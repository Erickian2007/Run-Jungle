using Godot;
using System;

public partial class GameSystem : Node
{
    [Signal]
    public delegate void GameOverEventHandler();
    [Signal]
    public delegate void StartGameEventHandler();
    public static bool IsGameStarted = false;
    public static double elapsedTime = 0.0;
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed)
        {
            if (keyEvent.Keycode == Key.Space || keyEvent.Keycode == Key.Up)
            {
                GD.Print("Game Started ", IsGameStarted);
                IsGameStarted = true;
                EmitSignal(SignalName.StartGame);
            }
        }
    }
    public override void _Process(double delta)
    {
        if (IsGameStarted)
        {
            elapsedTime += delta;    
        }
        base._Process(delta);

    }
}
