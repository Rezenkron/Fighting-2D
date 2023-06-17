using UnityEngine;

public interface IInputListener<T>
{
    public T OnButtonDown(KeyCode key);
    public T OnButtonUp(KeyCode key);
}