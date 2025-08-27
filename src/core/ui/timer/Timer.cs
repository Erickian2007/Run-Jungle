using Godot;
using System;

public partial class TimerCount : Control
{
    private float elapsedTime = 0f;
    private bool isRunning = false;
    private Label timerLabel;

    public Action Timeout { get; internal set; }

    public override void _Ready()
    {
        GameSystem gameSystem = GetNodeOrNull<GameSystem>("/root/GameSystem");
        gameSystem.StartGame += () =>
        {
            isRunning = true;
        };
        timerLabel = GetNode<Label>("Label");
    }
    public override void _Process(double delta)
    {
        if (isRunning)
        {
            elapsedTime += (float)delta;
            // Exiba o tempo no formato mm:ss:ff (minutos:segundos:frações)
            timerLabel.Text = ($"{(int)(elapsedTime / 60):D2}:{(int)(elapsedTime % 60):D2}:{(int)((elapsedTime * 100) % 100):D2}");
        }
    }
}
