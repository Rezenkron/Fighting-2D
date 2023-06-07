using UnityEngine;

public class MoveInputListener
{
    public float HorizontalInput { get { return Input.GetAxisRaw("Horizontal"); } }
    public bool JumpInputDown { get { return Input.GetButtonDown("Jump"); } }
    public bool JumpInputUp { get { return Input.GetButtonUp("Jump"); } }
}
