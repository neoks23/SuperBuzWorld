using Godot;
using System;

public class GlobalSettings : Node
{
    [Export]
    public bool fullscreenEnabled = false;
    [Export]
    public bool borderlessEnabled = false;
    [Export]
    public bool VSyncEnabled = false;
    [Export]
    public bool musicEnabled = true;
    [Export]
    public bool fxEnabled = true;

    [Export]
    public float musicVolume = 0;
    [Export]
    public float fxVolume = 0;
}
