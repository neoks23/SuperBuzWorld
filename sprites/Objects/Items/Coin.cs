using Godot;
using System;

public class Coin : Area2D
{
    public void _on_Coin_body_entered(Node body)
    {
        Bob.score += 10;
        var coinFx= (AudioStreamPlayer)GetNode("/root/SoundManager/Coin");
        coinFx.Play();
        QueueFree();
    }
}
