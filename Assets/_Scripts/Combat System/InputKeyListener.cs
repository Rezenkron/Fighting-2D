using UnityEngine;

public class InputKeyListener : IInputListener<bool>
{
    public bool OnButtonDown(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }

    public bool OnButtonUp(KeyCode key)
    {
        return Input.GetKeyUp(key);
    }
}
