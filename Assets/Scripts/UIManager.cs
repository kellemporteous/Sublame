using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public UI_ScoreDisplay scoreDisplay;

    public static UIManager Instance;

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetScore(int newScore)
    {
        scoreDisplay.SetScore(newScore);
    }
}
