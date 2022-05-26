using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerControls _player;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Clock _clockPrefab;
    [SerializeField] private float _coinSpawnDelay;
    [SerializeField] private float _clockSpawnDelay;
    [SerializeField] private float _borderRadius = 6.06f ;
    [SerializeField] private float _gameTime;
    [SerializeField] private Transform _gameBoard;

    private float _timeSinceLastSpawnCoin;
    private float _timeSinceLastSpawnClock;
    private float _currentGameTime;
    private bool _gameInAction = false;

    public float BorderRadius => _borderRadius;
    public static GameManager Instance;

    private void Start()
    {
        _gameInAction = false;
        UIManager.Instance.intro.ShowStartIntro();
        UIManager.Instance.OnStartLevel += StartGame;
    }

    private void StartGame()
    {
        UIManager.Instance.OnStartLevel -= StartGame;

        UIManager.Instance.intro.HideStartIntro();

        _player.gameObject.SetActive(true);

        _currentGameTime = _gameTime;

        if (!Instance)
            Instance = this;

        _timeSinceLastSpawnCoin = _coinSpawnDelay;

        _gameInAction = true;
    }

    private void Update()
    {
        if (_gameInAction)
            UpdateTimers();
    }

    private void UpdateTimers()
    {
        _currentGameTime -= Time.deltaTime;

        UIManager.Instance.UpdateTimeValue(_currentGameTime, _gameTime);

        if (_currentGameTime <= 0)
        {
            LoadScene();
        }

        if (_timeSinceLastSpawnCoin >= _coinSpawnDelay)
        {
            SpawnCollectable(_coinPrefab);
            _timeSinceLastSpawnCoin = 0f;
        }

        if (_timeSinceLastSpawnClock >= _clockSpawnDelay)
        {
            SpawnCollectable(_clockPrefab);
            _timeSinceLastSpawnClock = 0f;
        }

        _timeSinceLastSpawnCoin += Time.deltaTime;
        _timeSinceLastSpawnClock += Time.deltaTime;
    }

    public void AddTimeToGame(float value)
    {
        _currentGameTime += value;
    }

    private void SpawnCollectable(Collectable collectable)
    {
        var collectableObject = Instantiate(collectable.gameObject, _gameBoard);

        float border = _borderRadius - 1f;
        float randomX = Random.Range(-border, border);
        float randomY = Random.Range(-border, border);

        Vector2 pos = Vector2.ClampMagnitude(new Vector2(randomX, randomY), _borderRadius);

        collectableObject.transform.position = pos;
        collectableObject.GetComponent<Collectable>().PopUpCollectable();        
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
