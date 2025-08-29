using Godot;
using System;

public partial class TimerCount : Label
{
    public float elapsedTime = 0f;
    public override void _Process(double delta)
    {
        elapsedTime = (float)GameSystem.elapsedTime;
        // Exiba o tempo no formato mm:ss:ff (minutos:segundos:frações)
        this.Text = ($"{(int)(elapsedTime / 60):D2}:{(int)(elapsedTime % 60):D2}:{(int)((elapsedTime * 100) % 100):D2}");
        base._Process(delta);
    }
}
