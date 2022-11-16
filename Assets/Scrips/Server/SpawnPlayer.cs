using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] public Dictionary<PlayerRef, NetworkObject> _networkObjects = new Dictionary< PlayerRef, NetworkObject>();
    public void SpawnedPlayer(NetworkRunner runner, PlayerRef playerRef)
    {
        Debug.Log("Spawn player");
        NetworkObject _object = runner.Spawn(_playerPrefab, new Vector3(0, 5, 0), Quaternion.identity, playerRef);
        _networkObjects.Add(playerRef, _object);
        Debug.Log($"{_networkObjects.Count} Objects in simulation");
    }
}
