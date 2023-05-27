using UnityEngine;

public class HorizontalWalking
{
    private readonly Rigidbody2D rigidbody;
    public HorizontalWalking(Rigidbody2D rigidbody)
    {
        this.rigidbody = rigidbody;
    }
    public void Move(float horizontalInput, float speed)
    {
        rigidbody.velocity = new Vector2(speed * horizontalInput * Time.fixedDeltaTime, rigidbody.velocity.y);
    }
}
