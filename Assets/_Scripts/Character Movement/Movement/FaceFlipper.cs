using UnityEngine;

public class FaceFlipper
{
    private readonly GameObject character;
    public FaceFlipper(GameObject character)
    {
        this.character = character;
    }

    public void Flip(float horizontalInput)
    {
        if (horizontalInput != 0)
        {
            character.transform.localScale = new Vector3(horizontalInput, character.transform.localScale.y, character.transform.localScale.z);
        }
    }
}

