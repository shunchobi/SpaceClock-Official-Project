using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreOpener : MonoBehaviour
{




    public void OnMouseUp()
    {
        OpenAppStore();
       
    }



    void OpenAppStore()
    {
        Application.OpenURL("https://itunes.apple.com/jp/app/id1539660932?mt=8");
    }


}
