using UnityEngine;

public class PhysicsJump
{
    private readonly Rigidbody2D rigidbody;
    private readonly Transform groundChecker;
    private readonly LayerMask groundLayer;
    private readonly float maxJumpsAmount;
    private float jumpsAmount;

    private readonly float gravityScale;

    private float buttonPressedTime;


    private bool isJumping;

    private JumpView jumpView;

    public PhysicsJump(Rigidbody2D rigidbody, Transform groundChecker, LayerMask groundLayer, float jumpsAmount, JumpView jumpView)
    {
        this.rigidbody = rigidbody;
        this.groundChecker = groundChecker;
        this.groundLayer = groundLayer;
        this.jumpsAmount = jumpsAmount;
        this.maxJumpsAmount = jumpsAmount;

        gravityScale = rigidbody.gravityScale;

        this.jumpView = jumpView;
    }

    public void DoJump(bool input,float jumpForce, float fallGravityScale, float maxButtonPressedTime)
    {
        jumpView.SetVerticalSpeed(0.3f);
        if (!isJumping)
        {
            bool isGrounded = Physics2D.OverlapCircle(groundChecker.position, 0.1f, groundLayer);
            jumpView.IsGrounded(isGrounded);
            if (isGrounded) { jumpsAmount = maxJumpsAmount; }
        }
        if (input && jumpsAmount-- > 0)
        {
            rigidbody.gravityScale = gravityScale;
            isJumping = true;
            buttonPressedTime = 0;
        }
        if(isJumping)
        {
            buttonPressedTime += Time.deltaTime;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            if(buttonPressedTime > maxButtonPressedTime || Input.GetButtonUp("Jump"))
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
