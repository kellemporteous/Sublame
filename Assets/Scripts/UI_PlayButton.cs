using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI_PlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        // Reload the current levels
        SceneManager.LoadScene("Level1");
    }
}
