using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseEntity
{
    public static PlayerManager Instance { get; private set; }
    public PlayerMovement movement {  get; private set; }

    public int currentLevel = 1;
    public float currentExp = 0f;
    public float maxExp = 10f;

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
    }

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            AddExp(5);
        }else if (Input.GetKeyDown(KeyCode.G))
        {
            AddExp(15);
        }
    }

    public void AddExp(float val)
    {
        if(currentExp + val >= maxExp)
        {
            currentExp += val;
            LevelUp();
        }else if (currentExp + val < maxExp)
        {
            currentExp += val;
        }

        UIManager.Instance.OnExpChange(currentExp);
    }

    private void LevelUp()
    {
        currentLevel += 1;
        currentExp = 0;
        maxExp *= 2;
        UIManager.Instance.OnLevelUp(maxExp, currentLevel);
    }
}
