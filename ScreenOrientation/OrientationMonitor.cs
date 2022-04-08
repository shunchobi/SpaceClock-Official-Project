using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationMonitor : MonoBehaviour
{

    Camera _mainCamera;


    // 直前のディスプレイ向き
    public DeviceOrientation PrevOrientation;

    SettingMenuOpener settingMenuOpener;

    GameObject Time;
    GameObject Day;
    GameObject Week;
    GameObject settingOpener;

    GameObject spaceMaterial;

    Vector3 timeScaleLand = new Vector3(3.5f,3.5f,1);
    Vector3 timePosLand = new Vector3(0, 0, 0); //(0, 0, 0)
    Vector3 dayWeekScaleLand = new Vector3(2, 2, 1);
    Vector3 dayPosLand = new Vector3(48, -750, 0);//(0, -750, 0)
    Vector3 weekPosLand = new Vector3(0, -750, 0);//(0, -750, 0)
    Vector3 settingOpenerPos;
    Vector3 settingOpenerScaleLand = new Vector3(2, 2, 1);


    Vector3 timeScalePort = new Vector3(1.2f, 1.2f, 1);
    Vector3 timePosPort = new Vector3(0, 270, 0);
    Vector3 dayWeekScalePort = new Vector3(1, 1, 1);
    Vector3 dayPosPort = new Vector3(48, -110, 0);
    Vector3 weekPosPort = new Vector3(0, -110, 0);
    Vector3 settingOpenerScalePort = new Vector3(1, 1, 1);



    // 端末の向きを取得するメソッド
    DeviceOrientation getOrientation()
    {

        DeviceOrientation result;

        if (Screen.width < Screen.height)
        {
            result = DeviceOrientation.Portrait;
        }
        else
        {
            result = DeviceOrientation.LandscapeLeft;
        }

        return result;
    }



    public void InitilaizeOrient()
    {
        _mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        settingMenuOpener = GameObject.Find("SettingOpener").GetComponent<SettingMenuOpener>();

        Time = GameObject.Find("Time");
        Day = GameObject.Find("Day");
        Week = GameObject.Find("Week");
        settingOpener = GameObject.Find("SettingOpener");

        spaceMaterial = GameObject.Find("SpaceMaterial");

        PrevOrientation = getOrientation();

        settingOpenerPos = new Vector3(Screen.width/2-43-43, -Screen.height/2+43+43,0);

        if (PrevOrientation == DeviceOrientation.LandscapeLeft ||
                PrevOrientation == DeviceOrientation.LandscapeRight)
            UiScaleChangerForLand();
        else if (PrevOrientation == DeviceOrientation.Portrait)
            UiScaleChangerForPort();

    }



    void Update()
    {
        DeviceOrientation currentOrientation = getOrientation();

        // 画面の向きが変わった場合の処理
        if (PrevOrientation != currentOrientation)
        {
            if (settingMenuOpener.isOpen == true)
            {
                if (PrevOrientation == DeviceOrientation.LandscapeLeft ||
                PrevOrientation == DeviceOrientation.LandscapeRight)
                {
                    GameObject.Find("CloseSetting_Land").GetComponent<SettingMenuCloser>().CloseSettingMenu(false);
                }
                else if (PrevOrientation == DeviceOrientation.Portrait)
                {
                    GameObject.Find("CloseSetting_Port").GetComponent<SettingMenuCloser>().CloseSettingMenu(false);
                }
            }

            //orientationMonitor.PrevOrientation = FaceUp

            PrevOrientation = currentOrientation;
            
            if (PrevOrientation == DeviceOrientation.LandscapeLeft ||
                PrevOrientation == DeviceOrientation.LandscapeRight)
                UiScaleChangerForLand();
            else if (PrevOrientation == DeviceOrientation.Portrait)
                UiScaleChangerForPort();

            Cash.adsController.RequestBanner();
            Cash.adsController.ShowBanner();
        }
    }




    void UiScaleChangerForLand()
    {
        string deviceModel = SystemInfo.deviceModel;

        Time.GetComponent<Transform>().localScale = timeScaleLand;
        Time.GetComponent<Transform>().localPosition = timePosLand;
        Day.GetComponent<Transform>().localScale = dayWeekScaleLand;
        Day.GetComponent<Transform>().localPosition = dayPosLand;
        Week.GetComponent<Transform>().localScale = dayWeekScaleLand;
        Week.GetComponent<Transform>().localPosition = weekPosLand;
        //settingOpener.GetComponent<RectTransform>().localPosition = new Vector3((Screen.width / 2) - 43 - 43, (-Screen.height / 2) + 43 + 43, 0);
        settingOpener.GetComponent<RectTransform>().localScale = settingOpenerScaleLand;


        if (deviceModel.Contains("iPad"))
        {

            Time.GetComponent<Transform>().localScale = new Vector3(2.6f, 2.6f, 1); 

            spaceMaterial.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            BGSizeChanger.ChangeToLand_ipad();
        }
        else
        {
            spaceMaterial.transform.localScale = new Vector3(2, 2, 1);
            BGSizeChanger.ChangeToLand_iPhone();
        }

    }



    void UiScaleChangerForPort()
    {
        string deviceModel = SystemInfo.deviceModel;

        if (deviceModel.Contains("iPad"))
        {
            BGSizeChanger.ChangeToPort_iPad();
        }
        else
        {
            BGSizeChanger.ChangeToPort_iPhone();
        }

        spaceMaterial.transform.localScale = new Vector3(1, 1, 1);

        Time.GetComponent<Transform>().localScale = timeScalePort;
        Time.GetComponent<Transform>().localPosition = timePosPort;
        Day.GetComponent<Transform>().localScale = dayWeekScalePort;
        Day.GetComponent<Transform>().localPosition = dayPosPort;
        Week.GetComponent<Transform>().localScale = dayWeekScalePort;
        Week.GetComponent<Transform>().localPosition = weekPosPort;
        settingOpener.GetComponent<RectTransform>().localScale = settingOpenerScalePort;


        if (deviceModel.Contains("iPad"))
        {
            Time.GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f, 1); ;

            BGSizeChanger.ChangeToPort_iPad();
        }
        else
        {
            BGSizeChanger.ChangeToPort_iPhone();
        }

    }


    


}
