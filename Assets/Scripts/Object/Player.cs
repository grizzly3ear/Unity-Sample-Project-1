using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int JumpForce = 1000;

    protected override IHealthManager HealthManager {
        get
        {
            return _healthManager;
        }
    }

    private IHealthManager _healthManager;

    void Start()
    {
        // load image
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Getrigidbody().velocity = new Vector2(0, 0);
            Getrigidbody().AddForce(new Vector2(0, JumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.TryGetComponent(out Damage d))
        //{
        //    float damage = d.DamageDealt();
        //    HealthManager.DecreaseHealth(damage);
        //}
    }

    public void Setup(
        IHealthManager healthManager
    )
    {
        _healthManager = healthManager;
    }

    public override float ComputeDamageReceive(Object sender, float damageDealt)
    {
        // minus by armor is available
        return damageDealt;
    }

    private Rigidbody2D Getrigidbody()
    {
        return GetComponent<Rigidbody2D>();
    }
}
