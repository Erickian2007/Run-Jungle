using Godot;
using System;

public partial class SlotPositionSystem : Node
{
    [Export]
    public bool clean = false;
    public override void _Process(double delta)
    {
        if (this.GetChildCount() == 0)
        {
            clean = true;

        }
    }
}
