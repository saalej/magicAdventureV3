using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.SceneManagement;
using Fusion.Sockets;
using System;
using UnityEngine.Events;

public class StartNetworkGame : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField] private NetworkRunner _networkRunner;
    [SerializeField] private string _roomName;
    [SerializeField] private string _sceneName;
    [SerializeField] private UnityEvent<NetworkRunner, PlayerRef> OnPlayerJoinedEvent;

    [SerializeField] private GameObject panelServer;
    [SerializeField] private GameObject panelPlay;

    SpawnPlayer _spawnPlayer;

    async void StartNewGame(GameMode mode)
    {
        //var gameArgs = new StartGameArgs();
        //gameArgs.GameMode = mode;

        await _networkRunner.StartGame(new StartGameArgs
        { 
            GameMode = mode,//Mode de juego
            SessionName = _roomName,
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });

        _networkRunner.SetActiveScene(_sceneName);

    }

    public void StartGameAsHost()
    {
        StartNewGame(GameMode.AutoHostOrClient);
    }

    public void StartGameAsClient()
    {
        StartNewGame(GameMode.Client);
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        if (runner.IsServer)
        {
            Debug.Log("I'm Host");
            OnPlayerJoinedEvent?.Invoke(runner, player);
        }   else
        {
            Debug.Log("I'm Client");
            OnPlayerJoinedEvent?.Invoke(runner, player);
        }
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        if(_spawnPlayer._networkObjects.TryGetValue(player, out NetworkObject networkObject))
        {
            runner.Despawn(networkObject);
            _spawnPlayer._networkObjects.Remove(player);
        }
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        NetworkInputData data = new NetworkInputData();
        
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        data.Direction.x += xInput;


        if (yInput > 0)
        {
            data.isJumpButtonPressed = true;
        }

        input.Set(data);
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        
    }
}
