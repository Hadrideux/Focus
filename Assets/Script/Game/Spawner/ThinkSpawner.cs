using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkSpawner : MonoBehaviour
{
    #region ATTRIBUTS

    [Header("Spawn Time")]
    [SerializeField] private float _spawnDelay = 1;
    [SerializeField] private float _timeStamp = 0;

    [Header("Spawn Object")]
    [SerializeField] private AThinkingBubble[] _thinkSpawn = null;
    [SerializeField] private Transform _thinkContainer = null;

    [Header("Spawn Location")]
    [SerializeField] private float _minSpawnDistance = 0;
    [SerializeField] private float _maxSpawnDistance = 0;

    private Vector2 _spawnPosition = Vector2.zero;

    [Header("Init")]
    [SerializeField] Transform _focusPoint = null;

    #endregion ATTRIBUTS

    #region PROPERTIES

    public float SpawnDistanceMin => _minSpawnDistance;
    public float SpawnDistanceMax => _maxSpawnDistance;

    #endregion PROPERTIES

    #region MONO

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentGamePhase == EGamePhase.POMODORO)
        {
            SpawnTimer();
        }
    }

    #endregion MONO

    #region METHODES

    //Incrémenté le compteur de spawn
    public void SpawnTimer()
    {
        _timeStamp += Time.deltaTime;

        if (_timeStamp > _spawnDelay)
        {
            SpawnPosition();
            NewSapwn();
            _timeStamp = 0;
        }
    }

    //Spawn une nouvelle bulle de penser
    public void NewSapwn()
    {
        int randomSpawn = Random.Range(0, _thinkSpawn.Length);

        AThinkingBubble newThink = Instantiate(_thinkSpawn[randomSpawn], _spawnPosition, Quaternion.identity, _thinkContainer);
        newThink.Init(_focusPoint);
    }

    //Choisie un point de spawn dans la zone de spawn autorisé
    public void SpawnPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle * (_maxSpawnDistance - _minSpawnDistance);
        randomDirection = randomDirection + randomDirection.normalized * _minSpawnDistance;

        _spawnPosition = randomDirection;
    }

    #endregion METHODES
}
