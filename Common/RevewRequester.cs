using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevewRequester : MonoBehaviour
{


    float count = 0;
    float requestTime = 600; //アプリを３回以上起動後で、利用開始10分後にレビュー依頼
    int whenRequestHasOpenedApp = 3;
    bool isThreeTimeHasOpened = false;
    


    // Start is called before the first frame update
    void Start()
    {
        Cash.preference.howManyHasOpenedApp++;
        SaveManager.SaveFile_Preference();

        if (Cash.preference.howManyHasOpenedApp >= whenRequestHasOpenedApp
            && Cash.preference.hasRequestReview == false)
        {
            isThreeTimeHasOpened = true;
        }

        Debug.Log("howManyHasOpenedApp = "+ Cash.preference.howManyHasOpenedApp);
    }

    // Update is called once per frame
    void Update()
    {
        if (isThreeTimeHasOpened == true)
        {
            count += Time.deltaTime;

            if (count >= requestTime)
            {
                RequestReviwe();
                isThreeTimeHasOpened = false;
            }
        }
    }

    public void RequestReviwe()
    {
        UnityEngine.iOS.Device.RequestStoreReview();
        Cash.preference.hasRequestReview = true;
        SaveManager.SaveFile_Preference();

        Debug.Log("Requestd Review");
    }

}
