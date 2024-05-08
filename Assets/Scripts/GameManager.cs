using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerObject;
    public GameObject HealthBarObject;
    public GameObject ObstacleManagerObject;
    
    // Start is called before the first frame update
    void Start()
    {
        IHealthManager healthManager = new HealthManager();

        HealthBar healthBar = HealthBarObject.GetComponent<HealthBar>();
        healthBar.Setup(healthManager);
        Player player = PlayerObject.GetComponent<Player>();
        player.Setup(healthManager);

        ICameraManager cameraManager = new CameraManager();
        IScreenManager screenManager = new ScreenManager(cameraManager);

        ObstacleManager obstacleManager = ObstacleManagerObject.GetComponent<ObstacleManager>();
        obstacleManager.Setup(screenManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
