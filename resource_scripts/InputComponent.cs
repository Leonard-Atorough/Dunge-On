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

    string idleState = "idle_forward";

    public override void _PhysicsProcess(double delta)
    {
        var input = Input.GetVector("move_backward", "move_forward", "move_up", "move_down");

		if (input.Length() > 0)
		{
			actor.Velocity = actor.Velocity.MoveToward(input * maxSpeed, (float)(acceleration * delta));

			if (actor.Velocity.X != 0)
			{
                player.Play("walk_sideways");
                idleState = new string("idle_sideways");

                body.Scale = actor.Velocity.X > 0 ? new Vector2I(1, 1) : body.Scale = new Vector2I(-1, 1);
            }
			else if (actor.Velocity.Y < 0)
			{
				player.Play("walk_backward");
				idleState = new string("idle_backward");
			}
			else
			{
                player.Play("walk_forward");
                idleState = new string("idle_forward");
            }
		}
		else
		{
			actor.Velocity = actor.Velocity.MoveToward(Vector2.Zero, (float)(friction * delta));
			player.Play(idleState);
		}
    }
}
