using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class ScreenToucher : MonoBehaviour
{


    bool isTouchedForSeting = false;
    Button settingOpenerB;
    Image settingOpenerI;


    // Start is called before the first frame update
    void Start()
    {
        settingOpenerB = GameObject.Find("SettingOpener").GetComponent<Button>();
        settingOpenerI = GameObject.Find("SettingOpener").GetComponent<Image>();
        SetStatusBarAndSetting(false);
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("shun");
    //    }
    //}



    private void DisplaySetting()
    {
        //ステータスバーと設定ボタンを表示
        if(isTouchedForSeting == false)
        {
            SetStatusBarAndSetting(true);
            isTouchedForSeting = true;
        }
        //ステータスバーと設定ボタンを非表示
        else
        {
            SetStatusBarAndSetting(false);
            isTouchedForSeting = false;
        }

    }



    float delta = 10f;
    bool isDrag = false;
    Vector3 mouseDownPos = new Vector3();
    float maxBrightDelta = 800;
    float brightnessNow;

    private void OnMouseDrag()
    {
        if (Math.Abs(mouseDownPos.y - Input.mousePosition.y) >= delta)
        {
            //上にドラッグすれば値は正、下なら負
            float dragYDelta = Input.mousePosition.y - mouseDownPos.y;
            float addBrightnessNum = dragYDelta / maxBrightDelta;
            float newBrightness = brightnessNow + addBrightnessNum;
            SetBrightness.DoAction(newBrightness);
        }
    }



    private void OnMouseDown()
    {
        brightnessNow = Screen.brightness;
        mouseDownPos = Input.mousePosition;
    }



    private void OnMouseUp()
    {
        if (Math.Abs(mouseDownPos.y - Input.mousePosition.y) <= delta)
        {
            DisplaySetting();
        }
    }




    void SetStatusBarAndSetting(bool isShow)
    {
        settingOpenerB.enabled = isShow;
        if(isShow == false)
            settingOpenerI.color = new Color(255f, 255f, 255f, 0f);
        else
            settingOpenerI.color = new Color(255f, 255f, 255f, 255f);
        //ステータスバーを表示,非表示
        NativeUtil.IOSUtil.SetStatusBarEnabled(isShow);
    }




    public void ToucheableScreen(bool able)
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = able;
    }
}
