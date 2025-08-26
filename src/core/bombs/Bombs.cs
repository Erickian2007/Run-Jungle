using Godot;
using System;

public partial class Bombs : Node2D
{
    [Export]
    public PackedScene bomb_scene;
    private bool canInstance = false;
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed)
        {
            if (keyEvent.Keycode == Key.Space || keyEvent.Keycode == Key.Up)
            {
                canInstance = true;
            }
        }
    }
    public void InstanceBombs()
    {
        RigidBody2D bomb = bomb_scene.Instantiate<RigidBody2D>();
        this.AddChild(bomb);
    }

    public void _TimerTimout()
    {
        if (canInstance)
        {
            InstanceBombs();
        }
    }
    
}
