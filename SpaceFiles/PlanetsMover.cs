using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsMover : MonoBehaviour
{


    GameObject sun;
    GameObject suisei; 
    GameObject kinsei; 
    GameObject earth; 
    GameObject moon; 
    GameObject mars; 
    GameObject mokusei;
    GameObject dosei; 
    GameObject tenousei;
    GameObject kaiousei;

    GameObject center;
    GameObject me;

    float speed = 5f;

    float suiseiCycle = 4.1f;
    float kinseiCycle = 1.6f;
    float earthCycle = 1f;
    float moonCycle = 13.5f;
    float marsCycle = 0.53f;
    float mokuseiCycle = 0.2f;//0.08f;
    float doseiCycle = 0.3f; //0.03f;
    float tenouseiCycle = 0.1f; //0.01f;
    float kaiouseiCycle = 0.25f; //0.06f;


    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.Find("Sun");
        suisei = GameObject.Find("Suisei");
        kinsei = GameObject.Find("Kinsei");
        earth = GameObject.Find("Earth");
        moon = GameObject.Find("Moon");
        mars = GameObject.Find("Mars");
        mokusei = GameObject.Find("Mokusei");
        dosei = GameObject.Find("Dosei");
        tenousei = GameObject.Find("Tenousei");
        kaiousei = GameObject.Find("Kaiousei");


        if (transform.name == "Moon")
            center = earth;
        else
            center = sun;


        switch (transform.name)
        {
            case "Earth":
                me = earth;
                speed = speed * earthCycle;
                break;
            case "Moon":
                me = moon;
                speed = speed * moonCycle;
                break;
            case "Suisei":
                me = suisei;
                speed = speed * suiseiCycle;
                break;
            case "Kinsei":
                me = kinsei;
                speed = speed * kinseiCycle;
                break;
            case "Mars":
                me = mars;
                speed = speed * marsCycle;
                break;
            case "Mokusei":
                me = mokusei;
                speed = speed * mokuseiCycle;
                break;
            case "Dosei":
                me = dosei;
                speed = speed * doseiCycle;
                break;
            case "Tenousei":
                me = tenousei;
                speed = speed * tenouseiCycle;
                break;
            case "Kaiousei":
                me = kaiousei;
                speed = speed * kaiouseiCycle;
                break;

        }
    }



    // Update is called once per frame
    void Update()
    {
        //RotateAround(円運動の中心,進行方向,速度)
        transform.RotateAround(center.transform.position,
        transform.forward, speed * Time.deltaTime);
    }
}
