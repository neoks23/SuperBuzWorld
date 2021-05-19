using Godot;
using System;

public class MusicManager : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.

    GlobalSettings globalSettings;
    AudioStreamPlayer titleScreenAudio;
    public override void _Ready()
    {
        globalSettings = (GlobalSettings)GetNode("/root/GlobalSettings");
        titleScreenAudio = GetNode<AudioStreamPlayer>("Titlescreen");
        titleScreenAudio.VolumeDb = (globalSettings.musicVolume - 30);
        titleScreenAudio.Autoplay = true;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        titleScreenAudio.VolumeDb = (globalSettings.musicVolume - 30);
    }
}
