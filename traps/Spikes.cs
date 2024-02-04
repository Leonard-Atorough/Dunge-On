using Godot;
using System;
using System.Threading;

public partial class Spikes : Node2D
{
	Godot.Timer DamageTimer { get; set; }
	Area2D Area2D { get; set; }
	[Export]
	DamageComponent DamageComponent { get; set; }

	public override void _Ready()
	{
		DamageTimer = GetNode<Godot.Timer>("DealDamageTimer");
		DamageTimer.Timeout += OnDamageTimerTmeout;

	}

	public override void _Process(double delta)
	{
		if (!DamageTimer.IsStopped())
		{

		}
	}

	public void OnDamageTimerTmeout()
	{
		GD.Print("Its all over");
	}
}
