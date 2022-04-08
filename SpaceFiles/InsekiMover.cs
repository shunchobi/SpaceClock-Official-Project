using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsekiMover : MonoBehaviour
{


    Vector3 startPos;
    Vector3 endPos;

    float speed = 100f;

    bool move = false;

    float bottomYPos = -Screen.height / 2 + Screen.height / 8;
    float topYPos = Screen.height / 2 - Screen.height / 8;
    float rightXPos;
    float leftXPos;

    float XPos = 0;

    float span = 50f; //値の数字秒ごとに隕石が飛ぶ
    float currentTime = 0f;



    private void Start()
    {
        this.gameObject.transform.position = new Vector3(-Screen.width-100, Screen.height+100, 0);
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
            MoveInseki();
        

            if (move == true)
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




    void MoveInseki()
    {
        //スタート地点、ゴール地点、右左どちらからかを決める。
        float startYPos = GetRandomValue();
        float finishYPos = GetRandomValue();
        bool moveFromRight = RandomBool();

        if(moveFromRight == true)
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
        if (moveFromRight == true) roatationZ = 180f + angle;
        else roatationZ = -180f + angle;
        Vector3 ang = this.transform.localEulerAngles; //いったんそのオブジェの角度すべてをvector変数に入れる
        ang.z = roatationZ; //X軸にのみ任意の値を代入
        transform.localEulerAngles = ang;

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
