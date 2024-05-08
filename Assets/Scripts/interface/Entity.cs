using System;
public abstract class Character: Damage
{
    
}

public abstract class Obstacle: Damage {
    protected override IHealthManager HealthManager
    {
        get
        {
            // There's no use case that obstacle got damaged right now
            return null;
        }
    }
}
