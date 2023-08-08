using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameController : MonoBehaviour
{
    public List<GameObject> spawnedEnemies = new List<GameObject>();
    public bool isGameEnded;
    public bool endGameTrigger;
    public GameObject confetti;
    public Transform playerWaitPos;
    private Camera cam;
    private PlayerController player;
    private IEnumerator confettiSpawner;
    public float spawnTime;
    public TextMeshProUGUI remainingTime;
    public GameObject UI;
    public GameObject victoryScreen;
    public InterstitalAdManager interstitialAd;
    private void Start()
    {
        confettiSpawner = Confetti();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        cam = Camera.main;
    }
    private void Update()
    {
        remainingTime.text = spawnTime.ToString("0");
        if (spawnTime <= 0)
        {
            UI.SetActive(false);
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
        if (isGameEnded)
        {
            if (!endGameTrigger)
            {
                cam.GetComponent<CameraFollower>().closeUp = true;
                player.isWin = true;
                player.transform.position = playerWaitPos.position;
                endGameTrigger = true;
                victoryScreen.SetActive(true);
                Invoke("EndGame", 4f);
                EndGame();
            }
        }        
    }
    public void EndGame()
    {
        StartCoroutine(confettiSpawner);
    }
    private IEnumerator Confetti()
    {
        while (true)
        {
            Instantiate(confetti, transform.position + new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(0, 7f), Random.Range(.5f, .5f)), Quaternion.identity);
            yield return new WaitForSeconds(.2f);
        }
    }
    public void AgainButton()
    {
        interstitialAd.againWar = true;
        interstitialAd.ShowInterstitalAd();
    }
    public void GoHomeButton()
    {
        interstitialAd.ShowInterstitalAd();
    }
}
