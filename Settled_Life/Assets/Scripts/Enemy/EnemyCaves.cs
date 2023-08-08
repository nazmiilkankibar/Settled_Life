using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyCaves : MonoBehaviour
{
    public Transform spawnPos;
    private GameController gameController;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    private int spawnCount;
    public int minSpawnCount;
    public int maxSpawnCount;
    private void Start()
    {
        spawnCount = Random.Range(minSpawnCount, maxSpawnCount);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Invoke("StartSpawn", gameController.spawnTime);
    }
    private void StartSpawn()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject obj = Instantiate(enemies[Random.Range(0, enemies.Count)].gameObject, spawnPos.position, spawnPos.rotation);
            gameController.spawnedEnemies.Add(obj);
            yield return new WaitForSeconds(.25f);
        }
    }
}
