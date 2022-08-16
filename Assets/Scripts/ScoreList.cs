using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class ScoreList : MonoBehaviour
{

    public static ScoreList instance {get; private set;}

    [SerializeField] private Queue<int> scores = new Queue<int>();
    [SerializeField] private int[] newArray = new int[10];

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
    }

    // ADDS NEW SCORE TO SCORELIST
    public void AddScore(int newScore){
        if(scores.Count < 10){
            scores.Enqueue(newScore);
        }
        else{
            scores.Dequeue();
            scores.Enqueue(newScore);
        }
    }

    // PRINTS HIGHSCORE LIST
    public void PrintScore(){

        print("-----SCORELIST-----");

        newArray = scores.ToArray();
        Save();

        foreach(int score in newArray){
            print(score + "\n");
        }

        print("----ENDOFSCORELIST----");
    }


    // SAVE HIGHSCORE COUNT
    public void Save(){
        BinaryFormatter bF = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/HighScoreConatiner.dat",FileMode.Create);
        HighScoreContainer highScoreContainer = new HighScoreContainer();
        newArray.CopyTo(highScoreContainer.newArray, 0);
        bF.Serialize(file,highScoreContainer);
        file.Close();
    }

    //LOAD HIGHSCORE 
    public void Load(){
        if(File.Exists(Application.persistentDataPath + "/HighScoreConatiner.dat")){
            BinaryFormatter bF = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/HighScoreConatiner.dat",FileMode.Open);
            HighScoreContainer highScoreContainer = (HighScoreContainer)bF.Deserialize(file);
            file.Close();
            highScoreContainer.newArray.CopyTo(newArray, 0);
        }
    }
}

[Serializable]
public class HighScoreContainer{
    public Queue<int> scores = new Queue<int>();
    public int[] newArray = new int[10];

}
