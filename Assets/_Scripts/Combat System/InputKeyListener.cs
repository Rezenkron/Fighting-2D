using UnityEngine;

public class InputKeyListener : IInputListener<bool>
{
    private readonly KeyCode key;

    public InputKeyListener(KeyCode key)
    {
        this.key = key;
    }

    public bool OnButtonDown()
    {
        return Input.GetKeyDown(key);
    }

    public bool OnButtonUp()
    {
        return Input.GetKeyUp(key);
    }
}
