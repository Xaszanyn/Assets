using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{

    // public override void OnClientConnect(NetworkConnection conn)
    // {
    //     base.OnClientConnect(conn);

    //     Debug.Log("CONNECTED TO A SERVER");
    // }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // base.OnServerAddPlayer(conn);

        // Debug.Log("ADDED PLAYER (S)");
        // Debug.Log("PLAYER COUNT: " + numPlayers);
        // // Debug.Log($"There are {numPlayers} players.");

        // // başkası bağlanıp player oluşunca da bu çalışır.


        MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();

        player.SetDisplayName($"Player {numPlayers}");
    }

}
