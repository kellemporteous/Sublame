using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI_ResetButton : MonoBehaviour {

	// Use this for initialization
	void Start (){

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        // Reload the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
