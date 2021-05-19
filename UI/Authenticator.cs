using Godot;
using System;

public class Authenticator : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public static string user_info;
    public static string email;
    public static string world;
    public static Vector3 pos;
    public static Vector3 insidePos;
    public static Vector3 saveFile;
    public override void _Ready()
    {
        GetNode<TextureButton>("SignUpButton").GrabFocus();
    }
    public void _on_SignUpButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GetTree().ChangeScene("res://UI/Register.tscn");
    }
    public void _on_LoginButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GetTree().ChangeScene("res://UI/Login.tscn");
    }
    public void _on_QuitButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GetTree().Quit();
    }
    public void _on_ResetTokenButton_focus_entered()
    {
        GetNode<Label>("ResetTokenButton/Label").Text = "<Reset Token>";
    }
    public void _on_ResetTokenButton_focus_exited()
    {
        GetNode<Label>("ResetTokenButton/Label").Text = "Reset Token";
    }
    public void _on_ResetTokenButton_mouse_entered()
    {
        GetNode<Label>("ResetTokenButton/Label").Text = "<Reset Token>";
    }
    public void _on_ResetTokenButton_mouse_exited()
    {
        GetNode<Label>("ResetTokenButton/Label").Text = "Reset Token";
    }
    public void _on_ResetTokenButton_button_down()
    {
        GetNode<Label>("ResetTokenButton/Label").RectPosition = new Vector2(6, 15);
    }
    public void _on_ResetTokenButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GetNode<Label>("ResetTokenButton/Label").RectPosition = new Vector2(6, 0);

        GDScript registerDBClass = (GDScript)GD.Load("res://UI/RegisterDB.gd");
        Godot.Object registerDB = (Godot.Object)registerDBClass.New();
        registerDB.Call("_open_tokenizer");
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
