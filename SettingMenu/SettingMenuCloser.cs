using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenuCloser : MonoBehaviour
{

    SettingMenuOpener settingMenuOpener;
    RewardDealer rewardDealer;


    public void CloseSettingMenu(bool showBanner)
    {
        settingMenuOpener = GameObject.Find("SettingOpener").GetComponent<SettingMenuOpener>();
        rewardDealer = GameObject.Find("Ads").GetComponent<RewardDealer>();

        settingMenuOpener.isOpen = false;
        GameObject.Find("SettingPanel").SetActive(false);
        GameObject.Find("BackGround").GetComponent<ScreenToucher>().ToucheableScreen(true);
        if (showBanner == true && Cash.preference.hasPurchased == false && Cash.preference.rewardWatched == false)
            Cash.adsController.ShowBanner();
    }
}
