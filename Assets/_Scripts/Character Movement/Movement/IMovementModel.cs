using UnityEngine;

public interface IMovementModel
{
    Vector2 MoveDirection { get; }
    void Update();
}
