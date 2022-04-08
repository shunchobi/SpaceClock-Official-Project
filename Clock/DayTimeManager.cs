using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DayTimeManager : MonoBehaviour
{

    public static int year;
    public static int month;
    public static int day;
    public static int hour;
    public static int minute;
    public static int second;
    public static DayOfWeek dayOfWeek;

    DateTime now;


    void Start()
    {
        //プロパティ
        now = DateTime.Now;

        //year = now.Year;                //　年
        month = now.Month;              //　月
        day = now.Day;                  //　日
        hour = now.Hour;                //　時
        minute = now.Minute;            //　分
        //second = now.Second;            //　秒

        dayOfWeek = now.DayOfWeek;//　曜日
        //Sunday=0,Monday=1,Tuesday=2,Wednesday=3,Thursday=4,Friday=5,Saturday=6

        DayTimeChanger.ChangeDayMonth(day, month);
        DayTimeChanger.ChangeTime(hour, minute);
        string s = dayOfWeek.ToString();
        DayTimeChanger.ChangeWeek(s);


    }







    // Update is called once per frame
    void Update()
    {
        now = DateTime.Now;

        if (month != now.Month || day != now.Day)
        {
            month = now.Month;
            day = now.Day;
            DayTimeChanger.ChangeDayMonth(day, month);
        }

        if (hour != now.Hour || minute != now.Minute)
        {
            hour = now.Hour;
            minute = now.Minute;
            DayTimeChanger.ChangeTime(hour, minute);
        }


        if (dayOfWeek != now.DayOfWeek)
        {
            dayOfWeek = now.DayOfWeek;
            string s = dayOfWeek.ToString();
            DayTimeChanger.ChangeWeek(s);
        }
    }








}
