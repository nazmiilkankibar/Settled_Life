using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
public class InterstitalAdManager : MonoBehaviour
{
    private InterstitialAd interstitialAd;
    public string androidInterstitialAd;
    public string iphoneInterstitialAd;
    string adId;

    public float setTimer;
    private float timer;

    public bool againWar;
    public bool goToWar;
    private void Start()
    {
        RequestInterstitial();
        timer = setTimer;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                ShowInterstitalAd();
                timer = setTimer;
            }
        }
    }
    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        adId = androidInterstitialAd;
#elif UNITY_IPHONE
        string adId = iphoneInterstitialAd;
#else
        string adId = "Tanýmsýz";
#endif
        interstitialAd = new InterstitialAd(adId);

        interstitialAd.OnAdLoaded += InterstitialAdLoaded;
        interstitialAd.OnAdFailedToLoad += InterstitialAdFailedToLoad;
        interstitialAd.OnAdOpening += InterstitialAdOpened;
        interstitialAd.OnAdClosed += InterstitialAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(request);
    }

    private void InterstitialAdClosed(object sender, System.EventArgs e)
    {
        //Reklam kapatýldý. Sonra ->>
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            RequestInterstitial();
        }
        else
        {
            if (againWar)
            {
                SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings));
                againWar = false;
            }
            else if (goToWar)
            {
                SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings));
                goToWar = false;
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void InterstitialAdOpened(object sender, System.EventArgs e)
    {
        //Reklam açýldý. Sonra ->>
    }

    private void InterstitialAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        //Reklam yüklenemedi. Sonra ->>
        RequestInterstitial();
    }

    private void InterstitialAdLoaded(object sender, System.EventArgs e)
    {
        //Reklam yüklendi. Sonra ->>
    }
    public void AgainButton()
    {

    }
    public void ShowInterstitalAd()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        else
        {
            RequestInterstitial();
        }
    }
}
