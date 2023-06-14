using UnityEngine;
using Zenject;

public class GroundChecker
{
    private readonly Transform groundChecker;
    private readonly LayerMask groundLayer;
    public GroundChecker([Inject(Id = "groundChecker")]Transform groundChecker, [Inject(Id = "groundLayer")] LayerMask groundLayer)
    {
        this.groundChecker = groundChecker;
        this.groundLayer = groundLayer;
    }
    public bool IsGrounded()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundChecker.position, 0.1f, groundLayer);
        return isGrounded;
    }
}
