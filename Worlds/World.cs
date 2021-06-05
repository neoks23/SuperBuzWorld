using Godot;
using System;

public class World : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<Control>("Bob/EscMenu").Visible = false;
        var musicManager = (MusicManager)GetNode("/root/MusicManager");
        musicManager.StopAll();
        var overWorldAudio = (AudioStreamPlayer)GetNode("/root/MusicManager/Overworld");
        overWorldAudio.Play();
    }
    public void _on_SaveButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GDScript saveDataGDClass = (GDScript)GD.Load("res://UI/SaveData.gd");
        Godot.Object saveDataGD = (Godot.Object)saveDataGDClass.New();
        KinematicBody2D bob = GetNode<KinematicBody2D>("Bob");
        saveDataGD.Call("_save_data", bob.Position, Authenticator.insidePos, Authenticator.saveFile, Authenticator.world);
    }
    public void _on_MainMenuButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GetTree().ChangeScene("res://UI/Titlescreen.tscn");
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
