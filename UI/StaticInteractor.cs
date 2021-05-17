using Godot;
using System;

public class StaticInteractor : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public string GetEmail()
    {
        return Authenticator.email;
    }

    public Vector3 GetPos()
    {
        return Authenticator.pos;
    }
    public void SetSaveFile(int i)
    {
        if(i == 0)
        {
            Authenticator.saveFile = new Vector3(1, 0, 0);
        }
        if(i == 1)
        {
            Authenticator.saveFile = new Vector3(0, 1, 0);
        }
        if(i == 2)
        {
            Authenticator.saveFile = new Vector3(0, 0, 1);
        }
    }
    public void SetPos(float x, float y, float z)
    {
        Authenticator.pos = new Vector3(x, y, z);
    }
    public void SetInsidePos(float x, float y, float z)
    {
        Authenticator.insidePos = new Vector3(x, y, z);
    }
}
