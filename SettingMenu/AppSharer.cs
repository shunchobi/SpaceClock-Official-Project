using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SocialConnector;
using UnityEngine.UI;

public class AppSharer : MonoBehaviour
{


    string appId = "1539660932";
    string ja = "便利な置き時計。背景で宇宙でかわいい！";
    string en = "The Clock with space backgraund! Those are moving, cool!";

    OrientationMonitor orientationMonitor;


    public void Share()
    {
        orientationMonitor = GameObject.Find("Main Camera").GetComponent<OrientationMonitor>();

        if (orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeLeft ||
        orientationMonitor.PrevOrientation == DeviceOrientation.LandscapeRight)
        {
            GameObject.Find("CloseSetting_Land").GetComponent<SettingMenuCloser>().CloseSettingMenu(true);
        }
        else if (orientationMonitor.PrevOrientation == DeviceOrientation.Portrait)
        {
            GameObject.Find("CloseSetting_Port").GetComponent<SettingMenuCloser>().CloseSettingMenu(true);
        }

        StartCoroutine(_Share());

    }



    public IEnumerator _Share()
    {
        Debug.Log("_Share is woring");
        string imgPath = Application.persistentDataPath + "/image.png";

        // 前回のデータを削除
        File.Delete(imgPath);

        //スクリーンショットを撮影
        ScreenCapture.CaptureScreenshot("image.png");

        // 撮影画像の保存が完了するまで待機
        while (true)
        {
            if (File.Exists(imgPath)) break;
            yield return null;
        }

        // 投稿する
        string tweetText = ja;
        string tweetURL = string.Format("itms-apps://itunes.apple.com/app/id{0}?mt=8", Cash.appId);
        SocialConnector.SocialConnector.Share(tweetText, tweetURL, imgPath);
    }




    //public void ShareApp()
    //{
    //    SocialConnector.SocialConnector.Share(ja, string.Format("itms-apps://itunes.apple.com/app/id{0}?mt=8", Cash.appId), null);
    //    //SocialConnector.SocialConnector.Share(ja, "https://apps.apple.com/us/app/solitaire-ex/id1333116435?l=ja&ls=1", null);

    //}
}
