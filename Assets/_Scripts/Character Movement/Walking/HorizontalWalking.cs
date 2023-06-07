using UnityEngine;

public class HorizontalWalking
{
    private readonly Rigidbody2D rigidbody;
    public Vector3 Direction { get; private set; }
    public HorizontalWalking(Rigidbody2D rigidbody)
    {
        this.rigidbody = rigidbody;
    }
    public void Move(float horizontalInput, float speed)
    {
        Direction = new Vector3(horizontalInput * speed * Time.deltaTime, rigidbody.velocity.y);
        rigidbody.velocity = Direction;
    }
}
