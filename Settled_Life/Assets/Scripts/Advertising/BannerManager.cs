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
        string adId = "Tan�ms�z";
#endif
        this.bannerView = new BannerView(adId, AdSize.Banner, AdPosition.Bottom);

        //Reklam y�klenince ne olacak
        bannerView.OnAdLoaded += BannerViewOnLoaded;
        //Reklam�n y�klenmesinde sorun varsa ne olacak
        bannerView.OnAdFailedToLoad += BannerViewFailedToLoad;
        //Reklam a��ld� sonra ne olacak
        bannerView.OnAdOpening += BannerAdOpened;
        //Reklam kapat�ld� sonra ne olacak
        bannerView.OnAdClosed += BannerAdClosed;

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

    private void BannerAdClosed(object sender, System.EventArgs e)
    {
        //Reklam kapat�ld�� Sonra ->>
    }

    private void BannerAdOpened(object sender, System.EventArgs e)
    {
        //Reklam a��ld�. Sonra ->>
    }

    private void BannerViewFailedToLoad(object sender, AdFailedToLoadEventArgs e)
    {
        //Reklam y�klemesi ba�ar�s�z oldu. Sonra ->>
    }

    private void BannerViewOnLoaded(object sender, System.EventArgs e)
    {
        //Reklam y�klendi. Sonra ->>
    }
}
