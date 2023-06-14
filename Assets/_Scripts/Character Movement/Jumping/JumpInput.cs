using UnityEngine;

public class JumpInput : IInput<bool>
{
    private bool jump;
    public void ReadInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        else if(jump = Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
    }

    public bool GetInput()
    {
        return jump;
    }

}
