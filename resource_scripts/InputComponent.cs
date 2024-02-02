using Godot;
using System;
using System.Diagnostics;

public partial class InputComponent : Node
{
	[Export]
	CharacterBody2D actor;
	[Export]
	Node2D body;
	[Export]
	AnimationPlayer player;
	[Export]
	float maxSpeed = 100.0f;
	[Export]
	float acceleration = 1000.0f;
	[Export]
	float friction = 500.0f;

    string idleState = "idle_sideways";

    public override void _PhysicsProcess(double delta)
    {
        var input = Input.GetVector("move_backward", "move_forward", "move_up", "move_down");
		var mousePosition = actor.GetGlobalMousePosition();
		var mouseDirection = mousePosition.X > actor.GlobalPosition.X;

        body.Scale = mouseDirection ? new Vector2I(1, 1) : body.Scale = new Vector2I(-1, 1);

        if (input.Length() > 0)
		{
			actor.Velocity = actor.Velocity.MoveToward(input * maxSpeed, (float)(acceleration * delta));
            player.Play("walk_sideways");
            idleState = new string("idle_sideways");
		}
		else
		{
			actor.Velocity = actor.Velocity.MoveToward(Vector2.Zero, (float)(friction * delta));
			player.Play(idleState);
		}
    }
}
