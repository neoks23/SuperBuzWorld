using Godot;
using System;

public class Titlescreen : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<TextureButton>("SettingsButton").GrabFocus();
        var musicManager = (MusicManager)GetNode("/root/MusicManager");
        musicManager.StopAll();
        var titleScreenAudio = (AudioStreamPlayer)GetNode("/root/MusicManager/Titlescreen");
        titleScreenAudio.Play();
    }

    //Play button

    public void _on_PlayButton_focus_entered()
    {
        GetNode<Label>("PlayButton/Label").Text = "<Play>";
    }
    public void _on_PlayButton_focus_exited()
    {
        GetNode<Label>("PlayButton/Label").Text = "Play";
    }
    public void _on_PlayButton_mouse_entered()
    {
        GetNode<Label>("PlayButton/Label").Text = "<Play>";
    }
    public void _on_PlayButton_mouse_exited()
    {
        GetNode<Label>("PlayButton/Label").Text = "Play";
    }
    public void _on_PlayButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GetTree().ChangeScene("res://UI/SaveSelect.tscn");
    }
    //Settings Button
    public void _on_SettingsButton_focus_entered()
    {
        GetNode<Label>("SettingsButton/Label").Text = "<Settings>";
    }
    public void _on_SettingsButton_focus_exited()
    {
        GetNode<Label>("SettingsButton/Label").Text = "Settings";
    }
    public void _on_SettingsButton_mouse_entered()
    {
        GetNode<Label>("SettingsButton/Label").Text = "<Settings>";
    }
    public void _on_SettingsButton_mouse_exited()
    {
        GetNode<Label>("SettingsButton/Label").Text = "Settings";
    }
    public void _on_SettingsButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GetTree().ChangeScene("res://UI/Settings.tscn");
    }

    //Quit Button

    public void _on_QuitButton_focus_entered()
    {
        GetNode<Label>("QuitButton/Label").Text = "<Quit>";
    }
    public void _on_QuitButton_focus_exited()
    {
        GetNode<Label>("QuitButton/Label").Text = "Quit";
    }
    public void _on_QuitButton_mouse_entered()
    {
        GetNode<Label>("QuitButton/Label").Text = "<Quit>";
    }
    public void _on_QuitButton_mouse_exited()
    {
        GetNode<Label>("QuitButton/Label").Text = "Quit";
    }
    public void _on_QuitButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GetTree().Quit();
    }
    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
