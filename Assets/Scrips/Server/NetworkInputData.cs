using Fusion;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
    public Vector3 Direction;
    public bool isJumpButtonPressed;
    public bool isGround;
}
