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
    AudioStreamPlayer StepFx;
    AudioStreamPlayer JumpFx;
    AudioStreamPlayer CoinFx;
    AudioStreamPlayer TutorialBlockFx;
    AudioStreamPlayer ShootFx;
    public override void _Ready()
    {
        globalSettings = (GlobalSettings)GetNode("/root/GlobalSettings");
        ButtonClickFx = GetNode<AudioStreamPlayer>("ButtonClick");
        ButtonClickFx.VolumeDb = (globalSettings.fxVolume - 30);
        StepFx = GetNode<AudioStreamPlayer>("Step");
        StepFx.VolumeDb = (globalSettings.fxVolume - 30);
        JumpFx = GetNode<AudioStreamPlayer>("Jump");
        JumpFx.VolumeDb = (globalSettings.fxVolume - 30);
        CoinFx = GetNode<AudioStreamPlayer>("Coin");
        CoinFx.VolumeDb = (globalSettings.fxVolume - 30);
        TutorialBlockFx = GetNode<AudioStreamPlayer>("TutorialBlock");
        TutorialBlockFx.VolumeDb = (globalSettings.fxVolume - 30);
        ShootFx = GetNode<AudioStreamPlayer>("Shoot");
        ShootFx.VolumeDb = (globalSettings.fxVolume - 30);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        ButtonClickFx.VolumeDb = (globalSettings.fxVolume - 30);
        StepFx.VolumeDb = (globalSettings.fxVolume - 30);
        JumpFx.VolumeDb = (globalSettings.fxVolume - 30);
        CoinFx.VolumeDb = (globalSettings.fxVolume - 30);
        TutorialBlockFx.VolumeDb = (globalSettings.fxVolume - 30);
        ShootFx.VolumeDb = (globalSettings.fxVolume - 30);
    }
}
