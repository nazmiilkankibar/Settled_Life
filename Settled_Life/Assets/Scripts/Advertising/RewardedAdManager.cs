using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class RewardedAdManager : MonoBehaviour
{
    private RewardedAd rewarded;
    public string androidRewardedAd;
    public string iphoneRewardedAd;
    string adId;

    //Rewarded Button
    public GameObject rewardedAdButton;
    private float timer = 5;
    private float animationTriggerTimer;
    private void Start()
    {
        RequestRewardedAd();
    }
    private void Update()
    {
        ShowRewardedAdButton();
    }
    private void RequestRewardedAd()
    {
#if UNITY_ANDROID
        adId = androidRewardedAd;
#elif UNITY_IPHONE
        string adId = iphoneRewardedAd;
#else
        string adId = "Tanýmsýz";
#endif
        this.rewarded = new RewardedAd(adId);

        //Reklam yüklenince ne olacak
        rewarded.OnAdLoaded += RewardedViewOnLoaded;
        //Reklamýn yüklenmesinde sorun varsa ne olacak
        rewarded.OnAdFailedToLoad += RewardedViewFailedToLoad;
        //Reklam açýldý sonra ne olacak
        rewarded.OnAdOpening += RewardedAdOpened;
        //Reklam gösterilemedi
        rewarded.OnAdFailedToShow += RewardedFailedToShow;
        //Reklam ödülü verildi
        rewarded.OnUserEarnedReward += EarnedReward;
        //Reklam kapatýldý sonra ne olacak
        rewarded.OnAdClosed += RewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rewarded.LoadAd(request);
    }

    private void EarnedReward(object sender, Reward e)
    {
        PlayerPrefs.SetInt("GoldCount", PlayerPrefs.GetInt("GoldCount") +  100);
        timer = 5;
        RequestRewardedAd();
    }

    private void RewardedFailedToShow(object sender, AdErrorEventArgs e)
    {
        
    }

    public void RewardedViewOnLoaded(object sender, EventArgs e)
    {

    }
    public void RewardedViewFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {

    }
    public void RewardedAdOpened(object sender, EventArgs e)
    {
        timer = 5;
        rewardedAdButton.SetActive(false);
    }
    public void RewardedAdClosed(object sender, EventArgs e)
    {
        RequestRewardedAd();
    }
    public void ShowRewardedAd()
    {
        if (rewarded.IsLoaded())
        {
            rewarded.Show();
        }
    }
    public void ShowRewardedAdButton()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            rewardedAdButton.SetActive(true);
            if (animationTriggerTimer < 0)
            {
                rewardedAdButton.GetComponent<Animator>().SetTrigger("Trigger");
                animationTriggerTimer = 5;
            }
            else
            {
                animationTriggerTimer -= Time.deltaTime;
            }
        }
    }
}
