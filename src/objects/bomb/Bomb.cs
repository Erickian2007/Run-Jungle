using Godot;
using System;

public partial class Bomb : RigidBody2D
{
    public override void _Ready()
    {
        InitialForce();
        base._Ready();
    }

    public void InitialForce()
    {
        this.ApplyCentralImpulse(new Vector2(-200.0f, -300.0f));
        this.AddConstantCentralForce(new Vector2(-50.0f, 0.0f));
    }
}
