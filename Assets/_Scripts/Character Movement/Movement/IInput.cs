using System;
using Unity.Mathematics;

public interface IInput<T> where T : struct
{
    void ReadInput();
    T GetInput();
}
