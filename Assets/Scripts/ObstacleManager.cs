using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public int Gap = 3;
    public float Width = 0.5f;
    public float SpawnDelay = 1.5f;
    public float ObstacleSpeed = 1;
    public GameObject ObstaclePrefab;

    private IScreenManager ScreenManager { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateRandomizeObstacle());
    }

    IEnumerator CreateRandomizeObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnDelay);
            if (!ShouldStartRandomize()) {
                continue;
            }
            List<ObstacleModel> models = GenerateObstacleUpperAndLowerModels();
            models.ForEach((obs) =>
            {
                GameObject obstacleObject = Instantiate(ObstaclePrefab);
                PipeObstacle obstacle = obstacleObject.GetComponent<PipeObstacle>();
                obstacle.Setup(obs);
            });
        }
    }

    private bool ShouldStartRandomize()
    {
        return ScreenManager != null;
    }

    private List<ObstacleModel> GenerateObstacleUpperAndLowerModels()
    {
        List<ObstacleModel> lists = new();
        Rect screenRect = ScreenManager.GetScreenRect();
        float height = Random.Range(1.5f, 4f);

        float upperObsYCenter = screenRect.yMax - (height / 2);
        float lowerObsYCenter = (screenRect.yMax - height - Gap + screenRect.yMin) / 2;
        float lowerObsHeight = screenRect.yMax - height - Gap - screenRect.yMin;

        lists.Add(new ObstacleModel(
            new Vector2(
                screenRect.xMax,
                upperObsYCenter
            ),
            Direction.Down,
            height,
            Width,
            ObstacleSpeed,
            HandleObstacleOutOfScreen
        ));
        lists.Add(new ObstacleModel(
            new Vector2(
                screenRect.xMax,
                lowerObsYCenter
            ),
            Direction.Up,
            lowerObsHeight,
            Width,
            ObstacleSpeed,
            HandleObstacleOutOfScreen
        ));
        
        return lists;
    }

    public void Setup(IScreenManager screenManager)
    {
        ScreenManager = screenManager;
    }

    private void HandleObstacleOutOfScreen(PipeObstacle sender, Vector2 centerPos)
    {
        if (centerPos.x >= ScreenManager.GetScreenRect().xMin - (Width / 2))
        {
            return;
        }

        sender.gameObject.SetActive(false);
        Destroy(sender);
    }
}
