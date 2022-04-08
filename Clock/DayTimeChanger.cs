using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DayTimeChanger : MonoBehaviour
{


    /// <summary>
    /// 月を変更表示
    /// </summary>
    public static void ChangeDayMonth(int day, int month)
    {
        string dayTenDigit = GetTenDigit(day).ToString();
        string dayOneDigit = GetOneDigit(day).ToString();
        string monthTenDigit = GetTenDigit(month).ToString();
        string monthOneDigit = GetOneDigit(month).ToString();


        Cash.day1Img.sprite = SpriteGetter.GetSprite(dayTenDigit);
        Cash.day2Img.sprite = SpriteGetter.GetSprite(dayOneDigit);
        Cash.month1Img.sprite = SpriteGetter.GetSprite(monthTenDigit);
        Cash.month2Img.sprite = SpriteGetter.GetSprite(monthOneDigit);
    }






    /// <summary>
    /// 曜日を変更表示
    /// </summary>
    public static void ChangeWeek(string week)
    {

        Cash.dayOfWeeksImg.sprite = SpriteGetter.GetSprite(week);
    }






    /// <summary>
    /// 時間を変更表示
    /// </summary>
    public static void ChangeTime(int hour, int minute)
    {
        int hourTenDigit = GetTenDigit(hour);
        int hourOneDigit = GetOneDigit(hour);
        int minuteTenDigit = GetTenDigit(minute);
        int minuteOneDigit = GetOneDigit(minute);

        string hourTenDigitStr = hourTenDigit.ToString();
        string hourOneDigitStr = hourOneDigit.ToString();
        string minuteTenDigitStr = minuteTenDigit.ToString();
        string minuteOneDigitStr = minuteOneDigit.ToString();

        //12時間表示で○○時の数字を表示
        if (Cash.preference.howNumDisplay == 1)
        {
            //hourの十の位のオブジェクトを非表示にする
            if (hour <= 9 || hour >= 12 && hour <= 21)
            {
                Cash.hour1Obj.SetActive(false);
                string hourNum = GetNumOf12hours(hour).ToString();
                Cash.hour2Img.sprite = SpriteGetter.GetSprite(hourNum);
            }
            else
            {
                Cash.hour1Obj.SetActive(true);
                Cash.hour1Img.sprite = SpriteGetter.GetSprite(hourTenDigitStr);
                Cash.hour2Img.sprite = SpriteGetter.GetSprite(hourOneDigitStr);
            }

            Cash.ampmObj.SetActive(true);
            if (hour <= 11) Cash.ampmImg.sprite = Cash.amSp;
            if (hour >= 12) Cash.ampmImg.sprite = Cash.pmSp;
        }
        //24時間表示で○○時の数字を表示
        else if (Cash.preference.howNumDisplay == 2)
        {
            Cash.ampmObj.SetActive(false);
            Cash.hour1Obj.SetActive(true);
            Cash.hour1Img.sprite = SpriteGetter.GetSprite(hourTenDigitStr);
            Cash.hour2Img.sprite = SpriteGetter.GetSprite(hourOneDigitStr);
        }
        //24時間表示、先行ゼロなしで○○時の数字を表示
        else if (Cash.preference.howNumDisplay == 3)
        {
            Cash.ampmObj.SetActive(false);
            if (hour <= 9)
            {
                Cash.hour1Obj.SetActive(false);
                Cash.hour2Img.sprite = SpriteGetter.GetSprite(hourOneDigitStr);
            }
            else
            {
                Cash.hour1Obj.SetActive(true);
                Cash.hour1Img.sprite = SpriteGetter.GetSprite(hourTenDigitStr);
                Cash.hour2Img.sprite = SpriteGetter.GetSprite(hourOneDigitStr);

            }

        }


        //○○分の数字を表示
        Cash.minute1Img.sprite = SpriteGetter.GetSprite(minuteTenDigitStr);
        Cash.minute2Img.sprite = SpriteGetter.GetSprite(minuteOneDigitStr);

    }









    static int GetTenDigit(int num)
    {
        int tenDigit = -1;

        if (num < 10)
            tenDigit = 0;
        else if (num >= 10)
            tenDigit = num / 10;

        return tenDigit;
    }


    static int GetOneDigit(int num)
    {
        int oneDigit = -1;
        int tenDigit = -1;



        if (num < 10)
            tenDigit = 0;
        else if (num >= 10)
            tenDigit = num / 10;

        oneDigit = num - tenDigit * 10;

        return oneDigit;
    }



    static int GetNumOf12hours(int hour)
    {
        int num = -1;

        switch (hour)
        {
            case 12:
                num = 0;
                break;
            case 13:
                num = 1;
                break;
            case 14:
                num = 2;
                break;
            case 15:
                num = 3;
                break;
            case 16:
                num = 4;
                break;
            case 17:
                num = 5;
                break;
            case 18:
                num = 6;
                break;
            case 19:
                num = 7;
                break;
            case 20:
                num = 8;
                break;
            case 21:
                num = 9;
                break;
            case 22:
                num = 10;
                break;
            case 23:
                num = 11;
                break;
        }

        if (hour <= 9)
            num = hour;


        return num;
    }

}
