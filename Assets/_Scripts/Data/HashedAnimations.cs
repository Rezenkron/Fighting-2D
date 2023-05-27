using UnityEngine;

public static class HashedAnimations
{
    //ANIMATIONS
    public static int Idle { get; private set; } = Animator.StringToHash("Idle");

    //PARAMETERS
    public static int HorizontalSpeed { get; private set; } = Animator.StringToHash("HorizontalSpeed");
    public static int VerticalSpeed { get; private set; } = Animator.StringToHash("VerticalSpeed");

}
