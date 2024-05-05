using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ObstacleManagerObject;
    // Start is called before the first frame update
    void Start()
    {
        //IHealthManager healthManager = new HealthManager();

        //GameObject healthBarObject = new("");
        //HealthBar healthBar = healthBarObject.GetComponent<HealthBar>();
        //healthBar.Setup(healthManager);

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
