using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkSpawner : MonoBehaviour
{
    #region ATTRIBUTS

    [SerializeField] private float _spawnTimer = 1;
    [SerializeField] private float _currentTimer = 0;

    [SerializeField] private GameObject[] _thinkSpawn = null;
    [SerializeField] private Transform _thinkContainer = null;

    [SerializeField] private float _minSpawnDistance = 0;
    [SerializeField] private float _maxSpawnDistance = 0;
    [SerializeField] private Vector2 _spawnPosition = Vector2.zero;


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
        // Dessiner des gizmos pour représenter les rayons de spawn dans l'éditeur Unity
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _minSpawnDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _maxSpawnDistance);
    }

    #endregion MONO

    #region METHODES

    public void NewSapwn()
    {
        int randomSpawn = Random.Range(0, _thinkSpawn.Length);

        Instantiate(_thinkSpawn[randomSpawn], _spawnPosition, _thinkContainer.rotation, _thinkContainer);
    }

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

    public void SpawnPosition()
    {
        //float randomDistance = Random.Range(_minSpawnDistance, _maxSpawnDistance);
        
        Vector2 randomDirection = Random.insideUnitCircle * (_maxSpawnDistance - _minSpawnDistance);
        randomDirection = randomDirection + randomDirection.normalized * _minSpawnDistance;

        _spawnPosition = randomDirection;
        
        //transform.position + new Vector3(randomDirection.x, 0, randomDirection.y) * randomDistance
        //float radius = Random.Range(_minSpawnDistance, _maxSpawnDistance);
        //Vector2 randomSpawnLocation = Random.insideUnitCircle * radius ;
    }

    #endregion METHODES
}
