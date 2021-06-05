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
    AudioStreamPlayer overWorldAudio;
    AudioStreamPlayer underWorldAudio;
    public override void _Ready()
    {
        globalSettings = (GlobalSettings)GetNode("/root/GlobalSettings");
        titleScreenAudio = GetNode<AudioStreamPlayer>("Titlescreen");
        titleScreenAudio.VolumeDb = (globalSettings.musicVolume - 30);
        titleScreenAudio.Autoplay = true;
        overWorldAudio = GetNode<AudioStreamPlayer>("Overworld");
        overWorldAudio.VolumeDb = (globalSettings.musicVolume - 30);
        overWorldAudio.Autoplay = true;
        underWorldAudio = GetNode<AudioStreamPlayer>("Underworld");
        underWorldAudio.VolumeDb = (globalSettings.musicVolume - 30);
        underWorldAudio.Autoplay = true;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        titleScreenAudio.VolumeDb = (globalSettings.musicVolume - 30);
        overWorldAudio.VolumeDb = (globalSettings.musicVolume - 30);
        underWorldAudio.VolumeDb = (globalSettings.musicVolume - 30);
    }
    public void StopAll()
    {
        titleScreenAudio.Stop();
        overWorldAudio.Stop();
        underWorldAudio.Stop();
    }
}
