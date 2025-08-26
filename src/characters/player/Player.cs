using Godot;
using System;

public partial class Player : CharacterBody2D
{

    [Export]
    public int jumpForce = -500;
    private AnimatedSprite2D _anim;
    private bool jumped = false;
    public override void _Ready()
    {
        _anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        // Gravity
        float gravity = 1200f;
        if (!IsOnFloor())
        {
            Velocity += new Vector2(0, gravity * (float)delta);
        }
        else
        {
            jumped = false;
        }

        if (Input.IsActionJustPressed("ui_accept") || Input.IsActionJustPressed("ui_up"))
        {
            if (IsOnFloor())
            {
                _anim.Play("run");
                jumped = true;
                Velocity = new Vector2(0, jumpForce);
            }
        }

        this.MoveAndSlide();
    }
}
