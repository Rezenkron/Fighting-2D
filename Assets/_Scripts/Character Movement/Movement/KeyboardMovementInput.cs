using UnityEngine;

public class KeyboardMovementInput : IInput<float>
{
    private float horizontal;
    public void ReadInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }
    public float GetInput()
    {
        return horizontal;
    }
}
