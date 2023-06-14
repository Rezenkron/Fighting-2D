using UnityEngine;
using Zenject;

public class PlayerMovementView : IMovementView
{
    private readonly Rigidbody2D rb;
    private readonly Animator anim;

    private readonly IMovementModel model;
    private readonly FaceFlipper flipper;

    public PlayerMovementView(IMovementModel model,[Inject(Id = "playerRigidbody")] Rigidbody2D rb, Animator anim)
    {
        this.model = model;
        this.rb = rb;
        this.anim = anim;
        flipper = new FaceFlipper(rb.gameObject);
    }

    public void Update()
    {
        rb.velocity = new Vector2(model.MoveDirection.x, rb.velocity.y);
        anim.SetFloat(HashedAnimations.HorizontalSpeed, Mathf.Abs(rb.velocity.x));
        flipper.Flip(Mathf.Clamp(model.MoveDirection.x, -1,1));

    }
}

