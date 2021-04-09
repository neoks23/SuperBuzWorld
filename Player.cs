using Godot;
using System;
public class Player : KinematicBody2D
{
    [Export] public int speed = 200;
    [Export] public int jumpHeight = 400;

    public Vector2 velocity;
    private AnimationTree animtree;
    private AnimationNodeStateMachinePlayback stateMachine;
    private bool isRunning;
    private float gravity = 10f;

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
        animtree.GetRootMotionTransform();
        stateMachine = (AnimationNodeStateMachinePlayback)animtree.Get("parameters/playback");
        isRunning = false;
    }
    public void Idling()
    {
        isRunning = false;
        stateMachine.Travel("Idle");
    }
    public void RunningMan()
    {
        isRunning = true;
        stateMachine.Travel("Run");
    }
    public void GetInput()
    {
        if (Input.IsActionPressed("right"))
        {
            velocity.x = speed;
            if (!isRunning)
            {
                stateMachine.Travel("Transition");
            }
        }
        else if (Input.IsActionPressed("left"))
        {
            velocity.x = -speed;
            if (!isRunning)
            {
                stateMachine.Travel("Transition");
            }
        }
        else
        {
            velocity.x = 0;
        }
        if (Input.IsActionJustPressed("up") && IsOnFloor())
        {
            velocity.y += -jumpHeight;
            jumping = true;
        }
        if(jumping && velocity.y >= 0)
        {
            jumping = false;
        }

        snapVector = new Vector2(0, SNAP_LENGTH);

        if (jumping)
        {
            snapVector = new Vector2();
        }

        if (Input.IsActionJustReleased("right"))
        {
            stateMachine.Travel("ReverseR");
        }
        if (Input.IsActionJustReleased("left"))
        {
            stateMachine.Travel("ReverseL");
        }
    }

    public override void _PhysicsProcess(float delta)
    {
        Slope();
        GetInput();
        velocity.y += gravity;

        animtree.Set("parameters/Transition/blend_position", velocity.x);
        animtree.Set("parameters/Run/blend_position", velocity.x);

        velocity = MoveAndSlideWithSnap(velocity * delta * 60, snapVector, FLOOR_NORMAL,true,4,FLOOR_MAX_ANGLE);
    }
    public void Slope()
    {
        
        var slides = GetSlideCount();
        for (int i = 0; i < slides; i++)
        {
            var normal = GetSlideCollision(i).Normal;
            var slopeAngle = Mathf.Rad2Deg(Mathf.Acos(normal.Dot(new Vector2(0, -1))));
            Console.WriteLine(slopeAngle);
            if (Input.IsActionPressed("left"))
            {
                slopeAngle = -slopeAngle;
            }
            if (slopeAngle < MAX_SLOPE_ANGLE && slopeAngle > -MAX_SLOPE_ANGLE)
            {
                jumpHeight = 300;
            }
            else if (!Input.IsActionPressed("left")  && !Input.IsActionPressed("right"))
            {
                jumpHeight = 300;
            }
            else if(slopeAngle > MAX_SLOPE_ANGLE)
            {
                jumpHeight = 150;
            }
            else if(slopeAngle < -MAX_SLOPE_ANGLE)
            {
                jumpHeight = 150;
            }
        }

    }
}
