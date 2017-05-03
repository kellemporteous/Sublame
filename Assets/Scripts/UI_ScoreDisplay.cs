using UnityEngine;
using System.Collections;

public class UI_ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetScore(int newScore)
    {
        UnityEngine.UI.Text text = GetComponent<UnityEngine.UI.Text>();

        text.text = "Score: " + newScore.ToString();
    }
}
