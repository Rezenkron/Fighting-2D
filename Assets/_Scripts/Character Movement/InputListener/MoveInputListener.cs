using UnityEngine;

public class MoveInputListener
{
    public float HorizontalInput { get { return Input.GetAxisRaw("Horizontal"); } }
    public float JumpInput { get { return Input.GetAxisRaw("Jump"); } }
}
