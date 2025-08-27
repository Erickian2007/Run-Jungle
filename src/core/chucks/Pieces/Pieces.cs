using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

public partial class Pieces : Node2D
{
    public Timer Timer;
    public Marker2D NewChuckPosition;

    [Export]
    public double speed = 1.0;
    [Export]
    public int maxChucks = 3;
    [Export]
    public bool canMove = false;
    public override void _Ready()
    {
        Timer = GetNodeOrNull<Timer>("Timer");
        NewChuckPosition = GetNodeOrNull<Marker2D>("NewChuckPosition");
        Timer.Start();
        Timer.Timeout += () =>
        {
            GD.Print("Timeout");
            if (this.GetChildCount() < maxChucks)
            {
                CreateChucks();
            }   
        };
        base._Ready();
    }
    public void CreateChucks()
    {
        PackedScene chuckFloor = GD.Load<PackedScene>("res://src/objects/map/chunks/chunk_1.tscn");
        ChuckCore chuckFloorInstance = chuckFloor.Instantiate<ChuckCore>();
        chuckFloorInstance.Position = NewChuckPosition.Position;
        // Adiciona o ChuckCore como filho do nó atual
        this.CallDeferred("add_child", chuckFloorInstance);
    }
}
