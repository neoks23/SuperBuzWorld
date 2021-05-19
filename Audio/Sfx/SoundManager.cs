using Godot;
using System;

public class SoundManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    GlobalSettings globalSettings;
    AudioStreamPlayer ButtonClickFx;
    public override void _Ready()
    {
        globalSettings = (GlobalSettings)GetNode("/root/GlobalSettings");
        ButtonClickFx = GetNode<AudioStreamPlayer>("ButtonClick");
        ButtonClickFx.VolumeDb = (globalSettings.fxVolume - 30);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        ButtonClickFx.VolumeDb = (globalSettings.fxVolume - 30);
    }
}
