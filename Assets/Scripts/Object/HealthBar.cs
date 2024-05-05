using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setup(IHealthManager healthManager)
    {
        healthManager.HealthEvent += this.HealthChange;
    }

    private void HealthChange(object sender, int val)
    {

    }
}
