using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class BannerManager : MonoBehaviour
{
    //Banner ca-app-pub-3940256099942544/6300978111
    //Interstitial ca-app-pub-3940256099942544/1033173712
    //Interstitial Video  ca-app-pub-3940256099942544/8691691433
    //Rewarded Video  ca-app-pub-3940256099942544/5224354917
    //Native Advanced ca-app-pub-3940256099942544/2247696110
    //Native Advanced Video ca-app-pub-3940256099942544/1044960115

    private BannerView bannerView;
    public string androidBannerID;
    public string iphoneBannerID;
    string adId;
    private void Start()
    {
        RequestBanner();
    }
    private void RequestBanner()
    {
#if UNITY_ANDROID
        adId = androidBannerID;
#elif UNITY_IPHONE
        string adId = bannerAdvertisingIDIphone;
#else
        string adId = "Tanýmsýz";
#endif
        this.bannerView = new BannerView(adId, AdSize.Banner, AdPosition.Bottom);

        //Reklam yüklenince ne olacak
        bannerView.OnAdLoaded += BannerViewOnLoaded;
        //Reklamýn yüklenmesinde sorun varsa ne olacak
        bannerView.OnAdFailedToLoad += BannerViewFailedToLoad;
        //Reklam açýldý sonra ne olacak
        bannerView.OnAdOpening += BannerAdOpened;
        //Reklam kapatýldý sonra ne olacak
        bannerView.OnAdClosed += BannerAdClosed;

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

    private void BannerAdClosed(object sender, System.EventArgs e)
    {
        //Reklam kapatýldýç Sonra ->>
    }

    private void BannerAdOpened(object sender, System.EventArgs e)
    {
        //Reklam açýldý. Sonra ->>
    }

    private void BannerViewFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        //Reklam yüklemesi baþarýsýz oldu. Sonra ->>
    }

    private void BannerViewOnLoaded(object sender, System.EventArgs e)
    {
        //Reklam yüklendi. Sonra ->>
    }
}
