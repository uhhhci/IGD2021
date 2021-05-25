using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public event EventHandler OnHealthChanged;
    private int Health;
    private int HealthMax;

    public HealthSystem(int healthMax)
    {
        this.HealthMax = healthMax;
        this.Health = healthMax;
    }

    public int GetHealth()
    {
        return this.Health;
    }

    public float GetHealthPercent()
    {
        return (float)Health / HealthMax;
    } 

    public void Damage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

    public void Heal(int amount)
    {
        Health += amount;
        if (Health > HealthMax) Health = HealthMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
}
