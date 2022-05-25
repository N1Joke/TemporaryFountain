using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshCoin;
    [SerializeField] private TextMeshProUGUI _textMeshTimeLeft;
    [SerializeField] private Slider _slider;

    private int _coinCount;

    public static UIManager Instance;

    private void Start()
    {
        if (!Instance)
            Instance = this;
    }

    public void AddCoin(int value = 1)
    {
        _coinCount += value;
        _textMeshCoin.text = "Money collected = $" + _coinCount;
    }

    public void UpdateTimeValue(float leftTime, float maxTime)
    {
        int minute = Mathf.FloorToInt(leftTime / 60f);
        int sec =(int) (leftTime - minute * 60f);

        _textMeshTimeLeft.text = "Time left = " + minute.ToString() + ":" + sec + "s";

        _slider.value = Mathf.InverseLerp(0f, maxTime, leftTime);
    }
}
