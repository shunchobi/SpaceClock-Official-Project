using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailer : MonoBehaviour
{
    //メール
    private const string MAIL_ADRESS = "spaceclock@one-wheat.com";
    private const string NEW_LINE_STRING = "\n";
    private const string CAUTION_STATEMENT = "---------以下の内容はそのままで---------" + NEW_LINE_STRING;
    /// <summary>
    /// メーラーを起動する
    /// </summary>
    public static void OpenMailer()
    {
        //タイトルはアプリ名
        string subject = "Space Clock";
        //本文は端末名、OS、アプリバージョン、言語
        string deviceName = SystemInfo.deviceModel;
#if UNITY_IOS && !UNITY_EDITOR
deviceName = UnityEngine.iOS.Device.generation.ToString();
#endif
        string body = NEW_LINE_STRING + NEW_LINE_STRING + CAUTION_STATEMENT + NEW_LINE_STRING;
        body += "Device   : " + deviceName + NEW_LINE_STRING;
        body += "OS       : " + SystemInfo.operatingSystem + NEW_LINE_STRING;
        body += "Ver      : " + "1.0" + NEW_LINE_STRING;
        body += "Language : " + Application.systemLanguage.ToString() + NEW_LINE_STRING;
        //エスケープ処理
        body = System.Uri.EscapeDataString(body);
        subject = System.Uri.EscapeDataString(subject);
        Application.OpenURL("mailto:" + MAIL_ADRESS + "?subject=" + subject + "&body=" + body);
    }
}
