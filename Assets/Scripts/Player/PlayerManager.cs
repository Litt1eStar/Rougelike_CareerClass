using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public PlayerMovement movement;
    public PlayerBaseClass currentPlayer;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        currentPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBaseClass>();
        movement = GetComponent<PlayerMovement>();
    }
}
