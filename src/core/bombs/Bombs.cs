using Godot;
using System;

public partial class Bombs : Node2D
{
    [Export]
    public PackedScene bomb_scene;

    public Timer timer;
    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        timer.Timeout += _TimerTimout;
        base._Ready();
    }
    public void InstanceBombs()
    {
        RigidBody2D bomb = bomb_scene.Instantiate<RigidBody2D>();
        this.AddChild(bomb);
    }

    public void _TimerTimout()
    {
        InstanceBombs();
    }
    
}
