using Godot;

namespace DungeOn.resource_scripts
{
	public partial class MovementComponent : Node
	{
		[Export]
		CharacterBody2D actor;
		[Export]
		float min_slide_angle = 0.0f;

		public override void _Ready()
		{
			actor.WallMinSlideAngle = min_slide_angle;
			actor.MotionMode = CharacterBody2D.MotionModeEnum.Floating;
		}

		public override void _PhysicsProcess(double delta)
		{
			actor.MoveAndSlide();
		}
	}
}
