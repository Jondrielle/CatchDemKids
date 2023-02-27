using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class ScoreList : MonoBehaviour
{

    public static ScoreList instance {get; private set;}

    [SerializeField] private Queue<int> scoresList = new Queue<int>();
    public int[] scores = new int[10];


    void Awake(){
        if(instance == null)
            instance = this;
        else
            Destroy(this);
    
        DontDestroyOnLoad(this.gameObject);
    }

    void Start(){
        // LOAD HIGHSCORE DATA
        Load();
        PrintScore();
    }


    // PRINTS HIGHSCORE LIST
    public void PrintScore(){

        print("-----SCORELIST-----");

        foreach(int score in scores)
        {
            print( $"{score} \n" );
        }
        

        print("----ENDOFSCORELIST----");
    }


    //LOAD HIGHSCORE 
    public void Load(){
        if (File.Exists(Application.persistentDataPath + "/ScoreConatiner.dat"))
        {
            BinaryFormatter bF = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/ScoreConatiner.dat", FileMode.Open);
            ScoreContainer scoreContainer = (ScoreContainer)bF.Deserialize(file);
            Array.Clear(scores, 0, scores.Length);
            scoreContainer.highScores.CopyTo(scores, 0);
            scoresList = scoreContainer.highScores;
            Array.Sort(scores);
            file.Close();
        }
    }

}

[Serializable]
public class HighScoreContainer{
    public Queue<int> scores = new Queue<int>();
    public int[] newArray = new int[10];

}
