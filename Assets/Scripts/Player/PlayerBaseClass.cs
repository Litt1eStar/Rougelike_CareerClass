using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseClass : MonoBehaviour
{
    public PlayerData playerData { get; private set; }
    //Player SO

    private void Start()
    {
        playerData = GetComponent<PlayerData>();
    }
}
