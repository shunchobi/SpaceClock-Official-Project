using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.Advertisements;

public class AdsController : MonoBehaviour
{

    // #if UNITY_ANDROID
    // string bannerAdUnitId = "ca-app-pub-8709392240032722/2787916304";
    // string iterstitialAdUnitId = "ca-app-pub-8709392240032722/1785483914";
#if UNITY_IPHONE
    string bannerAdUnitId = "ca-app-pub-8709392240032722/7901259951";//本番"ca-app-pub-8709392240032722/7901259951";  テストca-app-pub-3940256099942544/2934735716
    string iterstitialAdUnitId = "ca-app-pub-8709392240032722/6396606590";//"ca-app-pub-8709392240032722/6396606590";  ca-app-pub-3940256099942544/4411468910
    string rewardAdUnitId = "ca-app-pub-8709392240032722/9656214810";//"ca-app-pub-8709392240032722/9656214810";  ca-app-pub-3940256099942544/1712485313
    string appId = "ca-app-pub-8709392240032722~3223648341";
#else
    string bannerAdUnitId = "unexpected_platform";
    string iterstitialAdUnitId = "unexpected_platform";
#endif

    public BannerView bannerView;
    public InterstitialAd interstitial;
    public RewardedAd reward;


    OrientationMonitor orientationMonitor;


    bool wasOnNet = false;
    bool isDestroyedBanner = false;



    //float targetHeightA = 1920;
    //float targetWidthA = 1080;

    //float targetHeightB = 1334;
    //float targetWidthB = 750;

    //float targetHeightC = 1136;
    //float targetWidthC = 640;

    //bool hasSafearea = true;





    public void InitiAdmobAds()
    {
        //if (Application.internetReachability == NetworkReachability.NotReachable)
        //    return;

        //orientationMonitor = GameObject.Find("Main Camera").GetComponent<OrientationMonitor>();

        ////hasSafearea = GetHasSafearea();

        //MobileAds.Initialize(initStatus => { });
        ////MobileAds.Initialize(appId);

        //wasOnNet = true;
        //RequestBanner();
        //RequestiIterstitial();
        //RequestReward();
    }


    private void Update()
    {
        //if (Cash.preference.hasPurchased == true || Cash.preference.rewardWatched == true)
        //    return;

        //if (wasOnNet == true && Application.internetReachability == NetworkReachability.NotReachable)
        //{
        //    bannerView.Destroy();
        //    interstitial.Destroy();
        //    reward = null;
        //    isDestroyedBanner = true;
        //    wasOnNet = false;
        //    return;
        //}

        //if (isDestroyedBanner == true)
        //{
        //    if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        //    {
        //        RequestBanner();
        //        RequestiIterstitial();
        //        RequestReward();
        //        wasOnNet = true;
        //        isDestroyedBanner = false;
        //    }
        //}
    }



