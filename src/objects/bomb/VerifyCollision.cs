using Godot;
using System;

public partial class VerifyCollision : Area2D
{
    public Bomb bomb;

    public override void _Ready()
    {
        bomb = GetParent<Bomb>();
        this.AreaEntered += (Area2D) =>
        {
            GD.Print("Bomb hit an area");
            if (!Area2D.IsInGroup("player")) return;
            bomb.animatedSprite2D.Hide();

            // animate explosion
            bomb.effects.Show();
            bomb.effects.Play("explode");
            bomb.effects.AnimationFinished += () => bomb.QueueFree();

            GD.Print(Area2D.GetParent<Node2D>().Name, " hit the player");
        };
        base._Ready();
    }
}
