using Godot;
using System;

public class InsideBobWorld : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<Control>("Buz/EscMenu").Visible = false;
        var musicManager = (MusicManager)GetNode("/root/MusicManager");
        musicManager.StopAll();
        var underWorldAudio = (AudioStreamPlayer)GetNode("/root/MusicManager/Underworld");
        underWorldAudio.Play();
    }
    public void _on_SaveButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GDScript saveDataGDClass = (GDScript)GD.Load("res://UI/SaveData.gd");
        Godot.Object saveDataGD = (Godot.Object)saveDataGDClass.New();
        KinematicBody2D buz = GetNode<KinematicBody2D>("Buz");
        saveDataGD.Call("_save_data", buz.Position, Authenticator.pos, Authenticator.saveFile, Authenticator.world, Bob.score);
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
    public void _on_WaterCollider_body_entered(Node body)
    {
        GetTree().ReloadCurrentScene();
    }
}