    ////private bool GetHasSafearea()
    ////{
    //    //bool hasSafearea = true;
    //
    //
    //    //if (orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeLeft ||
    //        //orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeRight)
    //    //{
    //        //if (Screen.height == targetWidthA && Screen.width == targetHeightA ||
    //            //Screen.height == targetWidthB && Screen.width == targetHeightB ||
    //            //Screen.height == targetWidthC && Screen.width == targetHeightC)
    //            //hasSafearea = false;
    //    //}
    //    //else if (orientationMonitor.PrevOrientation == DeviceOrientation.Portrait)
    //
    //        //if (Screen.height == targetHeightA && Screen.width == targetWidthA ||
    //            //Screen.height == targetHeightB && Screen.width == targetWidthB ||
    //            //Screen.height == targetHeightC && Screen.width == targetWidthC)
    //            //hasSafearea = false;
    //
    //
    //    //return hasSafearea;
    ////}



    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// バナー広告
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void RequestBanner()
    {
        //    //if (bannerView != null)
        //    //    bannerView.Destroy();

        //    ////MobileAds.Initialize(bannerAdUnitId);
        //    //MobileAds.Initialize(initStatus => { });
        //    //bannerView = new BannerView(bannerAdUnitId, AdSize.SmartBanner, AdPosition.Top);
        //    //AdRequest request = new AdRequest.Builder().AddTestDevice(SystemInfo.deviceUniqueIdentifier).Build(); //AddTestDevice("d774780f5c8bf3c81230b0d3e9d12a2d").AddTestDevice("358239057028468").AddTestDevice("44fdaf30776c6c02ed9a31e8d9d640bd").Build();
        //    //bannerView.LoadAd(request);
        //    if (bannerView != null)
        //        bannerView.Destroy();

        //    AdSize adaptiveSize;

        //    if (orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeLeft ||
        //        orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeRight)
        //    {
        //        adaptiveSize = AdSize.GetLandscapeAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        //        Debug.Log("横画面でバナーのロードをリクエスト");
        //        bannerView = new BannerView(bannerAdUnitId, adaptiveSize, AdPosition.Top);
        //        //bannerView = new BannerView(bannerAdUnitId, AdSize.SmartBanner, AdPosition.Top);

        //    }

        //    else if (orientationMonitor.PrevOrientation == DeviceOrientation.Portrait)
        //    {
        //        adaptiveSize = AdSize.GetPortraitAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        //        Debug.Log("縦画面でバナーのロードをリクエスト");
        //        bannerView = new BannerView(bannerAdUnitId, adaptiveSize, AdPosition.Top);
        //    }
        //    else
        //    {
        //        adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        //        Debug.Log("横画面,縦画面以外でバナーのロードをリクエスト");
        //        bannerView = new BannerView(bannerAdUnitId, adaptiveSize, AdPosition.Top);
        //    }

        //    bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        //    bannerView.OnAdLoaded += (handler, EventArgs) =>
        //    {
        //        Debug.Log("バナーを読み込みました。");
        //    };


        //    AdRequest request = new AdRequest.Builder().Build(); //AddTestDevice(SystemInfo.deviceUniqueIdentifier)

        //    if (Cash.preference.hasPurchased == true || Cash.preference.rewardWatched == true)
        //        return;

        //    bannerView.LoadAd(request);
    }


    public void HideBanner()
    {
        //if (bannerView != null)
        //    bannerView.Hide();
    }

    public void ShowBanner()
    {
        //if (Cash.preference.hasPurchased == true || Cash.preference.rewardWatched == true)
        //    return;

        //if (bannerView != null)
        //    bannerView.Show();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////


    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //Debug.Log("バナーの読み込みに失敗しました。");

        //MonoBehaviour.print(
        //        "HandleFailedToReceiveAd event received with message: " + args.Message);
    }


    ////public void HandleOnAdLoaded(object sender, EventArgs args)
    ////{
    ////    MonoBehaviour.print("HandleAdLoaded event received");
    ////}




    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// リワード広告
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void ShowReward()
    {
//#if UNITY_EDITOR
//        GameObject.Find("Ads").GetComponent<RewardDealer>().AffectNoAdsByReward();
//        return;
//#endif

//        if (Application.internetReachability == NetworkReachability.NotReachable)
//        {
//            if (reward != null)
//                reward = null;
//            return;

//        }

//        if (reward != null && reward.IsLoaded())
//        {
//#if UNITY_EDITOR
//#else
//        if (Cash.preference.hasPurchased == true || Cash.preference.rewardWatched == true)
//            return;
//        reward.Show();
//#endif
//        }
//        else
//        {
//            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
//            {
//                if (reward != null)
//                    reward = null;
//                RequestReward();
//            }
//        }
    }



