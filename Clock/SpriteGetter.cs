using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteGetter : MonoBehaviour
{



    public static Sprite GetSprite(string value)
    {
        Sprite target = null;

        switch (value)
        {
            case "0":
                target = Cash.zero;
                break;
            case "1":
                target = Cash.one;
                break;
            case "2":
                target = Cash.two;
                break;
            case "3":
                target = Cash.three;
                break;
            case "4":
                target = Cash.four;
                break;
            case "5":
                target = Cash.five;
                break;
            case "6":
                target = Cash.six;
                break;
            case "7":
                target = Cash.seven;
                break;
            case "8":
                target = Cash.eight;
                break;
            case "9":
                target = Cash.nine;
                break;

            case "AM":
                target = Cash.amSp;
                break;
            case "PM":
                target = Cash.pmSp;
                break;

            case "Monday":
                target = Cash.monSp;
                break;
            case "Tuesday":
                target = Cash.tueSp;
                break;
            case "Wednesday":
                target = Cash.wedSp;
                break;
            case "Thursday":
                target = Cash.thuSp;
                break;
            case "Friday":
                target = Cash.friSp;
                break;
            case "Saturday":
                target = Cash.SatSp;
                break;
            case "Sunday":
                target = Cash.sunSp;
                break;
        }
        return target;

    }

}
