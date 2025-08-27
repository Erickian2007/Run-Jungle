using Godot;
using System;

public partial class SlotPositionSystem : Node
{
    // Variables Exports
    [Export]
    public bool clean = false;
    public Node2D chuck;
    public Area2D area2D;
    public override void _Ready()
    {
        chuck = GetChildOrNull<Node2D>(0);
        area2D = GetNodeOrNull<Area2D>("End");
        area2D.AreaExited += (Area2D area) =>
        {
            CreateChuck();
            GD.Print("Area Exited", area.Name);
        };
        base._Ready();
    }

    public void CreateChuck()
    {
        PackedScene chuckFloor = GD.Load<PackedScene>("res://src/objects/map/chunks/chunk_1.tscn");
        ChuckCore chuckFloorInstance = chuckFloor.Instantiate<ChuckCore>();
        // Adiciona o ChuckCore como filho do nó atual
        this.AddChild(chuckFloorInstance);
        this.clean = false;
    }        // Instancia o ChuckCore
    public override void _Process(double delta)
    {
        if (this.GetChildCount() == 0)
        {
            clean = true;

        }
    }
}
