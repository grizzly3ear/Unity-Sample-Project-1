using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Use this for initialization
    public float CurrentHealth = 100;

    void Start()
    {
        var slider = GetComponent<Slider>();
        slider.maxValue = CurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        var slider = GetComponent<Slider>();
        slider.value = CurrentHealth;
    }

    public void Setup(IHealthManager healthManager)
    {
        healthManager.HealthEvent += this.HealthChange;
    }

    private void HealthChange(object sender, float val)
    {
        CurrentHealth += val;
    }
}
