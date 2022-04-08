using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenuOpener : MonoBehaviour
{

    GameObject settingPanel;
    GameObject settingBackgraundPort;
    GameObject settingBackgraundLand;

    OrientationMonitor orientationMonitor;

    CompleteProject.Purchaser purchaser;

    //Vector3 posLand = new Vector3(0, 390, 0);
    //Vector3 posLand_iPad = new Vector3(0, 420, 0);
    Vector3 posLand = new Vector3(0, 500, 0);
    Vector3 posLand_iPad = new Vector3(0, 500, 0);
    Vector3 scaleLand = new Vector3(1.3f, 1.3f, 1);

    //Vector3 posPort = new Vector3(0, 450, 0);
    //Vector3 posPort_iPad = new Vector3(0, 430, 0);
    Vector3 posPort = new Vector3(0, 500, 0);
    Vector3 posPort_iPad = new Vector3(0, 500, 0);
    Vector3 scalePort = new Vector3(1, 1, 1);


    public bool isOpen = false;
    public bool isPort = true;

    Text Purchase_Port_T;
    Text Video_Port_T;
    Text Purchase_Land_T;
    Text Video_Land_T;
    Text AdsTitle_Port;
    Text AdsTitle_Land;
    Text Value_Port;
    Text Value_Land;

    GameObject Stiker_Port_P;
    GameObject Stiker_Port_V;
    GameObject Stiker_Land_P;
    GameObject Stiker_Land_V;

    GameObject Purchase_Port;
    GameObject Video_Port;
    GameObject Purchase_Land;
    GameObject Video_Land;



    string purchase_Ja = "一生広告フリー！";
    string video_Ja = "6時間広告フリー！";
    string purchase_En = "No Ads ever!";
    string video_En = "No Ads for 6hours!";
    string adsTitle_Ja = "★広告を消せるよ★";
    string adsTitle_En = "★You can delete Ads★";
    string stiker_Purchased_Ja = "購入済み";
    string stiker_Purchased_En = "Purchased";
    string stiker_NoNeed_Ja = "必要なし";
    string stiker_NoNeed_En = "NoNeed";

    string value = "";



    private void Start()
    {
        settingPanel = GameObject.Find("SettingPanel");
        settingBackgraundPort = GameObject.Find("SettingBackgraundPort");
        settingBackgraundLand = GameObject.Find("SettingBackgraundLand");

        purchaser = GameObject.Find("Purchases").GetComponent<CompleteProject.Purchaser>();

        Purchase_Port_T = GameObject.Find("Purchase_Port_T").GetComponent<Text>();
        Video_Port_T = GameObject.Find("Video_Port_T").GetComponent<Text>();
        Purchase_Land_T = GameObject.Find("Purchase_Land_T").GetComponent<Text>();
        Video_Land_T = GameObject.Find("Video_Land_T").GetComponent<Text>();
        AdsTitle_Port = GameObject.Find("AdsTitle_Port").GetComponent<Text>();
        AdsTitle_Land = GameObject.Find("AdsTitle_Land").GetComponent<Text>();
        Value_Port = GameObject.Find("Value_Port").GetComponent<Text>();
        Value_Land = GameObject.Find("Value_Land").GetComponent<Text>();

        Stiker_Port_P = GameObject.Find("Stiker_Port_P");
        Stiker_Port_V = GameObject.Find("Stiker_Port_V");
        Stiker_Land_P = GameObject.Find("Stiker_Land_P");
        Stiker_Land_V = GameObject.Find("Stiker_Land_V");

        Purchase_Port = GameObject.Find("Purchase_Port");
        Video_Port = GameObject.Find("Video_Port");
        Purchase_Land = GameObject.Find("Purchase_Land");
        Video_Land = GameObject.Find("Video_Land");

        if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            settingBackgraundPort.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Setting/setting_ja");
            settingBackgraundLand.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Setting/settingLand_ja");
            Purchase_Port_T.text = purchase_Ja;
            Video_Port_T.text = video_Ja;
            Purchase_Land_T.text = purchase_Ja;
            Video_Land_T.text = video_Ja;
            AdsTitle_Port.text = adsTitle_Ja;
            AdsTitle_Land.text = adsTitle_Ja;
            Stiker_Port_P.transform.Find("Text").gameObject.GetComponent<Text>().text = stiker_Purchased_Ja;
            Stiker_Port_V.transform.Find("Text").gameObject.GetComponent<Text>().text = stiker_NoNeed_Ja;
            Stiker_Land_P.transform.Find("Text").gameObject.GetComponent<Text>().text = stiker_Purchased_Ja;
            Stiker_Land_V.transform.Find("Text").gameObject.GetComponent<Text>().text = stiker_NoNeed_Ja;
            GameObject.Find("Restore_Port").GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Setting/restore_ja");
            GameObject.Find("Restore_Land").GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Setting/restore_ja");

            //Value_Port.text = ;
            //Value_Land.text = ;
        }
        else
        {
            settingBackgraundPort.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Setting/setting_en");
            settingBackgraundLand.GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Setting/settingLand_en");

            Purchase_Port_T.text = purchase_En;
            Video_Port_T.text = video_En;
            Purchase_Land_T.text = purchase_En;
            Video_Land_T.text = video_En;
            AdsTitle_Port.text = adsTitle_En;
            AdsTitle_Land.text = adsTitle_En;
            Stiker_Port_P.transform.Find("Text").gameObject.GetComponent<Text>().text = stiker_Purchased_En;
            Stiker_Port_V.transform.Find("Text").gameObject.GetComponent<Text>().text = stiker_NoNeed_En;
            Stiker_Land_P.transform.Find("Text").gameObject.GetComponent<Text>().text = stiker_Purchased_En;
            Stiker_Land_V.transform.Find("Text").gameObject.GetComponent<Text>().text = stiker_NoNeed_En;
            GameObject.Find("Restore_Port").GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Setting/restore_en");
            GameObject.Find("Restore_Land").GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/Setting/restore_en");

            //Value_Port.text = ;
            //Value_Land.text = ;
        }

        Stiker_Port_P.SetActive(false);
        Stiker_Port_V.SetActive(false);
        Stiker_Land_P.SetActive(false);
        Stiker_Land_V.SetActive(false);

        settingPanel.SetActive(false);
        orientationMonitor = GameObject.Find("Main Camera").GetComponent<OrientationMonitor>();
    }




    bool move = false;
    float speed = 150;
    Vector3 endPos = Vector3.zero;
    GameObject movedObj = null;

    private void Update()
    {
        if (move == true)
        {
            movedObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(movedObj.GetComponent<RectTransform>().anchoredPosition.x, movedObj.GetComponent<RectTransform>().anchoredPosition.y+speed, 0);
            if (movedObj.GetComponent<RectTransform>().anchoredPosition.y >= endPos.y)
            {
                movedObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(endPos.x, endPos.y, endPos.z);
                move = false;
            }
        }
    }




    public void PutStikers()
    {
        if (orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeLeft ||
        orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeRight)
        {
            Stiker_Land_P.SetActive(true);
            Stiker_Land_V.SetActive(true);

            Purchase_Land.GetComponent<Button>().enabled = false;
            Video_Land.GetComponent<Button>().enabled = false;
        }
        else if (orientationMonitor.PrevOrientation == DeviceOrientation.Portrait)
        {
            Stiker_Port_P.SetActive(true);
            Stiker_Port_V.SetActive(true);

            Purchase_Port.GetComponent<Button>().enabled = false;
            Video_Port.GetComponent<Button>().enabled = false;
        }

    }




    public void OpenSettingMenu(){
        GameObject.Find("BackGround").GetComponent<ScreenToucher>().ToucheableScreen(false);
        Cash.adsController.HideBanner();

        if (orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeLeft ||
                orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeRight)
        {
            isOpen = true;
            isPort = false;
            ChangeSizeForLand();
        }
        else if (orientationMonitor.PrevOrientation == DeviceOrientation.Portrait)
        {
            isOpen = true;
            isPort = true;
            ChangeSizeForPort();
        }
    }


    void ChangeSizeForPort()
    {
        settingPanel.SetActive(true);
        settingBackgraundPort.SetActive(true);
        settingBackgraundLand.SetActive(false);
        settingBackgraundPort.GetComponent<RectTransform>().localScale = scalePort;

        settingBackgraundPort.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -1000, 0);
        movedObj = settingBackgraundPort;
        endPos = posPort;
        Debug.Log("heyyyy");
        GameObject.Find("Value_Port").GetComponent<Text>().text = purchaser.price;


        string deviceModel = SystemInfo.deviceModel;
        if (deviceModel.Contains("iPad"))
        {
            endPos = posPort_iPad;
        }

        if (Cash.preference.hasPurchased == true)
        {
            Stiker_Port_P.SetActive(true);
            Stiker_Port_V.SetActive(true);

            Purchase_Port.GetComponent<Button>().enabled = false;
            Video_Port.GetComponent<Button>().enabled = false;
        }

        if (Cash.preference.rewardWatched == false)
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
                Video_Port_T.text = video_Ja;
            else
                Video_Port_T.text = video_En;
        }

            move = true;
    }




    void ChangeSizeForLand()
    {
        settingPanel.SetActive(true);
        settingBackgraundPort.SetActive(false);
        settingBackgraundLand.SetActive(true);
        settingBackgraundLand.GetComponent<RectTransform>().localScale = scaleLand;

        settingBackgraundLand.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -1000, 0);
        movedObj = settingBackgraundLand;
        endPos = posLand;

        GameObject.Find("Value_Land").GetComponent<Text>().text = purchaser.price;

        string deviceModel = SystemInfo.deviceModel;
        if (deviceModel.Contains("iPad"))
        {
            endPos = posLand_iPad;
        }

        if (Cash.preference.hasPurchased == true)
        {
            Stiker_Land_P.SetActive(true);
            Stiker_Land_V.SetActive(true);

            Purchase_Land.GetComponent<Button>().enabled = false;
            Video_Land.GetComponent<Button>().enabled = false;

        }

        if (Cash.preference.rewardWatched == false)
        {
            if (Application.systemLanguage == SystemLanguage.Japanese)
                Video_Land_T.text = video_Ja;
            else
                Video_Land_T.text = video_En;
        }


        move = true;
    }



}
