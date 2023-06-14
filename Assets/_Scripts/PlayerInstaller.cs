using UnityEditor.Rendering;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player player;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float speed;

    [Header("Jumping")]
    [SerializeField] private int maxJumpsAmount;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallGravityScale;
    [SerializeField] private float maxJumpTime;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundLayer;

    public override void InstallBindings()
    {
        BindMovementInput();
        BindMovementModel();
        BindMovementView();

        BindJumpInput();
        BindJumpModel();
        BindJumpView();
        BindGroundChecker();
    }

    private void BindGroundChecker()
    {
        Container.Bind<GroundChecker>()
            .FromInstance(new GroundChecker(groundChecker, groundLayer))
            .AsSingle();
    }

    private void BindJumpInput()
    {
        Container.Bind<IInput<bool>>()
            .To<JumpInput>()
            .AsSingle();
    }
    private void BindJumpModel() 
    {
        Container.Bind<IJumpModel>()
            .To<PhysicsJump>()
            .AsSingle().WithArguments(maxJumpsAmount,jumpForce,fallGravityScale,maxJumpTime);
    }

    private void BindJumpView()
    {
        Container.Bind<IJumpView>()
            .To<JumpView>()
            .AsSingle().WithArguments(anim,rb);
    }
    private void BindMovementInput()
    {
        Container
            .Bind<IInput<float>>()
            .To<KeyboardMovementInput>()
            .AsSingle();
    }
    private void BindMovementModel()
    {
        Container
            .Bind<float>()
            .WithId("speed")
            .FromInstance(speed);

        Container
            .Bind<Rigidbody2D>()
            .WithId("playerRigidbody")
            .FromInstance(rb)
            .AsSingle();

        Container
            .Bind<IMovementModel>()
            .To<PlayerMovement>()
            .AsSingle();
    }

    private void BindMovementView()
    {
        Container.
            Bind<Animator>()
            .FromInstance(anim)
            .AsSingle();

        Container
            .Bind<IMovementView>()
            .To<PlayerMovementView>()
            .AsSingle();
    }
}