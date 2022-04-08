using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Preference {

    //1 = 12時間表示
    //2 = 24時間表示
    //3 = 24時間表示、先行ゼロなし
    public int howNumDisplay = 1;

    //課金したかどうか
    public bool hasPurchased = false;

    //動画を見て広告非表示中かどうか
    public bool rewardWatched = false;

    //広告非表示中にアプリを終了した時の非表示経過時間
    public int passedTimeWithNoAds;

    public int leftAppTime;
    public int leftAppDay;
    public int leftAppMonth;
    public int LeftAppMonthDays;


    public int howManyHasOpenedApp = 0;

    public bool hasRequestReview = false;


    //上下スライドで画面明るさ調整
    bool lightCont = true;

    //スワイプで数字のサイズ調整
    bool sizeCont = true;



}
