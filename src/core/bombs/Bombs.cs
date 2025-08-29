using Godot;
using System;

public partial class Bombs : Node2D
{
    [Export]
    public int spawn_interval = 3; // Intervalo de spawn em segundos
    [Export]
    public PackedScene bomb_scene;
    private Timer timer;
    public override void _Ready()
    {
        timer = GetNodeOrNull<Timer>("Timer");
        timer.WaitTime = 1.0f;
        timer.Start();
        timer.Timeout += () =>
        {
            if (!GameSystem.IsGameStarted) return;
            timer.WaitTime = GD.RandRange((spawn_interval / 2), spawn_interval - (float)(GameSystem.elapsedTime / 10));
            GD.Print("Timer Timeout - Instance Bomb");
            InstanceBombs();
        };
        base._Ready();
    }
    public void InstanceBombs()
    {
        if (bomb_scene == null)
        {
            GD.PrintErr("[Bombs] bomb_scene não está atribuído! Arraste o arquivo bomb.tscn para o campo Bomb Scene no inspetor.");
            return;
        }
        RigidBody2D bomb = bomb_scene.Instantiate<RigidBody2D>();
        if (bomb == null)
        {
            GD.PrintErr("[Bombs] Falha ao instanciar bomb_scene! Verifique se bomb.tscn é do tipo RigidBody2D.");
            return;
        }
        this.AddChild(bomb);
    }
}
