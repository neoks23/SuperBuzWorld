using Godot;
using System;

public class BlockCrate : Node2D
{
    public void _on_Area2D_body_entered(Node body)
    {
        if (Bob.isStrong)
        {
            QueueFree();
        }
    }
}
