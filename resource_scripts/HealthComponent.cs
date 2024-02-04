using Godot;
using System;

public partial class HealthComponent : Node
{
    private int currrentHealth;

    [Export]
    public int MaxHealth { get; private set; } = 10;

    public int CurrrentHealth
    {
        get => currrentHealth;

        set
        {
            currrentHealth = Math.Clamp(value, 0, MaxHealth);
        }
    }
    public void TakeDamage(int amount)
    {
        currrentHealth -= amount;
    }

}
