using UnityEngine;

public class JumpView
{
    private readonly Animator animator;
    private readonly Rigidbody2D rigidbody;
    public JumpView(Animator animator, Rigidbody2D rigidbody)
    {
        this.animator = animator;
        this.rigidbody = rigidbody;
    }
    public void SetVerticalSpeed(float transitionTime)
    {
        animator.SetFloat(HashedAnimations.VerticalSpeed, rigidbody.velocity.y);
    }

    public void IsGrounded(bool isGrounded)
    {
        animator.SetBool(HashedAnimations.IsGrounded, isGrounded);
    }
}
