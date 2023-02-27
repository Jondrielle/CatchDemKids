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
    public int[] scores = new int[10];
    public Queue<int> scores1 = new Queue<int>();
    int elementCounter = 0;

    //gameScoreText.text += " " + gameScore; 

    void Start(){
        // LOAD HIGHSCORE
        //Save();
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
        if(gameScore > highScore && !(scores1.Contains(gameScore)) ){
            highScore = gameScore;
            highScoreText.text = "HighScore \n" + highScore;
            newHighScoreText.text = $"New HighScore:\n {highScore}";
            AddScore(highScore);
            Save();
            Load();
        }
        else
        {
            highScoreText.text = "HighScore \n" + scores[scores.Length - 1];
            newHighScoreText.text = $"New HighScore:\n";
        }
    }

    // SAVE HIGHSCORE COUNT
    public void Save(){
        BinaryFormatter bF = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/ScoreConatiner.dat",FileMode.Create);
        ScoreContainer scoreContainer = new ScoreContainer();
        //scoreContainer.highScores.Clear();
        scoreContainer.highScores = scores1;
        bF.Serialize(file,scoreContainer);
        file.Close();
    }

    //LOAD HIGHSCORE 
    public void Load(){
        if(File.Exists(Application.persistentDataPath + "/ScoreConatiner.dat")){
            BinaryFormatter bF = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/ScoreConatiner.dat",FileMode.Open);
            ScoreContainer scoreContainer = (ScoreContainer)bF.Deserialize(file);
            Array.Clear(scores,0,scores.Length);
            scoreContainer.highScores.CopyTo(scores, 0);
            scores1 = scoreContainer.highScores;
            Array.Sort(scores);
            file.Close();
        }
    }


    public void AddScore(int newScore)
    {
        if (scores1.Count < 10)
        {
            scores1.Enqueue(newScore);
        }
        else
        {
            scores1.Dequeue();
            scores1.Enqueue(newScore);
        }
    }

}

[Serializable]
public class ScoreContainer{
    public int highScore;
    [SerializeField] public Queue<int> highScores = new Queue<int>();
}
