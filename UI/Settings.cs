using Godot;
using System;

public class Settings : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<TextureButton>("BackButton").GrabFocus();
        var musicSlider = GetNode<HSlider>("MusicSlider");
        var sfxSlider = GetNode<HSlider>("SfxSlider");
        var globalSettings = (GlobalSettings)GetNode("/root/GlobalSettings");
        musicSlider.Value = globalSettings.musicVolume;
        sfxSlider.Value = globalSettings.fxVolume;
        var fsCheckBox = GetNode<CheckBox>("Fullscreen/FullscreenCheckBox");
        var borderlessCheckBox = GetNode<CheckBox>("Borderless/BorderlessCheckBox");
        var VSyncCheckBox = GetNode<CheckBox>("VSync/VSyncCheckBox");
        if (OS.WindowFullscreen)
        {          
            fsCheckBox.Pressed = true;
        }
        else
        {
            fsCheckBox.Pressed = false;
        }
        if (OS.WindowBorderless)
        {
            borderlessCheckBox.Pressed = true;
        }
        else
        {
            borderlessCheckBox.Pressed = false;
        }
        if (OS.VsyncEnabled)
        {
            VSyncCheckBox.Pressed = true;
        }
        else
        {
            VSyncCheckBox.Pressed = false;
        }
    }
    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("ui_cancel"))
        {
            _on_BackButton_button_up();
        }
    }
    public void _on_SfxSlider_value_changed(float value)
    {
        var globalSettings = (GlobalSettings)GetNode("/root/GlobalSettings");
        globalSettings.fxVolume = value;
        var sfxSlider = GetNode<HSlider>("SfxSlider");
        var sfxSliderLabel = GetNode<Label>("SfxSlider/Label");
        sfxSliderLabel.Text = (value + 50).ToString();
        if (value == sfxSlider.MinValue)
        {
            globalSettings.fxEnabled = false;
        }
        else
        {
            globalSettings.fxEnabled = true;
        }
    }

    public void _on_MusicSlider_value_changed(float value)
    {
        var globalSettings = (GlobalSettings)GetNode("/root/GlobalSettings");
        globalSettings.musicVolume = value;
        var musicSlider = GetNode<HSlider>("MusicSlider");
        var musicSliderLabel = GetNode<Label>("MusicSlider/Label");
        musicSliderLabel.Text = (value + 50).ToString();
        if (value == musicSlider.MinValue)
        {
            globalSettings.musicEnabled = false;
        }
        else
        {
            globalSettings.musicEnabled = true;
        }
    }
    
    public void _on_BackButton_focus_entered()
    {
        GetNode<Label>("BackButton/Label").Text = "<Back>";
    }
    public void _on_BackButton_focus_exited()
    {
        GetNode<Label>("BackButton/Label").Text = "Back";
    }
    public void _on_BackButton_mouse_entered()
    {
        GetNode<Label>("BackButton/Label").Text = "<Back>";
    }
    public void _on_BackButton_mouse_exited()
    {
        GetNode<Label>("BackButton/Label").Text = "Back";
    }
    public void _on_BackButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GetTree().ChangeScene("res://UI/Titlescreen.tscn");
    }
    public void _on_FullscreenCheckBox_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        OS.WindowFullscreen = !OS.WindowFullscreen;
        var globalSettings = (GlobalSettings)GetNode("/root/GlobalSettings");

        if (OS.WindowFullscreen)
        {
            globalSettings.fullscreenEnabled = true;
        }
        else
        {
            globalSettings.fullscreenEnabled = false;
        }
    }
    public void _on_BorderlessCheckBox_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        OS.WindowBorderless = !OS.WindowBorderless;
        var globalSettings = (GlobalSettings)GetNode("/root/GlobalSettings");

        if (OS.WindowBorderless)
        {
            globalSettings.borderlessEnabled = true;
        }
        else
        {
            globalSettings.borderlessEnabled = false;
        }
    }
    public void _on_VSyncCheckBox_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        OS.VsyncEnabled = !OS.VsyncEnabled;
        var globalSettings = (GlobalSettings)GetNode("/root/GlobalSettings");

        if (OS.VsyncEnabled)
        {
            globalSettings.VSyncEnabled = true;
        }
        else
        {
            globalSettings.VSyncEnabled = false;
        }
    }
}
