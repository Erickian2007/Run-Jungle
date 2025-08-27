using Godot;
using System;

public partial class Initial : Control
{
    public AnimationPlayer Anim;
    public override void _Ready()
    {
        Anim = GetNodeOrNull<AnimationPlayer>("AnimationPlayer");
        // Assuming you have an instance of GameSystem, for example as a singleton or node
        var gameSystem = GetNodeOrNull<GameSystem>("/root/GameSystem");
        if (gameSystem != null)
        {
            gameSystem.StartGame += () =>
            {
                if (Anim != null)
                {
                    Anim.Play("hide");
                }
            };
        }
        base._Ready();
    }
}
