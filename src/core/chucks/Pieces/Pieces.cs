using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

public partial class Pieces : Node2D
{
    public Marker2D instaceFloor;

    [Export]
    public double speed = 1.0;
    [Export]
    public int maxChucks = 3;
    [Export]
    public bool canMove = false;

    public List<ChuckCore> chucks = new List<ChuckCore>();
    public override void _Ready()
    {
        instaceFloor = GetNode<Marker2D>("InstanceFloor");
        base._Ready();
    }
    public override void _Process(double delta)
    {
        TranslateChucks(delta);
        CreateChucks();

        base._Process(delta);
    }
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed)
        {
            if (keyEvent.Keycode == Key.Space || keyEvent.Keycode == Key.Up)
            {
                canMove = true;
            }
        }
    }
    public void TranslateChucks(double delta)
    {
        if (!canMove) return;
        Vector2 position = this.Position;
        position.X -= (float)(speed * delta);
        this.Position = position;
        base._Process(delta);
    }
    public void CreateChucks()
    {
        if (chucks.Count >= maxChucks) return;
        for (int i = 0; i < this.GetChildCount(); i++)
        {
            var slot = GetChild<SlotPositionSystem>(i);
            if (slot.clean)
            {
                PackedScene chuckFloor = GD.Load<PackedScene>("res://src/objects/map/chunks/chunk_1.tscn");
                ChuckCore chuckFloorInstance = chuckFloor.Instantiate<ChuckCore>();
                // Adiciona o ChuckCore como filho do nó atual
                slot.AddChild(chuckFloorInstance);
                slot.clean = false;
                break;
            }
        }
        // Instancia o ChuckCore

    }
}
