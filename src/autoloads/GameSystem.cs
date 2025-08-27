using Godot;
using System;

public  partial class GameSystem : Node
{
    [Signal]
    public delegate void StartGameEventHandler();
    public static bool IsGameStarted = false;
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed)
        {
            if (keyEvent.Keycode == Key.Space || keyEvent.Keycode == Key.Up)
            {
                IsGameStarted = true;
                EmitSignal(SignalName.StartGame);
            }
        }
    }
    public override void _Ready()
    {
        base._Ready();
    }
}
