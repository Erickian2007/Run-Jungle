using Godot;
using System;

public partial class GameOver : VisibleOnScreenNotifier2D
{
    public override void _Ready()
    {
        this.ScreenExited += () => GD.Print("Game Over - Screen Exited");
        GameSystem gs = GetNode<GameSystem>("/root/GameSystem");
        gs.EmitSignal("GameOver");
        base._Ready();
    }
}
