using UnityEngine;

public class JumpView : IJumpView
{
    private readonly Animator animator;
    private readonly Rigidbody2D rigidbody;
    private readonly GroundChecker groundChecker;
    public JumpView(Animator animator, Rigidbody2D rigidbody, GroundChecker groundChecker)
    {
        this.animator = animator;
        this.rigidbody = rigidbody;
        this.groundChecker = groundChecker;
    }
    public void SetVerticalSpeed()
    {
        animator.SetFloat(HashedAnimations.VerticalSpeed, rigidbody.velocity.y);
    }

    public void IsGrounded()
    {
        animator.SetBool(HashedAnimations.IsGrounded, groundChecker.IsGrounded());
    }
}
