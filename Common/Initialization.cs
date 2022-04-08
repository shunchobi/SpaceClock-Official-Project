using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Initialization : MonoBehaviour {


    


	// Use this for initialization
	void Awake () {
        Cash.Init();
        Cash.orientationMonitor.InitilaizeOrient();
        Cash.rewardDealer.InitiForRewardAd();
        Cash.adsController.InitiAdmobAds();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //Firebase.Analytics.FirebaseAnalytics.LogEvent("test");


        //ローカライズ
        L.Text.Init(Application.systemLanguage);

        switch (Cash.preference.howNumDisplay)
        {
            case 1:
                GameObject.Find("12HourPort").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("24HourPort").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("24HourNo0Port").transform.GetChild(0).gameObject.SetActive(false);
                
                GameObject.Find("12HourLand").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("24HourLand").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("24HourNo0Land").transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 2:
                GameObject.Find("12HourPort").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("24HourPort").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("24HourNo0Port").transform.GetChild(0).gameObject.SetActive(false);

                GameObject.Find("12HourLand").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("24HourLand").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("24HourNo0Land").transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 3:
                GameObject.Find("12HourPort").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("24HourPort").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("24HourNo0Port").transform.GetChild(0).gameObject.SetActive(true);

                GameObject.Find("12HourLand").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("24HourLand").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("24HourNo0Land").transform.GetChild(0).gameObject.SetActive(true);
                break;

        }
    }
	
}
