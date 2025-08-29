using Godot;
using System;

public partial class HitArea : Area2D
{
    CharacterBody2D Parent;
    AnimationPlayer Anim;
    public override void _Ready()
    {
        this.AddToGroup("player");
        Parent = GetParent<CharacterBody2D>();
        Anim = Parent.GetNode<AnimationPlayer>("AnimationPlayer");
        this.BodyEntered += BombHit; 
        base._Ready();
    }

    private void BombHit(Node2D body)
    {
        if (body is RigidBody2D)
        {
            Anim.Play("hit");
        }
    }
}
