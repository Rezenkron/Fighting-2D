using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
                        [Header("General")]
    [SerializeField] private Animator       animator;
    [SerializeField] private Rigidbody2D    rigidbody2d;
    [SerializeField] private float          animationTransitionSpeed;
                        [Header("Walking")]
    [SerializeField] private float          speed;
                        [Header("Jumping")]
    [SerializeField] private float          jumpForce;
    [SerializeField] private AnimationCurve jumpCurve;

    private MoveInputListener               moveInputListener;
    private HorizontalWalking               horizontalWalking;
    private HorizontalWalkingView           walkingView;
    private FaceFlipper                     faceFlipper;
    private JumpLogic                       jump;

    private void Awake()
    {
        moveInputListener                   = new MoveInputListener();
        horizontalWalking                   = new HorizontalWalking(rigidbody2d);
        walkingView                         = new HorizontalWalkingView(animator);
        faceFlipper                         = new FaceFlipper(gameObject);
        jump                                = new JumpLogic(rigidbody2d, jumpCurve, this);
    }

    private void Update()
    {
        walkingView.SetHorizontalMoveAnimation(moveInputListener.HorizontalInput, animationTransitionSpeed);
        faceFlipper.Flip(moveInputListener.HorizontalInput);
        jump.DoJump(moveInputListener.JumpInput, jumpForce);
        
    }

    private void FixedUpdate()
    {
        horizontalWalking.Move(moveInputListener.HorizontalInput, speed);
    }
}
