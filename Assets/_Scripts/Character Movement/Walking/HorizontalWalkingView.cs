using UnityEngine;

public class HorizontalWalkingView
{
    private readonly Animator animator;
    public HorizontalWalkingView(Animator animator)
    {
        this.animator = animator;
    }
    public void SetMoveAnimation(float horizontalInput, float transitionTime)
    {
        animator.SetFloat(HashedAnimations.HorizontalSpeed, Mathf.Abs(horizontalInput),transitionTime, Time.deltaTime);
    }
}
