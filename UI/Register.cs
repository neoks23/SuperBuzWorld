using Godot;
using System;

public class Register : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    string user_info = null;
    string email;
    string username;
    public override void _Ready()
    {
        GetNode<TextureButton>("RegisterDB/BackButton").GrabFocus();
    }
    public override void _Process(float delta)
    {
        if (Input.IsActionJustPressed("ui_cancel"))
        {
            _on_BackButton_button_up();
        }
    }
    public void _on_BackButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GetTree().ChangeScene("res://UI/Authenticator.tscn");
    }
    public void _on_SignUpButton_button_up()
    {
        var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
        buttonClickFx.Play();
        GDScript registerDBClass = (GDScript)GD.Load("res://UI/RegisterDB.gd");
        Godot.Object registerDB = (Godot.Object)registerDBClass.New();

        email = GetNode<LineEdit>("RegisterDB/Email").Text;
        username = GetNode<LineEdit>("RegisterDB/Username").Text;
        string password = GetNode<LineEdit>("RegisterDB/Password").Text;
        registerDB.Call("_register", email, username, password);
    }
    public void _on_SignUp_succeeded(string _user_info)
    {
        user_info = _user_info;
        Authenticator.user_info = user_info;
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
