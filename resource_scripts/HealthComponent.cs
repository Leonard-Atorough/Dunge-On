using Godot;
using System;

public partial class HealthComponent : Node
{
    [Export]
    public int MaxHealth { get; private set; } = 10;
    public Timer IFrameTimer { get; set; }

    private int _currrentHealth;
    private bool _invincible;

    public int CurrrentHealth
    {
        get => _currrentHealth;

        set
        {
            _currrentHealth = Math.Clamp(value, 0, MaxHealth);
        }
    }

    public override void _Ready()
    {
        _currrentHealth = MaxHealth;
        this.IFrameTimer = GetNode<Timer>("IFrameTimer");
        this.IFrameTimer.Timeout += OnIFrameTimerTimeout;
    }

    private void OnIFrameTimerTimeout()
    {
        _invincible = false;
    }

    public void TakeDamage(int amount)
    {
        if (!_invincible)
        {
            GD.Print(amount);
            _currrentHealth -= amount;
            GD.Print(_currrentHealth);
        }
        _invincible = true;
        this.IFrameTimer.Start();
    }

}
