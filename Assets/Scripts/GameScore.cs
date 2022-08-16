using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    [Header("GameScore Variables")]
    public int gameScore = 0;
    private const int zeroValue = 0;
    public TextMeshProUGUI gameScoreText;
    

    [Space(10)]
    [Header("HighScore Variables")]
    public int highScore = 0;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newHighScoreText;

    //gameScoreText.text += " " + gameScore; 

    void Start(){
        // LOAD HIGHSCORE
        Load();
        gameScoreText.text = "Score " + gameScore;
        highScoreText.text = "HighScore " + highScore;
    }

    // UPDATES GAMESCORE AND GAMESCORETEXT
    public void UpdateScore()
    {
        gameScore += 100;
        gameScoreText.text = "Score " + gameScore;
    }

    // CHECKS IF SCORE MADE IT TO THE LEADERBOARD
    public void LeaderBoardCheck(){
        //Save();
        if(gameScore > highScore){
            print("New Highscore");
            highScore = gameScore;
            highScoreText.text = "HighScore \n" + highScore;
            newHighScoreText.text = $"New HighScore:\n {highScore}";
            //ScoreList.instance.AddScore(gameScore);
            Save();
        }
    }

    // SAVE HIGHSCORE COUNT
    public void Save(){
        BinaryFormatter bF = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/ScoreConatiner.dat",FileMode.Create);
        ScoreContainer scoreContainer = new ScoreContainer();
        scoreContainer.highScore = gameScore;
        bF.Serialize(file,scoreContainer);
        file.Close();
    }

    //LOAD HIGHSCORE 
    public void Load(){
        if(File.Exists(Application.persistentDataPath + "/ScoreConatiner.dat")){
            BinaryFormatter bF = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/ScoreConatiner.dat",FileMode.Open);
            ScoreContainer scoreContainer = (ScoreContainer)bF.Deserialize(file);
            file.Close();
            highScore = scoreContainer.highScore;
        }
    }

    public void CallPrint(){
        ScoreList.instance.PrintScore();
    }
}

[Serializable]
public class ScoreContainer{
    public int highScore;
}
