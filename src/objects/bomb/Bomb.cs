using Godot;
using System;

public partial class Bomb : RigidBody2D
{
    public AnimatedSprite2D animatedSprite2D;
    public VisibleOnScreenNotifier2D visibleOnScreenNotifier2D;
    public AnimatedSprite2D effects;
    public Area2D area2D;
    public CollisionShape2D collisionShape2D;

    [Export]
    public Vector2 centralImpulse = new Vector2(-200.0f, -300.0f);
    [Export]
    public Vector2 constantCentralForce = new Vector2(-50.0f, 0.0f);
    public override void _Ready()
    {
        InitialForce();
        animatedSprite2D = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");
        visibleOnScreenNotifier2D = GetNodeOrNull<VisibleOnScreenNotifier2D>("VisibleNotifier");
        effects          = GetNodeOrNull<AnimatedSprite2D>("Effects");
        area2D           = GetNodeOrNull<Area2D>("Area2D");
        collisionShape2D = GetNodeOrNull<CollisionShape2D>("CollisionShape2D");
        // Set up signals
        //this.visibleOnScreenNotifier2D.ScreenExited += () => QueueFree();
        base._Ready();
    }

    public void InitialForce()
    {
        this.ApplyCentralImpulse(centralImpulse);
        this.AddConstantCentralForce(constantCentralForce);
    }
}
