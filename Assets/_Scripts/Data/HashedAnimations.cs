using UnityEngine;

public static class HashedAnimations
{
    //ANIMATIONS
    public static int Idle { get; private set; } = Animator.StringToHash("Idle");

    //PARAMETERS
    public static int HorizontalSpeed { get; private set; } = Animator.StringToHash("HorizontalSpeed");
    public static int VerticalSpeed { get; private set; } = Animator.StringToHash("VerticalSpeed");
    public static int IsGrounded { get; private set; } = Animator.StringToHash("IsGrounded");
    public static int IsAttacking { get; private set; } = Animator.StringToHash("IsAttacking");
    public static int AttackAction { get; private set; } = Animator.StringToHash("AttackAction");
        // ATTACK ACTIONS
        public static int Swipe { get; private set; } = 0;
        public static int Stab { get; private set; } = 1;
        public static int Point { get; private set; } = 2;
        public static int Summon { get; private set; } = 3;

}
