using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautMover : MonoBehaviour
{


    Sprite astronaut1; //左から右へ移動
    Sprite astronaut2; //右から左へ移動



    float span = 300f; //値の数字秒ごとに宇宙飛行士が飛ぶ
    float currentTime = 0f;

    Vector3 startPos;
    Vector3 endPos;

    float speed = 20f;//20

    bool move = false;

    float bottomYPos = -Screen.height / 2 + Screen.height / 8;
    float topYPos = Screen.height / 2 - Screen.height / 8;
    float rightXPos;
    float leftXPos;



    float waveSpan = 0.03f;
    float waveMax = 20f;
    float waveCount = 0f;
    bool isUpWave = true;


    float XPos = 0;

    // Start is called before the first frame update
    void Start()
	{
        if (Screen.width > Screen.height)
            XPos = Screen.width;
        else
            XPos = Screen.height;
        rightXPos = XPos + 100;
        leftXPos = -XPos - 100;

        astronaut1 = Resources.Load<Sprite>("Image/Space/astronaut1");
        astronaut2 = Resources.Load<Sprite>("Image/Space/astronaut2");
        this.gameObject.transform.position = new Vector3(-Screen.width-100, Screen.height+100,0);
    }


    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span && move == false)
            MoveAstronaut();


        if (move == true)
        {
            float step = speed * Time.deltaTime;
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, endPos, step);

            Vector3 wavePos = this.gameObject.transform.position;
            if (isUpWave == true) wavePos.y += waveSpan;
            if (isUpWave == false) wavePos.y -= waveSpan;
            waveCount += waveSpan;
            this.gameObject.transform.position = wavePos;

            if (waveCount > waveMax)
            {
                waveCount = 0f;
                isUpWave = !isUpWave;
            }


            if (this.gameObject.transform.position.x == endPos.x)
            {
                move = false;
                currentTime = 0f;
            }
        }

    }





    void MoveAstronaut()
    {
        //スタート地点、ゴール地点、右左どちらからかを決める。
        float startYPos = GetRandomValue();
        float finishYPos = GetRandomValue();
        bool moveFromRight = RandomBool();
        bool withRocket = RandomBool();


        if (moveFromRight == true)
        {
            startPos = new Vector3(rightXPos, startYPos, 0);
            endPos = new Vector3(leftXPos, finishYPos, 0);
        }
        else
        {
            startPos = new Vector3(leftXPos, startYPos, 0);
            endPos = new Vector3(rightXPos, finishYPos, 0);
        }

        this.gameObject.transform.position = startPos;




        //スタート地点からゴール地点までの角度を求める
        float dx = endPos.x - startPos.x;
        float dy = endPos.y - startPos.y;
        float rad = Mathf.Atan2(dy, dx);
        float angle = rad * Mathf.Rad2Deg;

        //求めた角度を　rotation.zに代入し、進行方向に頭を向かせる
        float roatationZ;
        if (moveFromRight == true) roatationZ = angle - 180f;
        else roatationZ = 180f - angle;



        if (moveFromRight == true && withRocket == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = astronaut1;
            Vector3 ang = this.transform.localEulerAngles; //いったんそのオブジェの角度すべてをvector変数に入れる
            ang.z = 0f; //X軸にのみ任意の値を代入
            ang.x = 0f;
            this.transform.localEulerAngles = ang;
        }
        if (moveFromRight == false && withRocket == false)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = astronaut1;
            Vector3 ang = this.transform.localEulerAngles; //いったんそのオブジェの角度すべてをvector変数に入れる
            ang.z = 180f; //X軸にのみ任意の値を代入
            ang.x = 180f;
            this.transform.localEulerAngles = ang;
        }
        if (moveFromRight == true && withRocket == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = astronaut2;
            Vector3 ang = this.transform.localEulerAngles; //いったんそのオブジェの角度すべてをvector変数に入れる
            ang.z = roatationZ; //X軸にのみ任意の値を代入
            ang.x = 0;
            ang.y = 0;
            this.transform.localEulerAngles = ang;
        }
        if (moveFromRight == false && withRocket == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = astronaut2;
            Vector3 ang = this.transform.localEulerAngles; //いったんそのオブジェの角度すべてをvector変数に入れる
            ang.z = roatationZ; //X軸にのみ任意の値を代入
            ang.x = 180f;
            ang.y = 0;
            this.transform.localEulerAngles = ang;
        }


        move = true;

    }


    float GetRandomValue()
    {
        return Random.Range(bottomYPos, topYPos);
    }


    bool RandomBool()
    {
        return Random.Range(0, 2) == 0;
    }

}
