using Godot;
using System;

public partial class Parallax : ParallaxBackground
{
    [Export]
    public float speed = -0.5f;
    [Export]
    public bool canMove = true;
    [Export]
    private int[] layersSpeed;

    public override void _Process(double delta)
    {
        if (canMove)
        {
            for (int i = 0; i < GetChildCount(); i++)
            {
                var layer = GetChild<ParallaxLayer>(i);
                Vector2 motion = layer.MotionOffset;
                motion.X += speed * layersSpeed[i] * (float)delta;
                layer.MotionOffset = motion;
            }
        }
        base._Process(delta);
    }
}
