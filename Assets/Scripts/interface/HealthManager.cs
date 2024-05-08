using HealthEvent = System.EventHandler<float>;

public interface IHealthManager
{
    void IncreaseHealth(float val);
    void DecreaseHealth(float val);
    public event HealthEvent HealthEvent;
}

public class HealthManager : IHealthManager
{
    private float health;
    public event HealthEvent HealthEvent;

    public void DecreaseHealth(float val)
    {
        health -= val;
        PublishHealthEvent();
    }

    public void IncreaseHealth(float val)
    {
        health += val;
        PublishHealthEvent();
    }

    private void PublishHealthEvent()
    {   
        HealthEvent?.Invoke(this, health);
    }
}
