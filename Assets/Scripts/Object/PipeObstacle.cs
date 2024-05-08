using UnityEngine;
using ObstacleEventHandler = System.Action<PipeObstacle, UnityEngine.Vector2>;

public struct ObstacleModel
{
    public Vector2 SpawnPoint { get; }
    public Direction Direction { get; }
    public float Width { get; }
    public float Height { get; }
    public ObstacleEventHandler ObstacleVectorChanged;
    public float ObstacleSpeed { get; }

    public ObstacleModel(
        Vector2 spawnPoint,
        Direction direction,
        float height,
        float width,
        float obstacleSpeed,
        ObstacleEventHandler obstacleVectorChanged
    )
    {
        Direction = direction;
        SpawnPoint = spawnPoint;
        Width = width;
        Height = height;
        ObstacleSpeed = obstacleSpeed;
        ObstacleVectorChanged = obstacleVectorChanged;
    }
}

public enum Direction
{
    Up,
    Down
}

public class PipeObstacle : Obstacle
{
    ObstacleEventHandler ObstacleVectorChanged;
    private float obstacleSpeed;
    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        transform.Translate(obstacleSpeed * Time.deltaTime * Vector2.left);
        ObstacleVectorChanged(this, transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Obstacle got collided enter 2d by: " + collision);
        // called decrease health by 1.5 point
        if (collision.gameObject.TryGetComponent<Damage>(out Damage d))
        {
            DealDamage(d, 1.5f);
        }
    }

    public void Setup(ObstacleModel model)
    {
        transform.position = model.SpawnPoint;
        transform.localScale = new Vector2(model.Width, model.Height);
        ObstacleVectorChanged += model.ObstacleVectorChanged;
        obstacleSpeed = model.ObstacleSpeed;
    }
}
