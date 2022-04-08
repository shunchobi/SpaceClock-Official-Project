using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


static class Cash {


    public static Preference preference;
    public static AdsController adsController;
    public static OrientationMonitor orientationMonitor;
    public static RewardDealer rewardDealer;

    public static string appId = "1539660932";


    public static string kolonStr = "Kolon";
    public static string slashStr = "Slash";

    public static string hour1Str = "Hour1";
    public static string hour2Str = "Hour2";
    public static string minute1Str = "Minute1";
    public static string minute2Str = "Minute2";
    public static string ampmStr = "AMPM";

    public static string month1Str = "Month1";
    public static string month2Str = "Month2";
    public static string day1Str = "Day1";
    public static string day2Str = "Day2";

    public static string dayOfWeeksStr = "DayOfWeeks";


    public static GameObject hour1Obj;
    public static GameObject ampmObj;



    public static Image kolonImg;
    public static Image slashImg;

    public static Image hour1Img;
    public static Image hour2Img;
    public static Image minute1Img;
    public static Image minute2Img;
    public static Image ampmImg;

    public static Image month1Img;
    public static Image month2Img;
    public static Image day1Img;
    public static Image day2Img;

    public static Image dayOfWeeksImg;



    public static Sprite zero;
    public static Sprite one;
    public static Sprite two;
    public static Sprite three;
    public static Sprite four;
    public static Sprite five;
    public static Sprite six;
    public static Sprite seven;
    public static Sprite eight;
    public static Sprite nine;

    public static Sprite kolonSp;
    public static Sprite slashSp;

    public static Sprite amSp;
    public static Sprite pmSp;

    public static Sprite sunSp;
    public static Sprite monSp;
    public static Sprite tueSp;
    public static Sprite wedSp;
    public static Sprite thuSp;
    public static Sprite friSp;
    public static Sprite SatSp;






    public static void Init(){
        preference = SaveManager.LoadFile_Preference();
        adsController = GameObject.Find("Ads").GetComponent<AdsController>();
        orientationMonitor = GameObject.Find("Main Camera").GetComponent<OrientationMonitor>();
        rewardDealer = GameObject.Find("Ads").GetComponent<RewardDealer>();

        hour1Obj = GameObject.Find(hour1Str);
        ampmObj = GameObject.Find(ampmStr);

        kolonImg = GameObject.Find(kolonStr).GetComponent<Image>();
        slashImg = GameObject.Find(slashStr).GetComponent<Image>();

        hour1Img = hour1Obj.GetComponent<Image>();
        hour2Img = GameObject.Find(hour2Str).GetComponent<Image>();
        minute1Img = GameObject.Find(minute1Str).GetComponent<Image>();
        minute2Img = GameObject.Find(minute2Str).GetComponent<Image>();
        ampmImg = GameObject.Find(ampmStr).GetComponent<Image>();

        month1Img = GameObject.Find(month1Str).GetComponent<Image>();
        month2Img = GameObject.Find(month2Str).GetComponent<Image>();
        day1Img = GameObject.Find(day1Str).GetComponent<Image>();
        day2Img = GameObject.Find(day2Str).GetComponent<Image>();

        dayOfWeeksImg = GameObject.Find(dayOfWeeksStr).GetComponent<Image>();


        string num = "Image/Num/";
        string weeks = "Image/Weeks/";

        zero = Resources.Load<Sprite>(num + "0");
        one = Resources.Load<Sprite>(num + "1");
        two = Resources.Load<Sprite>(num + "2");
        three = Resources.Load<Sprite>(num + "3");
        four = Resources.Load<Sprite>(num + "4");
        five = Resources.Load<Sprite>(num + "5");
        six = Resources.Load<Sprite>(num + "6");
        seven = Resources.Load<Sprite>(num + "7");
        eight = Resources.Load<Sprite>(num + "8");
        nine = Resources.Load<Sprite>(num + "9");

        kolonSp = Resources.Load<Sprite>(num + "time");
        slashSp = Resources.Load<Sprite>(num + "month");

        amSp = Resources.Load<Sprite>(num + "AM");
        pmSp = Resources.Load<Sprite>(num + "PM");

        sunSp = Resources.Load<Sprite>(weeks + "sun");
        monSp = Resources.Load<Sprite>(weeks + "mon");
        tueSp = Resources.Load<Sprite>(weeks + "tue");
        wedSp = Resources.Load<Sprite>(weeks + "wed");
        thuSp = Resources.Load<Sprite>(weeks + "thu");
        friSp = Resources.Load<Sprite>(weeks + "fri");
        SatSp = Resources.Load<Sprite>(weeks + "sat");

    }
}
