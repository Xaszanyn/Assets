using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar] [SerializeField] private string displayName = "Missing Name";

    [Server] public void SetDisplayName(string newDisplayName) {
        displayName = newDisplayName;
    }
}
