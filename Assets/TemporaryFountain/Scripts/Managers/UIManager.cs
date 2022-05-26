using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshCoin;
    [SerializeField] private TextMeshProUGUI _textMeshTimeLeft;
    [SerializeField] private Slider _slider;    
    [SerializeField] private Button _startButton;

    private int _coinCount;

    public static UIManager Instance;
    public Intro intro;
    public UnityAction OnStartLevel;

    private void Awake()
    {
        if (!Instance)
            Instance = this;

        intro.gameObject.SetActive(true);
    }

    private void Start()
    {
        
        _startButton.onClick.AddListener(()=> { OnStartLevel?.Invoke(); });    
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
