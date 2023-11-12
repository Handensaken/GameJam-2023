using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //Max coming at ya with suggestion of solution
    //Denna array innehåller olika prefabs för våra enemies, med matchande sprite, animation och animationscontroller i övrigt är de identiska. 
    //Vill vi arbeta utifrån en mer kraftfull prefab behöver vi arrays till animationskontroller och sprites, och då måste vi programmatiskt assigna sprite
    //Jag lämnar det valet till er
    [SerializeField] private GameObject[] enemyPrefabs;
    //Denna var det enda jag lade till här uppe

    //[SerializeField] private List<GameObject> enemyPrefabs = new List<GameObject>(); //5 levels of difficulty
    [SerializeField] private GameObject motherPumpkin;
    [Space(8)]
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private List<float> spawnTimes = new List<float>();
    [SerializeField] private List<int> enemyMaxRanks = new List<int>();
    //[SerializeField] private List<enemyScareCrowStats> enemyRankStats = new List<enemyScareCrowStats>();
    [SerializeField] private float difficultyUpTime = 120f;

    private List<Transform> _remainingSpawnPoints = new List<Transform>();
    private float _spawnTime = 20f;
    private bool _readyToSpawn = true;
    private int _enemyMaxRank = 1;
    private int _level = 0;
    private bool _atMaxDifficulty = false;
    private bool _readyToGitGudder = true;

    void Start()
    {
        _remainingSpawnPoints = spawnPoints;

        if (spawnTimes.Count > 0)
        {
            _spawnTime = spawnTimes[0];
        }

        if (enemyMaxRanks.Count > 0)
        {
            _enemyMaxRank = enemyMaxRanks[0];
        }
    }

    void Update()
    {
        if (_readyToSpawn)
        {
            StartCoroutine(SpawnAndTimer());
        }

        if (_readyToGitGudder && !_atMaxDifficulty)
        {
            StartCoroutine(DifficultyAndTimer());
        }
    }

    private void SpawnEnemy()
    {
        int point = Random.Range(0, _remainingSpawnPoints.Count);
        int enemyRank = Random.Range(0, _enemyMaxRank);
        GameObject enemy = enemyPrefabs[enemyRank];

        //  Max suggestion 
        //  GameObject enemy = enemyPrefabs[enemyRank];


        enemy.GetComponent<EnemyScareCrow>().target = motherPumpkin;
        //enemy.GetComponent<EnemyScareCrow>().AssignRankValues(enemyRankStats[enemyRank].pumpkinCraving, enemyRankStats[enemyRank].maxHp, enemyRankStats[enemyRank].speed, enemyRankStats[enemyRank].hungerDamage);

        Instantiate(enemy, _remainingSpawnPoints[point].position, Quaternion.identity);

        /*_remainingSpawnPoints.RemoveAt(point);

        if (_remainingSpawnPoints.Count <= 1)
        {
            _remainingSpawnPoints = spawnPoints;
        }*/
    }

    private IEnumerator SpawnAndTimer()
    {
        _readyToSpawn = false;
        yield return new WaitForSeconds(_spawnTime);
        SpawnEnemy();
        _readyToSpawn = true;
    }

    private void UpdateDifficulty()
    {
        _level++;

        _spawnTime = spawnTimes[_level];
        _enemyMaxRank = enemyMaxRanks[_level];

        if (_level >= spawnTimes.Count || _level >= enemyMaxRanks.Count)
        {
            _atMaxDifficulty = true;
        }
    }

    private IEnumerator DifficultyAndTimer()
    {
        _readyToGitGudder = false;
        yield return new WaitForSeconds(difficultyUpTime);
        UpdateDifficulty();
        _readyToGitGudder = true;
    }
}
