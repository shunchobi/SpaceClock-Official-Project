using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSizeChanger : MonoBehaviour
{

    static GameObject backGround;

    static float iphoneLandScale = 110;
    static float ipadLandScale = 70;
    static float portScale = 50;


    static float iphoneLandBXCSizeX = 9;
    static float iphoneLandBXCSizeY = 20;

    static float ipadLandBXCSizeX = 15;
    static float ipadLandBXCSizeY = 25;

    static float iphonePortBXCSizeX = 15;
    static float iphonePortBXCSizeY = 20;

    static float ipadPortBXCSizeX = 20;
    static float ipadPortBXCSizeY = 20;


    public static void ChangeToPort_iPhone()
    {
        GameObject.Find("BackGround").transform.rotation = Quaternion.Euler(0, 0, 0);
        GameObject.Find("BackGround").transform.localScale = new Vector3(portScale, portScale,0);
        BoxCollider2D boxCollider2D = GameObject.Find("BackGround").GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(iphonePortBXCSizeX, iphonePortBXCSizeY);
    }


    public static void ChangeToPort_iPad()
    {
        GameObject.Find("BackGround").transform.rotation = Quaternion.Euler(0, 0, 0);
        GameObject.Find("BackGround").transform.localScale = new Vector3(portScale, portScale, 0);
        BoxCollider2D boxCollider2D = GameObject.Find("BackGround").GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(ipadPortBXCSizeX, ipadPortBXCSizeY);

    }



    public static void ChangeToLand_iPhone()
    {
        GameObject.Find("BackGround").transform.rotation = Quaternion.Euler(0, 0, 90);
        GameObject.Find("BackGround").transform.localScale = new Vector3(iphoneLandScale, iphoneLandScale, 0);
        BoxCollider2D boxCollider2D = GameObject.Find("BackGround").GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(iphoneLandBXCSizeX, iphoneLandBXCSizeY);

    }



    public static void ChangeToLand_ipad()
    {
        GameObject.Find("BackGround").transform.rotation = Quaternion.Euler(0, 0, 90);
        GameObject.Find("BackGround").transform.localScale = new Vector3(ipadLandScale, ipadLandScale, 0);
        BoxCollider2D boxCollider2D = GameObject.Find("BackGround").GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(ipadLandBXCSizeX, ipadLandBXCSizeY);

    }



}
