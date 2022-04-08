using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


//namespaceは使用しなくても良い。
//データ化したいクラスの上に、[System.Serializable] を書くと、
//そのクラスの変数が全てデータになる。
//MonoBehaviourは記入してはいけない。
//せーぶ、ろーどしたいclassをどこかで一度だけインスタンス化する。

    [System.Serializable]
    public class PreferenceData
    {

        public List<GameScore> score;

        public bool isSounding = true;

        public int playmatDesignNum = 1;

    }


    [System.Serializable]
    public class GameScore
    {

        public float score = 0;
    }

