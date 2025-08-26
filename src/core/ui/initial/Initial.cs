using Godot;
using System;

public partial class Initial : Control
{
    public AnimationPlayer Anim;
    public override void _Ready()
    {
        Anim = GetNodeOrNull<AnimationPlayer>("AnimationPlayer");
        base._Ready();
    }
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed)
        {
            if (keyEvent.Keycode == Key.Space || keyEvent.Keycode == Key.Up)
            {
                if (Anim != null)
                {
                    Anim.Play("hide");
                }    
            }
        }
        base._Input(@event);
    }
}
