using Godot;
using System;

public partial class Pieces : Node2D
{
    [Export]
    public double speed = 1.0;
    [Export]
    public bool canMove = false;
    public override void _Process(double delta)
    {
        if (!canMove) return;
        Vector2 position = this.Position;
        position.X -= (float)(speed * delta);
        this.Position = position;
        base._Process(delta);
    }
}
