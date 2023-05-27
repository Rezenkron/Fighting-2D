using UnityEngine;

public class FaceFlipper
{
    private readonly GameObject player;
    public FaceFlipper(GameObject player)
    {
        this.player = player;
    }

    public void Flip(float horizontalInput)
    {
        if(horizontalInput != 0)
        {
            player.transform.localScale = new Vector3(horizontalInput, player.transform.localScale.y, player.transform.localScale.z);
        }
    }
}
