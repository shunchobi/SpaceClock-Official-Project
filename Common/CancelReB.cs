using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelReB : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void CancelRe()
    {
        Cash.rewardDealer.CancelRewardAdsTest();
    }


    public void CancelPur()
    {
        Cash.rewardDealer.CancelPurchaseTest();

    }


}
