using UnityEngine;
using ObstacleEventHandler = System.Action<Obstacle, UnityEngine.Vector2>;

public struct ObstacleModel
{
    public Vector2 SpawnPoint { get; }
    public Direction Direction { get; }
    public float Width { get; }
    public float Height { get; }
    public ObstacleEventHandler ObstacleVectorChanged;

    public ObstacleModel(
        Vector2 spawnPoint,
        Direction direction,
        float height,
        float width,
        ObstacleEventHandler obstacleVectorChanged
    )
    {
        Direction = direction;
        SpawnPoint = spawnPoint;
        Width = width;
        Height = height;
        ObstacleVectorChanged = obstacleVectorChanged;
    }
}

public enum Direction
{
    Up,
    Down
}

public class Obstacle : MonoBehaviour
{
    ObstacleEventHandler ObstacleVectorChanged;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);
        ObstacleVectorChanged(this, transform.position);
        // if out of screen
        // publish some event to manager
        // or manager should observe the pos of obstacle
    }

    private void OnTriggerEnter(Collider other)
    {
        // Show broken obstacle when touch
    }

    public void Setup(ObstacleModel model)
    {
        transform.position = model.SpawnPoint;
        transform.localScale = new Vector2(model.Width, model.Height);
        ObstacleVectorChanged += model.ObstacleVectorChanged;
    }
}
