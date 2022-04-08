using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMover : MonoBehaviour
{



    float span = 180f; //値の数字秒ごとに宇宙飛行士が飛ぶ
    float currentTime = 0f;

    Vector3 startPos;
    Vector3 endPos;

    float speed = 20f;//20

    bool move = false;

    float bottomYPos = -Screen.height / 2 + Screen.height / 8;
    float topYPos = Screen.height / 2 - Screen.height / 8;
    float rightXPos;
    float leftXPos;

    float XPos = 0;



    float waveSpan = 0.03f;
    float waveMax = 20f;
    float waveCount = 0f;
    bool isUpWave = true;

    bool moveStraight;

    Sprite UFO1; //左から右へ移動
    Sprite UFO2; //右から左へ移動
    Sprite UFO3; //左から右へ移動
    Sprite UFO4; //右から左へ移動




    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = new Vector3(-Screen.width-100, Screen.height+100, 0);
        UFO1 = Resources.Load<Sprite>("Image/Space/UFO1");
        UFO2 = Resources.Load<Sprite>("Image/Space/UFO2");
        UFO3 = Resources.Load<Sprite>("Image/Space/UFO3");
        UFO4 = Resources.Load<Sprite>("Image/Space/UFO4");

        if (Screen.width > Screen.height)
            XPos = Screen.width;
        else
            XPos = Screen.height;
        rightXPos = XPos + 100;
        leftXPos = -XPos - 100;

    }



    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span && move == false)
            MoveUFO();


        if (move == true && moveStraight == false)
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




        if (move == true && moveStraight == true)
        {
            float step = speed * Time.deltaTime;
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, endPos, step);

            if (this.gameObject.transform.position == endPos)
            {
                move = false;
                currentTime = 0f;
            }
        }

    }




    void MoveUFO()
    {
        //スタート地点、ゴール地点、右左どちらからかを決める。
        float startYPos = GetRandomValue();
        float finishYPos = GetRandomValue();
        bool moveFromRight = RandomBool();
        Sprite UFO = GetRandomUFO();
        moveStraight = RandomBool();
        if (moveStraight == true)
            speed = 200f;
        if (moveStraight == false)
            speed = 40f;




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
        this.gameObject.GetComponent<SpriteRenderer>().sprite = UFO;


        move = true;

    }


    float GetRandomValue()
    {
        return Random.Range(bottomYPos, topYPos);
    }

    Sprite GetRandomUFO()
    {
        int num = Random.Range(1, 5 + 1);

        Sprite UFO = null;

        switch(num){
            case 1:
                UFO = UFO1;
                break;
            case 2:
                UFO = UFO2;
                break;
            case 3:
                UFO = UFO3;
                break;
            case 4:
                UFO = UFO4;
                break;
        }

        return UFO;
    }



    bool RandomBool()
    {
        return Random.Range(0, 2) == 0;
    }

}
