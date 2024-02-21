using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkSpawner : MonoBehaviour
{
    #region ATTRIBUTS

    [Header("Spawn Time")]
    [SerializeField] private float _spawnTimer = 1;
    [SerializeField] private float _currentTimer = 0;

    [Header("Spawn Object")]
    [SerializeField] private AThinkingBubble[] _thinkSpawn = null;
    [SerializeField] private Transform _thinkContainer = null;

    [Header("Spawn Location")]
    [SerializeField] private float _minSpawnDistance = 0;
    [SerializeField] private float _maxSpawnDistance = 0;

    private Vector2 _spawnPosition = Vector2.zero;

    [Header("Init")]
    [SerializeField] GameObject _focusPoint = null;

    #endregion ATTRIBUTS

    #region MONO

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void OnDrawGizmosSelected()
    {
        //Dessiner des gizmos représentant les zones de spawn
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _minSpawnDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _maxSpawnDistance);
    }

    #endregion MONO

    #region METHODES

    //Spawn une nouvelle bulle de penser
    public void NewSapwn()
    {
        int randomSpawn = Random.Range(0, _thinkSpawn.Length);

        AThinkingBubble newThink = Instantiate(_thinkSpawn[randomSpawn], _spawnPosition, Quaternion.identity, _thinkContainer);
        newThink.Init(_focusPoint);
    }

    //Incrémenté le compteur de spawn
    public void UpdateTimer()
    {
        _currentTimer += Time.deltaTime;

        if (_currentTimer > _spawnTimer)
        {
            SpawnPosition();
            NewSapwn();
            _currentTimer = 0;
        }
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
