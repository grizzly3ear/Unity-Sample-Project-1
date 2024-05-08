using UnityEngine;

public abstract class Damage: MonoBehaviour
{
    protected abstract IHealthManager HealthManager { get; }
    public virtual float ComputeDamageReceive(Object sender, float damageDealt) { return 0; }

    public void DealDamage(Damage to, float damageDealt)
    {
        float finalDamage = to.ComputeDamageReceive(this, damageDealt);
        to.HealthManager.DecreaseHealth(finalDamage);
    }
}