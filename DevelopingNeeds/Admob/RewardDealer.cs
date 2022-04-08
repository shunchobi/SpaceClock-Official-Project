using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RewardDealer : MonoBehaviour
{

    bool count = false;
    float passedTime = 0;

    int noAdsTime = 21600; //６時間 （１時間＝３６００秒）

    AdAnounceMover adAnounceMover;
    OrientationMonitor orientationMonitor;
    SettingMenuOpener settingMenuOpener;

    public Text Video_Land_T;
    public Text Video_Port_T;


    // Start is called before the first frame update
    void Start()
    {
        adAnounceMover = GameObject.Find("AdAnounce").GetComponent<AdAnounceMover>();
        orientationMonitor = GameObject.Find("Main Camera").GetComponent<OrientationMonitor>();
        settingMenuOpener = GameObject.Find("SettingOpener").GetComponent<SettingMenuOpener>();
        Debug.Log("RewardDealer is called");
    }

    // Update is called once per frame
    void Update()
    {
        //if(count == true)
        //{
        //    passedTime += Time.deltaTime;


        //    //設定画面のVideoボタン上に残りの広告非表示時間を表示する。
        //    if (settingMenuOpener.isOpen == true)
        //    {
        //        if (orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeLeft ||
        //            orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeRight)
        //        {
        //            Video_Land_T.text = GetRemingNoAdsTimeAsStr(passedTime);
        //        }
        //        else if (orientationMonitor.PrevOrientation == DeviceOrientation.Portrait)
        //        {
        //            Video_Port_T.text = GetRemingNoAdsTimeAsStr(passedTime);
        //        }
        //    }

            

        //    if (passedTime >= noAdsTime)
        //    {
        //        passedTime = 0;
        //        Cash.preference.passedTimeWithNoAds = 0;
        //        Cash.preference.rewardWatched = false;
        //        SaveManager.SaveFile_Preference();

        //        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        //        {
        //            Cash.adsController.RequestBanner();
        //            Cash.adsController.RequestiIterstitial();
        //            Cash.adsController.RequestReward();
        //        }

        //        if (Application.systemLanguage == SystemLanguage.Japanese)
        //        {
        //            Video_Port_T.text = "6時間広告フリー！";
        //            Video_Land_T.text = "6時間広告フリー！";
        //        }
        //        else
        //        {
        //            Video_Port_T.text = "No Ads for 6hours!";
        //            Video_Land_T.text = "No Ads for 6hours!";
        //        }

        //        count = false;
        //    }
        //}
    }




    /// <summary>
    /// ///////////////////////////////////////////////////////////////////
    /// </summary>
    public void CancelRewardAdsTest()
    {
        count = false;

        passedTime = 0;
        Cash.preference.passedTimeWithNoAds = 0;
        Cash.preference.rewardWatched = false;
        SaveManager.SaveFile_Preference();

        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            Video_Port_T.text = "6時間広告フリー！";
            Video_Land_T.text = "6時間広告フリー！";
        }
        else
        {
            Video_Port_T.text = "No Ads for 6hours!";
            Video_Land_T.text = "No Ads for 6hours!";
        }

        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            Cash.adsController.RequestBanner();
            Cash.adsController.RequestiIterstitial();
            Cash.adsController.RequestReward();
        }
    }




    public void CancelPurchaseTest()
    {
        Cash.preference.hasPurchased = false;
        SaveManager.SaveFile_Preference();
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////
    /// </summary>







    public void CancelRewardAds()
    {
        count = false;

        passedTime = 0;
        Cash.preference.passedTimeWithNoAds = 0;
        Cash.preference.rewardWatched = false;
        SaveManager.SaveFile_Preference();

        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            Video_Port_T.text = "6時間広告フリー！";
            Video_Land_T.text = "6時間広告フリー！";
        }
        else
        {
            Video_Port_T.text = "No Ads for 6hours!";
            Video_Land_T.text = "No Ads for 6hours!";
        }

    }


    string GetRemingNoAdsTimeAsStr(float passedTime)
    {
        string remingTimeStr;

        int passedTimeInt = (int)Mathf.Floor(passedTime);

        int remaingTimeInt = noAdsTime - passedTimeInt;
        int remingHour = (int)Mathf.Floor(remaingTimeInt / 3600);
        int remingMin = remaingTimeInt / 60 - remingHour * 60;
        int remingSec = remaingTimeInt - remingHour * 3600 - remingMin * 60;

        string remingHourStr = remingHour.ToString();
        string remingMinStr = remingMin.ToString();
        string remingSecStr = remingSec.ToString();

        if (remingMin < 10)
            remingMinStr = "0"+ remingMin.ToString();
        if (remingSec < 10)
            remingSecStr = "0" + remingSec.ToString();

        if (Application.systemLanguage == SystemLanguage.Japanese)
            remingTimeStr = "残り" + remingHourStr + ":" + remingMinStr + ":" + remingSecStr;
        else
            remingTimeStr = remingHourStr + ":" + remingMinStr + ":" + remingSecStr + " Left";

        return remingTimeStr;
    }





    private void OnApplicationQuit()
    {
        SaveDayTimeInfo();
        Debug.Log("終了");
    }


    private void OnApplicationPause(bool pause)
    {
        //一時停止時（バックグラウンド時）
        if (pause)
        {
            SaveDayTimeInfo();
            Debug.Log("一時停止");
        }
        //再開時
        else
        {
            InitiForRewardAd();
            Debug.Log("一時停止から再開");
        }

    }



    void SaveDayTimeInfo()
    {
        Cash.preference.leftAppDay = DateTime.Now.Day;
        Cash.preference.leftAppMonth = DateTime.Now.Month;
        Cash.preference.LeftAppMonthDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); // その月の日数

        int hour = DateTime.Now.Hour;
        int min = DateTime.Now.Minute;
        int sec = DateTime.Now.Second;
        Cash.preference.leftAppTime = GetTimeAsSecond(hour, min, sec);

        count = false;
        Cash.preference.passedTimeWithNoAds = (int)passedTime; //小数点以下切り捨て

        SaveManager.SaveFile_Preference();
    }


    //24時間 = 86400秒
    //アプリを終了し、再起動後に１日以上空いたら広告は表示
    //アプリを終了し、再起動後に日を跨いでいたら経過時間＋再起動時の時刻（秒）
    //日を跨いでいなかったら、経過時間＋（アプリ起動時の時刻（秒）ー アプリ終了時の時刻（秒））

    /// <summary>
    /// アプリ起動時に動画広告によって広告非表示中期間ならその処理をする
    /// </summary>
    public void InitiForRewardAd()
    {
        if (Cash.preference.hasPurchased == true)
            return;

        if(Cash.preference.rewardWatched == true)
        {
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;

            int nowMonth = DateTime.Now.Month;
            int nowDAY = DateTime.Now.Day;
            int nowTime = GetTimeAsSecond(hour, min, sec);

            int num = 86400 - Cash.preference.leftAppTime; //アプリ終了時から同日の０時までの時間数
            int passedTimeWithNoAds = Cash.preference.passedTimeWithNoAds + num + nowTime;


            //アプリを終了した日が月末の場合
            if (Cash.preference.leftAppDay == Cash.preference.LeftAppMonthDays
                && nowDAY != Cash.preference.leftAppDay
                && nowMonth != Cash.preference.leftAppMonth)
            {
                Debug.Log("今日は月末です。");

                if (nowDAY >= 2)
                {
                    Debug.Log("今日は月末です。 22222");
                    Cash.preference.rewardWatched = false;
                    passedTime = 0;
                    SaveManager.SaveFile_Preference();
                    return;
                }
                else if (nowDAY == 1)
                {
                    Debug.Log("今日は月末です。 111111");
                    if (passedTimeWithNoAds >= noAdsTime)
                    {
                        Cash.preference.rewardWatched = false;
                        passedTime = 0;
                        SaveManager.SaveFile_Preference();
                        return;
                    }
                    else
                    {
                        Cash.preference.passedTimeWithNoAds = passedTimeWithNoAds;
                    }
                }
            }

            //アプリ再起動が１日以上空いた場合
            else if (nowDAY > Cash.preference.leftAppDay + 1)
            {
                Cash.preference.rewardWatched = false;
                passedTime = 0;
                SaveManager.SaveFile_Preference();
                return;
            }

            //アプリ再起動が日を跨いだ場合
            else if (nowDAY == Cash.preference.leftAppDay + 1)
            {
                if (passedTimeWithNoAds >= noAdsTime)
                {
                    Cash.preference.rewardWatched = false;
                    passedTime = 0;
                    SaveManager.SaveFile_Preference();
                    return;
                }
                else
                {
                    Cash.preference.passedTimeWithNoAds = passedTimeWithNoAds;
                }
            }

            //アプリ再起動が終了日と同日の場合
            //経過時間＋（アプリ起動時の時刻（秒）ー アプリ終了時の時刻（秒））
            else if (nowDAY == Cash.preference.leftAppDay)
            {
                Debug.Log("今日のさっきアプリを終了しました。");
                int passedTimeWhileOuttaGame = nowTime - Cash.preference.leftAppTime;
                int passedTimeSinceRewarded = Cash.preference.passedTimeWithNoAds + passedTimeWhileOuttaGame;

                if(passedTimeSinceRewarded > noAdsTime)
                {
                    Cash.preference.rewardWatched = false;
                    passedTime = 0;
                    SaveManager.SaveFile_Preference();
                    return;
                }
                else
                {
                    Cash.preference.passedTimeWithNoAds = passedTimeSinceRewarded;
                }
            }


            //広告非表示期間中の場合
            if(Cash.preference.rewardWatched == true)
            {
                Debug.Log("Cash.preference.rewardWatched == true です。");
                passedTime = Cash.preference.passedTimeWithNoAds;
                count = true;
            }
        }
    }



    //Cash.preference.rewardWatched = false; の場合に広告を表示する処理



    /// <summary>
    /// 動画広告を見て報酬を受け取る時にされる処理
    /// </summary>
    public void AffectNoAdsByReward()
    {
        Cash.preference.rewardWatched = true;
        SaveManager.SaveFile_Preference();

        Cash.adsController.bannerView.Destroy();

        if(adAnounceMover.move == true)
            adAnounceMover.RemoveAdAnounce();

        count = true;
    }




    int GetTimeAsSecond(int hour, int min, int sec)
    {
        int secSecond = sec;
        int minSecond = min * 60;
        int hourSecond = hour * 60 * 60;

        int secondNowTime = secSecond + minSecond + hourSecond;

        return secondNowTime;
    }

}
