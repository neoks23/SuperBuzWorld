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
    }

    public override void _Process(float delta)
    {
        var escMenu = GetNode<Control>("Buz/EscMenu");

        if (escMenu.Visible) {
            if (Input.IsActionJustPressed("ui_cancel"))
            {
                var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
                buttonClickFx.Play();
                escMenu.Visible = false;
            }
        }
    }
    public void _on_SaveButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GDScript saveDataGDClass = (GDScript)GD.Load("res://UI/SaveData.gd");
        Godot.Object saveDataGD = (Godot.Object)saveDataGDClass.New();
        KinematicBody2D buz = GetNode<KinematicBody2D>("Buz");
        saveDataGD.Call("_save_data", buz.Position, Authenticator.pos, Authenticator.saveFile, Authenticator.world);
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
}
