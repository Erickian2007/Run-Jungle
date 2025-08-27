using Godot;
using Microsoft.VisualBasic;
using System;
using System.Data.Common;

public partial class ChuckCore : Node2D
{
    [Export]
    public double speed = 100.0;
    [Export]
    public bool canMove = true;
    public VisibleOnScreenNotifier2D visibleOnScreenNotifier2D;
    public Area2D area2D;
    public override void _Ready()
    {
        visibleOnScreenNotifier2D = GetNodeOrNull<VisibleOnScreenNotifier2D>("VisibleNotifier");
        area2D = GetNodeOrNull<Area2D>("Area2D");

        this.visibleOnScreenNotifier2D.ScreenExited += () => QueueFree();

        base._Ready();
    }
    public override void _Process(double delta)
    {
        TranslateChucks(delta);
    }
    public void TranslateChucks(double delta)
    {
        if (!canMove) return;
        Vector2 position = this.Position;
        position.X -= (float)(speed * delta);
        this.Position = position;
        base._Process(delta);
    }

}
