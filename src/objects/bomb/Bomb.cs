using Godot;
using System;

public partial class Bomb : RigidBody2D
{
    VisibleOnScreenNotifier2D visibleOnScreenNotifier2D;
    public override void _Ready()
    {
        InitialForce();
        visibleOnScreenNotifier2D = GetNodeOrNull<VisibleOnScreenNotifier2D>("VisibleNotifier");
        this.visibleOnScreenNotifier2D.ScreenExited += () => QueueFree();
        base._Ready();
    }

    public void InitialForce()
    {
        this.ApplyCentralImpulse(new Vector2(-200.0f, -300.0f));
        this.AddConstantCentralForce(new Vector2(-50.0f, 0.0f));
    }
}
