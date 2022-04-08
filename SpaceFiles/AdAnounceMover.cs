using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdAnounceMover : MonoBehaviour
{
    Sprite adAnounce; //左から右へ移動
    Sprite astronaut1;

    IntertisialShower intertisialShower;

    Vector3 startPos;
    Vector3 endPos;

    float speed = 20f;//20

    public bool move = false;

    float leftXPosIphonePort = -500;
    float leftXPosIphoneLand = -850;
    float leftXPosIpadPort = -630;
    float leftXPosIpadLand = -580;

    float yPos = -170;

    float waveSpan = 0.03f;
    float waveMax = 20f;
    float waveCount = 0f;
    bool isUpWave = true;

    // Start is called before the first frame update
    void Start()
    {
        intertisialShower = GameObject.Find("Ads").GetComponent<IntertisialShower>();
            
        adAnounce = Resources.Load<Sprite>("Image/Space/adAnounce");
        astronaut1 = Resources.Load<Sprite>("Image/Space/astronaut1");

        this.gameObject.transform.position = new Vector3(-Screen.width - 100, Screen.height + 100, 0);
    }


    void Update()
    {
        
        if (move == true)
        {
            //float step = speed * Time.deltaTime;
            //this.gameObject.transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPos, step);

            //Vector3 wavePos = this.gameObject.transform.localPosition;
            //if (isUpWave == true) wavePos.y += waveSpan;
            //if (isUpWave == false) wavePos.y -= waveSpan;
            //waveCount += waveSpan;
            //this.gameObject.transform.localPosition = wavePos;

            //if (waveCount > waveMax)
            //{
            //    waveCount = 0f;
            //    isUpWave = !isUpWave;
            //}


            //if (this.gameObject.transform.localPosition.x >= endPos.x)
            //{
            //    ChangeSpriteAtFinishedMoving();
            //    this.gameObject.transform.position = new Vector3(-Screen.width - 100, Screen.height + 100, 0);
            //    move = false;
            //}
        }

    }





    public void MoveAdAnounce()
    {
        float leftXPos = 0;

        bool port = true;
        if (Screen.width > Screen.height)
            port = false;

        bool isIpad = false;
        if (SystemInfo.deviceModel.Contains("iPad"))
            isIpad = true;

        if (port == true && isIpad == false)
            leftXPos = leftXPosIphonePort;
        if (port == false && isIpad == false)
            leftXPos = leftXPosIphoneLand;
        if (port == true && isIpad == true)
            leftXPos = leftXPosIpadPort;
        if (port == false && isIpad == true)
            leftXPos = leftXPosIpadLand;

        startPos = new Vector3(leftXPos, yPos, 0);
        endPos = new Vector3(-leftXPos, yPos, 0);
        
        this.gameObject.transform.localPosition = startPos;        

        move = true;
    }



    public void RemoveAdAnounce()
    {
        move = false;
        this.gameObject.transform.position = new Vector3(-Screen.width - 100, Screen.height + 100, 0);

    }



    public void ChangeSpriteAtFinishedAd()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = astronaut1;
        Vector3 ang = this.transform.localEulerAngles; //いったんそのオブジェの角度すべてをvector変数に入れる
        ang.x = 0f; //X軸にのみ任意の値を代入
        ang.y = 180f;
        ang.z = 0f;
        this.transform.localEulerAngles = ang;

        this.gameObject.transform.localScale = new Vector3(45,45,0);

        intertisialShower.DeleteText();
    }


    void ChangeSpriteAtFinishedMoving()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = adAnounce;
        Vector3 ang = this.transform.localEulerAngles; //いったんそのオブジェの角度すべてをvector変数に入れる
        ang.x = 0f; //X軸にのみ任意の値を代入
        ang.y = 0f;
        ang.z = 0f;
        this.transform.localEulerAngles = ang;

        this.gameObject.transform.localScale = new Vector3(35, 35, 0);


        intertisialShower.ShowText();
    }


}
