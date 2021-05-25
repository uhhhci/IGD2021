using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Gradient Gradient;
    public Image Fill;

    private HealthSystem HealthSystem;
    public void Setup(HealthSystem healthSystem)
    {
        this.HealthSystem = healthSystem;
        HealthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        Fill.color = Gradient.Evaluate(1f);
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        SetHealth();
    }

    public void SetHealth()
    {
        Slider.value = HealthSystem.GetHealthPercent();
        Fill.color = Gradient.Evaluate(HealthSystem.GetHealthPercent());
    }

}
