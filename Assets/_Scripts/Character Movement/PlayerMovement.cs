using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
                            [Space(5)]
                        [Header("General")]
                            [Space(5)]
    [SerializeField] private Animator       animator;
    [SerializeField] private Rigidbody2D    rigidbody2d;
    [SerializeField] private float          animationTransitionSpeed;
                            [Space(5)]
                        [Header("Walking")]
                            [Space(5)]
    [SerializeField] private float          speed;
                            [Space(5)]
                        [Header("Jumping")]
                            [Space(5)]
    [SerializeField] private float          jumpForce;
    [SerializeField] private uint           jumpsAmount;
    [SerializeField] private Transform      groundChecker;
    [SerializeField] private float          fallGravityScale;
    [SerializeField] private LayerMask      groundLayer;

    private MoveInputListener               input;
    private HorizontalWalking               horizontalWalking;
    private HorizontalWalkingView           walkingView;
    private FaceFlipper                     faceFlipper;
    private PhysicsJump                     jump;
    private JumpView                        jumpView;

    private void Awake()
    {
        input                               = new MoveInputListener();
        horizontalWalking                   = new HorizontalWalking(rigidbody2d);
        walkingView                         = new HorizontalWalkingView(animator);
        faceFlipper                         = new FaceFlipper(gameObject);
        jumpView                            = new JumpView(animator, rigidbody2d);
        jump                                = new PhysicsJump(rigidbody2d, groundChecker, groundLayer,jumpsAmount, jumpView);
        
    }

    private void Update()
    {
        walkingView.SetMoveAnimation(input.HorizontalInput, animationTransitionSpeed);
        faceFlipper.Flip(input.HorizontalInput);
        jump.DoJump(input.JumpInputDown, jumpForce,fallGravityScale,0.3f);
    }

    private void FixedUpdate()
    {
        horizontalWalking.Move(input.HorizontalInput, speed);
    }
}
