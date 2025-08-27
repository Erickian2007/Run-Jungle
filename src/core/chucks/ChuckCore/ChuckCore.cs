using Godot;
using System;

public partial class ChuckCore : Node
{

    private VisibleOnScreenNotifier2D visibleOnScreenNotifier2D;
    public override void _Ready()
    {
        visibleOnScreenNotifier2D = GetNodeOrNull<VisibleOnScreenNotifier2D>("VisibleNotifier");
        this.visibleOnScreenNotifier2D.ScreenExited += () => QueueFree();
        base._Ready();
    }

}
