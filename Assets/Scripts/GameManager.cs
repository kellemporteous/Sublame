using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public bool InvertY = false;
    private int score = 0;

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;

        score = PlayerPrefs.GetInt(PrefKeys.Player_HighScore, 0);

        List<int> highScores = new List<int>();


        int numHighScores = PlayerPrefs.GetInt("Player.NumHighScores", 0);
        for (int index = 0; index < numHighScores; ++index)
        {
            highScores.Add(PlayerPrefs.GetInt("Player.Score_" + index, 0));
        }
    }


    public void AdjustScore(int deltaScore)
    {
        score += deltaScore;
        UIManager.Instance.SetScore(score);

        PlayerPrefs.SetInt(PrefKeys.Player_HighScore, score);
        PlayerPrefs.Save();
    }

	// Use this for initialization
	void Start () {
        UIManager.Instance.SetScore(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
