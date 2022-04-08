using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFormatChoser : MonoBehaviour
{

    public void SetCheckMark()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        OrientationMonitor orientationMonitor = GameObject.Find("Main Camera").GetComponent<OrientationMonitor>();


        if (orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeLeft ||
        orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeRight) {
            switch (this.gameObject.transform.name)
            {
                case "12HourLand":
                    Cash.preference.howNumDisplay = 1;
                    SaveManager.SaveFile_Preference();
                    DayTimeChanger.ChangeTime(DayTimeManager.hour, DayTimeManager.minute);
                    GameObject.Find("24HourLand").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.Find("24HourNo0Land").transform.GetChild(0).gameObject.SetActive(false);
                    break;
                case "24HourLand":
                    Cash.preference.howNumDisplay = 2;
                    SaveManager.SaveFile_Preference();
                    DayTimeChanger.ChangeTime(DayTimeManager.hour, DayTimeManager.minute);
                    GameObject.Find("12HourLand").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.Find("24HourNo0Land").transform.GetChild(0).gameObject.SetActive(false);
                    break;
                case "24HourNo0Land":
                    Cash.preference.howNumDisplay = 3;
                    SaveManager.SaveFile_Preference();
                    DayTimeChanger.ChangeTime(DayTimeManager.hour, DayTimeManager.minute);
                    GameObject.Find("12HourLand").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.Find("24HourLand").transform.GetChild(0).gameObject.SetActive(false);
                    break;
            }
        }


        else if (orientationMonitor.PrevOrientation == DeviceOrientation.Portrait) {
            switch (this.gameObject.transform.name)
            {
                case "12HourPort":
                    Cash.preference.howNumDisplay = 1;
                    SaveManager.SaveFile_Preference();
                    DayTimeChanger.ChangeTime(DayTimeManager.hour, DayTimeManager.minute);
                    GameObject.Find("24HourPort").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.Find("24HourNo0Port").transform.GetChild(0).gameObject.SetActive(false);
                    break;
                case "24HourPort":
                    Cash.preference.howNumDisplay = 2;
                    SaveManager.SaveFile_Preference();
                    DayTimeChanger.ChangeTime(DayTimeManager.hour, DayTimeManager.minute);
                    GameObject.Find("12HourPort").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.Find("24HourNo0Port").transform.GetChild(0).gameObject.SetActive(false);
                    break;
                case "24HourNo0Port":
                    Cash.preference.howNumDisplay = 3;
                    SaveManager.SaveFile_Preference();
                    DayTimeChanger.ChangeTime(DayTimeManager.hour, DayTimeManager.minute);
                    GameObject.Find("12HourPort").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.Find("24HourPort").transform.GetChild(0).gameObject.SetActive(false);
                    break;
            }
        }
    }

    
}
