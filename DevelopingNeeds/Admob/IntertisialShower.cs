using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IntertisialShower : MonoBehaviour
{

    AdAnounceMover adAnounceMover;
    Text adText;
    Text countText;

    string adIsComing = "広告が出るよ";
    string second = "秒";

    float intervalMin = 480; //10分間隔で全画面広告を表示

    float passedTime = 0; //経過時間
    float countdownTime = 38;

    bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        adAnounceMover = GameObject.Find("AdAnounce").GetComponent<AdAnounceMover>();
        adText = GameObject.Find("Text1").GetComponent<Text>();
        countText = GameObject.Find("Text2").GetComponent<Text>();

        if (Application.systemLanguage != SystemLanguage.Japanese)
        {
            adIsComing = "Ad is coming";
            second = "sec";
        }
    }



    public void DeleteText()
    {
        adText.text = "";
        countText.text = "";
    }


    public void ShowText()
    {
        adText.text = adIsComing;
        countText.text = Mathf.Floor(countdownTime) + second;
    }





    // Update is called once per frame
    void Update()
    {
        //if (Cash.preference.hasPurchased == true || Cash.preference.rewardWatched == true)
        //    return;

        //passedTime += Time.deltaTime;

        //if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork
        //    || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        //{
        //    if (Cash.adsController.interstitial != null && Cash.adsController.interstitial.IsLoaded())
        //    {
        //        if (passedTime >= intervalMin - countdownTime && start == false)
        //        {
        //            adAnounceMover.MoveAdAnounce();
        //            start = true;
        //        }


        //        if (start == true)
        //        {
        //            countText.text = Mathf.Floor(countdownTime) + second;
        //            countdownTime -= Time.deltaTime;
        //        }


        //        if (start == true && countdownTime <= 0)
        //        {
        //            Cash.adsController.ShowInterstitiaAd();
        //            adAnounceMover.ChangeSpriteAtFinishedAd();
        //            countdownTime = 30;
        //            passedTime = 0;
        //            start = false;
        //        }
        //    }
        //}
    }





}
