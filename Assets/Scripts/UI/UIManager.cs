using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Slider lvlSlider;
    [SerializeField] private TextMeshProUGUI lvlTxt;
    private void Awake()
    {
        if (Instance != null && Instance != this)
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
        lvlSlider.minValue = 0f;
        lvlSlider.maxValue = PlayerManager.Instance.maxExp;
    }

    public void OnExpChange(float currentExp)
    {
        lvlSlider.value = currentExp;
    }

    public void OnLevelUp(float newMaxExp, int currentLevel)
    {
        lvlSlider.maxValue = newMaxExp;
        lvlSlider.value = 0;
        lvlTxt.text = "Level " + currentLevel.ToString();
    }
}
