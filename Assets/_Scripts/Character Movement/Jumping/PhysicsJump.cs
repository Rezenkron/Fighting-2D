using UnityEngine;
using Zenject;

public class PhysicsJump : IJumpModel
{
    private readonly Rigidbody2D rigidbody;
    private readonly int maxJumpsAmount;
    private readonly float jumpForce;
    private readonly float fallGravityScale;
    private readonly float maxJumpTime;
    private readonly float gravityScale;

    private int jumpsAmount;
    private float buttonPressedTime;
    private bool isJumping;

    private readonly IInput<bool> input;
    private readonly IJumpView jumpView;
    private readonly GroundChecker groundChecker;

    public PhysicsJump([Inject(Id = "playerRigidbody")]Rigidbody2D rigidbody, IJumpView jumpView, GroundChecker groundChecker, IInput<bool> input, int jumpsAmount, float jumpForce, float fallGravityScale, float maxJumpTime)
    {
        this.rigidbody = rigidbody;
        this.jumpsAmount = jumpsAmount;
        this.jumpView = jumpView;
        this.groundChecker = groundChecker;
        this.input = input;
        this.jumpsAmount = jumpsAmount;
        this.maxJumpsAmount = jumpsAmount;
        this.jumpForce = jumpForce;
        this.fallGravityScale = fallGravityScale;
        this.maxJumpTime = maxJumpTime;

        gravityScale = rigidbody.gravityScale;
    }

    public void DoJump()
    {
        input.ReadInput();
        jumpView.SetVerticalSpeed();
        if (!isJumping)
        {
            bool isGrounded = groundChecker.IsGrounded();
            jumpView.IsGrounded();
            if (isGrounded) { jumpsAmount = maxJumpsAmount; }
        }
        if (input.GetInput() && jumpsAmount-- > 0)
        {
            rigidbody.gravityScale = gravityScale;
            isJumping = true;
            buttonPressedTime = 0;
        }
        if(isJumping)
        {
            buttonPressedTime += Time.deltaTime;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            if(buttonPressedTime > maxJumpTime || Input.GetButtonUp("Jump"))
            {
                isJumping = false;
            }
        }
        if(rigidbody.velocity.y < 0)
        {
            rigidbody.gravityScale = fallGravityScale;
        }
    }
}