    public void RequestReward()
    {
        //Debug.Log("リワードをリクエスト");

        //reward = new RewardedAd(rewardAdUnitId);
        //AdRequest request = new AdRequest.Builder().Build();//.AddTestDevice(SystemInfo.deviceUniqueIdentifier)

        //reward.OnAdFailedToLoad += (handler, EventArgs) =>
        //{
        //    if (reward != null)
        //        reward = null;

        //    Debug.Log("リワードのロードに失敗しました");
        //    //if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        //    //    RequestReward();
        //};

        //reward.OnAdClosed += (handler, EventArgs) =>
        //{
        //    if (Application.internetReachability == NetworkReachability.NotReachable)
        //    {
        //        if (reward != null)
        //            reward = null;
        //        return;
        //    }

        //    if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        //    {
        //        if (reward != null)
        //            reward = null;
        //        RequestReward();
        //    }
        //};

        //reward.OnAdLoaded += (handler, EventArgs) =>
        //{
        //    Debug.Log("リワードのロードに成功しました");

        //};


        //    //報酬受け取り時の処理
        //    reward.OnUserEarnedReward += (handler, EventArgs) =>
        //{
        //    GameObject.Find("Ads").GetComponent<RewardDealer>().AffectNoAdsByReward();
        //    RequestReward();
        //};

        ////広告を表示したとき
        //reward.OnAdOpening += (handler, EventArgs) =>
        //{
        //};


        //reward.OnAdFailedToShow += (handler, EventArgs) =>
        //{
        //    if (Application.internetReachability == NetworkReachability.NotReachable)
        //    {
        //        if (reward != null)
        //            reward = null;
        //        return;
        //    }

        //    if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        //    {
        //        if (reward != null)
        //            reward = null;
        //        RequestReward();
        //    }
        //};


        //reward.LoadAd(request);
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////




    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// 全画面広告
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void ShowInterstitiaAd()
    {
        
//        if (Application.internetReachability == NetworkReachability.NotReachable)
//        {
//            if (interstitial != null)
//                interstitial.Destroy();
//            return;
//        }

//        if (interstitial != null && interstitial.IsLoaded())
//        {
//#if UNITY_EDITOR
//#else
//            if (Cash.preference.hasPurchased == true || Cash.preference.rewardWatched == true)
//                return;
//            interstitial.Show();
//#endif
//        }
//        else
//        {
//            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
//            {
//                if (interstitial != null)
//                    interstitial.Destroy();
//                RequestiIterstitial();
//            }
//        }
    }


    public void RequestiIterstitial()
    {
        //Debug.Log("全画面広告をリクエスト");

        //interstitial = new InterstitialAd(iterstitialAdUnitId);
        //AdRequest request = new AdRequest.Builder().Build();

        ////interstitial.OnAdFailedToLoad += (handler, EventArgs) =>
        ////{
        ////    if (interstitial != null)
        ////        interstitial.Destroy();

        ////    if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        ////        RequestiIterstitial();
        ////};

        //interstitial.OnAdClosed += (handler, EventArgs) =>
        //{
        //    if (Application.internetReachability == NetworkReachability.NotReachable)
        //    {
        //        if (interstitial != null)
        //            interstitial.Destroy();
        //        return;
        //    }

        //    if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        //    {
        //        if (interstitial != null)
        //            interstitial.Destroy();
        //        RequestiIterstitial();
        //    }
        //};

        //interstitial.OnAdFailedToLoad += (handler, EventArgs) =>
        //{
        //    Debug.Log("全画面のロードに失敗しました");
        //};

        //interstitial.OnAdLoaded += (handler, EventArgs) =>
        //{
        //    Debug.Log("全画面のロードに成功しました");
        //};



        ////広告をタップされた時に実行される
        ////本アプリに戻ったときは、interstitial.OnAdClosedが実行され、広告が閉じる
        //interstitial.OnAdLeavingApplication += (handler, EventArgs) =>
        //{
        //};

        ////広告を表示したとき
        //interstitial.OnAdOpening += (handler, EventArgs) =>
        //{
        //};


        //interstitial.LoadAd(request);
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////

}
