using Godot;
using System;

public class GreenOrb : Node2D
{
    public void _on_Area2D_body_entered(Node body)
    {
        Bob.strongTimer = 60.0f;
        Bob.isStrong = true;
        var shootFx = (AudioStreamPlayer)GetNode("/root/SoundManager/Shoot");
        shootFx.Play();
        QueueFree();
    }
}
