using Fusion;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
    public Vector3 Direction;
    public Vector3 DirectionPlatform;
    public bool isJumpButtonPressed;
    public bool isPlatformMove;
}
