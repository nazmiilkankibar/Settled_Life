using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EvilGate : MonoBehaviour
{
    public Transform spawnPos;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    public int spawnTime;
    public InterstitalAdManager interstitialAd;
    private void Start()
    {
        StartCoroutine(SpawnTimer());
    }
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < Random.Range(1,3); i++)
        {
            GameObject obj = Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPos.position, Quaternion.identity);
            obj.GetComponent<EnemyController>().evilGate = transform.GetComponent<EvilGate>();
            spawnedEnemies.Add(obj);
        }
        yield return new WaitForSeconds(.2f);
    }
    IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            StartCoroutine(SpawnEnemies());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interstitialAd.goToWar = true;
            interstitialAd.ShowInterstitalAd();
            //SceneManager.LoadScene(Random.Range(1,SceneManager.sceneCountInBuildSettings));
        }
    }
}
