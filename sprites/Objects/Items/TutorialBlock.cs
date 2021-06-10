using Godot;
using System;

public class TutorialBlock : Node2D
{
    [Export] public string dialogue = "";
    [Export] public int dialogueType = 0;
    [Export] public bool isInstruction = false;
    [Export] public int instructionType = 0;

    private Sprite dialogueSprite;
    private Sprite instructionSprite;
    private Label dLabel;
    private float timer;

    public override void _Ready()
    {
        dialogueSprite = (Sprite)GetNode("Dialogue/Sprite");
        instructionSprite = (Sprite)GetNode("Dialogue/InstructionSprite");
        dLabel = (Label)GetNode("Dialogue/Text/Label");
        dLabel.Text = dialogue.CUnescape();
        for(int i = 0; i < 8; i++)
        {
            if(dialogueType == i)
            {
                dialogueSprite.Texture = (Texture)ResourceLoader.Load("res://sprites/UI/Dialogue/Test/D" + (i + 1).ToString() + ".png");
            }
        }
        dialogueSprite.Visible = false;
        dLabel.Visible = false;
        instructionSprite.Visible = false;

        if (dialogueType == 0)
        {

        }
        else if(dialogueType == 1)
        {
            dialogueSprite.Position = new Vector2(-12.773f, -43.541f);
            dLabel.RectPosition = new Vector2(-486f, -720f);
            dLabel.RectSize = new Vector2(689f, 519f);
        }
        else if (dialogueType == 2)
        {
            dialogueSprite.Position = new Vector2(13f, -43.541f);
            dLabel.RectPosition = new Vector2(-98f, -718f);
            dLabel.RectSize = new Vector2(444f, 509f);
        }
        else if (dialogueType == 3)
        {
            dialogueSprite.Position = new Vector2(33f, -15f);
            dLabel.RectPosition = new Vector2(204f, -416f);
            dLabel.RectSize = new Vector2(294f, 504f);
        }
        else if (dialogueType == 4)
        {
            dialogueSprite.Position = new Vector2(-33f, 15f);
            dLabel.RectPosition = new Vector2(-501f, -112f);
            dLabel.RectSize = new Vector2(294f, 504f);
        }
        else if (dialogueType == 5)
        {
            dialogueSprite.Position = new Vector2(-18f, -27f);
            dLabel.RectPosition = new Vector2(-501f, -396f);
            dLabel.RectSize = new Vector2(628f, 168f);
        }
        else if (dialogueType == 6)
        {
            dialogueSprite.Position = new Vector2(18f, -27f);
            dLabel.RectPosition = new Vector2(-114f, -398f);
            dLabel.RectSize = new Vector2(569f, 168f);
        }
        else if (dialogueType == 7)
        {
            dialogueSprite.Position = new Vector2(23f, -27f);
            dLabel.RectPosition = new Vector2(-107f, -385f);
            dLabel.RectSize = new Vector2(650f, 163f);
        }

        for (int i = 0; i < 8; i++)
        {
            if (instructionType == i)
            {
                instructionSprite.Texture = (Texture)ResourceLoader.Load("res://sprites/Keys/Instruction" + (i + 1).ToString() + ".png");
            }
        }
        if(instructionType == 0)
        {
            instructionSprite.Position = new Vector2(-13.258f, -43.561f);
        }
        if(instructionType == 1)
        {
            instructionSprite.Position = new Vector2(-32.328f, 14.709f);
        }
        if (instructionType == 2)
        {
            instructionSprite.Position = new Vector2(-13.258f, -43.561f);
        }

    }
    public void _on_Area2D_body_entered(Node body)
    {
        timer = 0;
        var tutorialBlockFx = (AudioStreamPlayer)GetNode("/root/SoundManager/TutorialBlock");
        tutorialBlockFx.Play();
        dialogueSprite.Visible = true;
        dLabel.Visible = true;
        if (isInstruction)
        {
            instructionSprite.Visible = true;
        }       
    }

    public override void _Process(float delta)
    {
        if (dialogueSprite.Visible)
        {
            timer += delta;
            if(timer > 5.0)
            {
                dialogueSprite.Visible = false;
                dLabel.Visible = false;
                if (instructionSprite.Visible)
                {
                    instructionSprite.Visible = false;
                }
            }
        }
    }
}
