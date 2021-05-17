using Godot;
using System;

public class Login : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    string user_info = null;
    public static bool b;
    public override void _Ready()
    {
        b = false;
        GetNode<TextureButton>("BackButton").GrabFocus();
    }
    public override void _PhysicsProcess(float delta)
    {
        if (b)
        {
            GetTree().ChangeScene("res://UI/Titlescreen.tscn");
        }
    }
    public void _on_BackButton_button_up()
    {
        GetTree().ChangeScene("res://UI/Authenticator.tscn");
    }
    public void _on_LoginButton_button_up()
    {
        GDScript loginDBClass = (GDScript)GD.Load("res://UI/LoginDB.gd");
        Godot.Object loginDB = (Godot.Object) loginDBClass.New();

        string email = GetNode<LineEdit>("Email").Text;
        string token = GetNode<LineEdit>("Token").Text;
        string password = GetNode<LineEdit>("Password").Text;
        loginDB.Call("_login", email.ToLower(), token, password);
    }
    public void ChangeScene()
    {
        b = true;
    }
    public void SaveAccount(string email)
    {
        Authenticator.email = email;
        GD.Print(Authenticator.email);
    }
    public void _on_Login_succeeded(string _user_info)
    {
        user_info = _user_info;
        Authenticator.user_info = user_info;
    }
    public void _on_ForgotPasswordButton_button_up()
    {
        GDScript loginDBClass = (GDScript)GD.Load("res://UI/LoginDB.gd");
        Godot.Object loginDB = (Godot.Object)loginDBClass.New();
        string email = GetNode<LineEdit>("Email").Text;

        loginDB.Call("_forgot_password", email);
    }
}
