using UnityEditor.Rendering;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player player;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private WeaponHolder weaponHolder;

    [Header("Movement")]
    [SerializeField] private float speed;

    [Header("Jumping")]
    [SerializeField] private int maxJumpsAmount;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallGravityScale;
    [SerializeField] private float maxJumpTime;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundLayer;

    [Header("Combat")]
    [SerializeField] private CombatAnimationEvents combatAnimationEvents;
    [SerializeField] private KeyCode attackKey;
    [SerializeField] private KeyCode buffKey;


    public override void InstallBindings()
    {
        BindPlayer();
        BindMovementInput();
        BindMovementModel();
        BindMovementView();

        BindJumpInput();
        BindJumpModel();
        BindJumpView();
        BindGroundChecker();
    }

    private void BindPlayer()
    {
        Container.Bind<Player>().FromInstance(player);
        Container.Bind<IInputListener<bool>>().To<InputKeyListener>().AsSingle();
        Container.Bind<CombatAnimation>().AsSingle().WithArguments(anim, attackKey, buffKey);
        Container.Bind<CombatAnimationEvents>().FromInstance(combatAnimationEvents).AsSingle();
        Container.Bind<WeaponHolder>().FromInstance(weaponHolder).AsSingle();
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
            .AsSingle().WithArguments(rb, maxJumpsAmount,jumpForce,fallGravityScale,maxJumpTime);
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
            .Bind<IMovementModel>()
            .To<PlayerMovement>()
            .AsSingle().WithArguments(speed,rb);
    }

    private void BindMovementView()
    {
        Container
            .Bind<IMovementView>()
            .To<PlayerMovementView>()
            .AsSingle().WithArguments(rb,anim);
    }
}