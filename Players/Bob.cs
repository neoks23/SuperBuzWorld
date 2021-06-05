using Godot;
using System;

public class Bob : KinematicBody2D
{
    [Export] public int speed = 200;
    [Export] public float runSpeed = 1.2f;
    [Export] public int jumpHeight = 400;
    public static int score = 0;

    public Vector2 velocity;
    private AnimationTree animtree;
    private AnimationNodeStateMachinePlayback stateMachine;
    private bool isRunning;
    private float gravity = 10f;
    private ParallaxBackground pbg;

    private Vector2 FLOOR_NORMAL = Vector2.Up;
    private float SNAP_LENGTH = 32.0f;
    private float MAX_SLOPE_ANGLE = 40.0f;
    private float FLOOR_MAX_ANGLE;
    bool jumping = false;

    private Vector2 snapVector;
    public override void _Ready()
    {
        jumping = false;
        FLOOR_MAX_ANGLE = Mathf.Deg2Rad(46);
        snapVector = new Vector2(0, SNAP_LENGTH);
        velocity = new Vector2();
        animtree = GetNode("AnimationTree") as AnimationTree;
        pbg = GetNode("ParallaxBackground") as ParallaxBackground;
        animtree.GetRootMotionTransform();
        stateMachine = (AnimationNodeStateMachinePlayback)animtree.Get("parameters/playback");
        isRunning = false;
        Authenticator.world = "OverWorld";
        Position = new Vector2(Authenticator.pos.x, Authenticator.pos.y);
    }
    public void ChangeAnimationState(string travelingState)
    {
        if (velocity.y <= 0.5f)
        {
            stateMachine.Travel(travelingState);
        }
    }
    public void GetInput()
    {
        if (Input.IsActionPressed("right"))
        {
            if (Input.IsActionPressed("run"))
            {
                velocity.x = speed * runSpeed;
            }
            else
            {
                velocity.x = speed;
            }
            ChangeAnimationState("Run");
            WalkFx();
        }
        else if (Input.IsActionPressed("left"))
        {
            if (Input.IsActionPressed("run"))
            {
                velocity.x = -speed * runSpeed;
            }
            else
            {
                velocity.x = -speed;
            }
            ChangeAnimationState("Run");
            WalkFx();
        }
        else
        {
            velocity.x = 0;
            ChangeAnimationState("Idle");
            var stepFx = (AudioStreamPlayer)GetNode("/root/SoundManager/Step");
            stepFx.Stop();
        }
        if (!IsOnFloor())
        {
            var stepFx = (AudioStreamPlayer)GetNode("/root/SoundManager/Step");
            stepFx.Stop();
        }
        if (Input.IsActionJustPressed("up") && IsOnFloor())
        {
            velocity.y += -jumpHeight;
            jumping = true;
            var jumpFx = (AudioStreamPlayer)GetNode("/root/SoundManager/Jump");
            jumpFx.Play();
        }
        if (jumping && velocity.y >= 0)
        {
            jumping = false;
        }
        snapVector = new Vector2(0, SNAP_LENGTH);
        if (jumping)
        {
            snapVector = new Vector2();
            stateMachine.Travel("Jump");
        }

        if (Input.IsActionJustPressed("tp"))
        {
            Authenticator.pos = new Vector3(Position.x, Position.y, 0);
            GetTree().ChangeScene("res://Worlds/InsideBobWorld.tscn");
        }
    }

    public override void _PhysicsProcess(float delta)
    {
        if (!GetNode<Control>("EscMenu").Visible)
        {
            if (Input.IsActionJustPressed("esc"))
            {

                GetNode<Control>("EscMenu").Visible = true;
                GetNode<TextureButton>("EscMenu/Sprite/SaveButton").GrabFocus();
                var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
                buttonClickFx.Play();
            }
        }
        else
        {
            if (Input.IsActionJustPressed("ui_cancel"))
            {
                GetNode<Control>("EscMenu").Visible = false;
                var buttonClickFx = (AudioStreamPlayer)GetNode("/root/SoundManager/ButtonClick");
                buttonClickFx.Play();
            }
        }

        if (!GetNode<Control>("EscMenu").Visible)
        {
            Slope();
            GetInput();
            velocity.y += gravity;

            animtree.Set("parameters/Jump/blend_position", velocity.x);
            animtree.Set("parameters/Run/blend_position", velocity.x);

            velocity = MoveAndSlideWithSnap(velocity * delta * 60, snapVector, FLOOR_NORMAL, true, 4, FLOOR_MAX_ANGLE);

            pbg.Offset = new Vector2(Position.x / 10, (Position.y / 10) + 200);
            
        }        
    }
    public void WalkFx()
    {
        if (IsOnFloor())
        {
            var stepFx = (AudioStreamPlayer)GetNode("/root/SoundManager/Step");
            if (!stepFx.Playing)
            {
                stepFx.Play();
            }
        }
    }
    public void Slope()
    {

        var slides = GetSlideCount();
        for (int i = 0; i < slides; i++)
        {
            var normal = GetSlideCollision(i).Normal;
            var slopeAngle = Mathf.Rad2Deg(Mathf.Acos(normal.Dot(new Vector2(0, -1))));
            if (Input.IsActionPressed("left"))
            {
                slopeAngle = -slopeAngle;
            }
            if (slopeAngle < MAX_SLOPE_ANGLE && slopeAngle > -MAX_SLOPE_ANGLE)
            {
                jumpHeight = 300;
            }
            else if (!Input.IsActionPressed("left") && !Input.IsActionPressed("right"))
            {
                jumpHeight = 300;
            }
            else if (slopeAngle > MAX_SLOPE_ANGLE)
            {
                jumpHeight = 150;
                if (Input.IsActionPressed("run"))
                {
                    jumpHeight = 75;
                }
            }
            else if (slopeAngle < -MAX_SLOPE_ANGLE)
            {
                jumpHeight = 150;
                if (Input.IsActionPressed("run"))
                {
                    jumpHeight = 75;
                }
            }
        }

    }
}
