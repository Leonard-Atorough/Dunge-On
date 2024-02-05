using Godot;
using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

public partial class Spikes : Node2D
{
	Godot.Timer DamageTimer { get; set; }
	Area2D Area2D { get; set; }
	[Export]
	DamageComponent DamageComponent { get; set; }

	private bool _spikesActive;
	private List<Node2D> _bodies = new List<Node2D>();

	public override void _Ready()
	{
		this.DamageTimer = GetNode<Godot.Timer>("DealDamageTimer");
		this.Area2D = GetNode<Area2D>("DamageZone");
		DamageTimer.Timeout += OnDamageTimerTmeout;
		Area2D.BodyEntered += OnBodyEntered;
		Area2D.BodyExited += OnBodyExited;
	}

    public override void _Process(double delta)
    {
        if (_spikesActive)
        {
			foreach (Node2D body in _bodies)
			{
                DamageComponent.DealDamage(body);
            }
        }
    }

    public void OnBodyEntered(Node2D body)
	{
		_bodies.Add(body);
	}

    private void OnBodyExited(Node2D body)
    {
        _bodies.Remove(body);
    }

    public void ResetTimer()
	{
		DamageTimer.Start();
		_spikesActive = false;
	}

	public void OnDamageTimerTmeout()
	{
		_spikesActive = true;
	}
}
