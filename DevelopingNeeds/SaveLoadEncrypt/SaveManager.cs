using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;


public class SaveManager : MonoBehaviour {
    




	public static Preference preference;
	public static String PREFERENCE_FILE_NAME = "/preference.dat";



    //Save
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static void SaveFile_Preference()
    {
        preference = Cash.preference; //ここでは、セーブしたい値を保持するPreferenceDataを与える。

        string json = JsonUtility.ToJson(preference); //json形式に書き換え

        saveJson(PREFERENCE_FILE_NAME, json);
    }

    //Load
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public static Preference LoadFile_Preference()
    {
        string json = LoadJson(PREFERENCE_FILE_NAME);
        // ファイルの存在チェック
        if (json == "")
        {
            preference = new Preference(); //jsonファイルがなかった場合、普通にインスタンス化
        }
        else
        {
            preference = JsonUtility.FromJson<Preference>(json); //jsonファイルが存在した場合、それを書き換えて、インスタンス化
        }

        return preference; //ここでは、セーブした値を保持するPreferenceDataを返している。
    }








	/// <summary>
	/// 使いたいファイルを取得
	/// </summary>
	static String GetFilePath (string fileName) 
	{
		string fullPath = "";
		string path = Application.persistentDataPath;
		fullPath = path + fileName;
		return fullPath;
	}

	/// <summary>
	/// Loads the json.
	/// </summary>
    public static string LoadJson (string fileName)
	{
		string json = "";
		string path = GetFilePath (fileName);
		if (File.Exists (path)) {

			Debug.Log (fileName + " has file");

			// StreamReaderでファイルを読み込む
			//			StreamReader reader = (new StreamReader (GetFilePath (STATISTICS_FILE_NAME), ENCODE_UTF8));
			Byte[] bytes = File.ReadAllBytes(path);
			String encrypted = Convert.ToBase64String(bytes);
			// ファイルの最後まで読み込む
			//			string encrypted = reader.ReadToEnd ();
			json = EncryptScript.DecryptBase64AesToUTF8 (encrypted); //復号化

		} else {
			Debug.Log (fileName + " new file");
		}

		return json;
	}
	/// <summary>
	/// Saves the json.
	/// </summary>
	public static void saveJson (string fileName, string json)
	{
		string path = GetFilePath(fileName);
		string encryoted = EncryptScript.EncryptUTF8AesToBase64(json); //暗号化

		Byte[] bytes = Convert.FromBase64String(encryoted);
		File.WriteAllBytes(path, bytes);
	}	

}
