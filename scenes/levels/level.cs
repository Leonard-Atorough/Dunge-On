using Godot;
using System;

public partial class level : Node2D
{
	TileMap TileMap { get; set; }
	Vector2I TileCellSize { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TileMap = (TileMap)GetParent().GetNode("Objects/TileMap");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
