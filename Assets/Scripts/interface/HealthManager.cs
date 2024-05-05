using HealthEvent = System.EventHandler<int>;

public interface IHealthManager
{
    void IncreaseHealth(int val);
    void DecreaseHealth(int val);
    public event HealthEvent HealthEvent;
}

public class HealthManager : IHealthManager
{
    private int health;
    public event HealthEvent HealthEvent;

    public void DecreaseHealth(int val)
    {
        health -= val;
        PublishHealthEvent();
    }

    public void IncreaseHealth(int val)
    {
        health += val;
        PublishHealthEvent();
    }

    private void PublishHealthEvent()
    {   
        HealthEvent?.Invoke(this, health);
    }
}
