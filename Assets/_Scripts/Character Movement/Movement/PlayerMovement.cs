using UnityEngine;
using Zenject;

public class PlayerMovement : IMovementModel
{
    private readonly float speed;
    private readonly Rigidbody2D rb;

    private readonly IInput<float> input;

    private float horizontal;

    public Vector2 MoveDirection { get; private set; }

    public PlayerMovement(IInput<float> input,[Inject(Id = "speed")] float speed, [Inject(Id = "playerRigidbody")]Rigidbody2D rb)
    {
        this.input = input;
        this.speed = speed;
        this.rb = rb;
    }

    public void Update()
    {
        input.ReadInput();
        horizontal = input.GetInput();
        SetMoveDirection();
    }

    private void SetMoveDirection()
    {
        MoveDirection = new Vector2(horizontal * speed, rb.velocity.y);
    }
}
