using Unity.Entities;

public struct PlayerInput : IComponentData
{
    public float Horizontal;
    public float Vertical;
    public float Jump;
}

public struct Block : IComponentData { }
public struct Fly : IComponentData { }

public struct Fall : IComponentData {
    public float FallSpeed;
    public float FallTime;
    public float Acceleration;
}

public struct Gravity : IComponentData {
    public float FallSpeed;
    public float FallTime;
}
public struct Acceleration : IComponentData
{
    public float Horizontal;
    public float Vertical;
}
