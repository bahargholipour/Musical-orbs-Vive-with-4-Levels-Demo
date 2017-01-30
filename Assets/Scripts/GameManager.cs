using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
	public string winSequence = "CA";
	private string currentSequence = "";
	
	public string nextLevel;


	// Use this for initialization
	void Start () {

        if (gm == null)
            gm = this.gameObject.GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (currentSequence.Length > 0)
        {
            Debug.Log(currentSequence);
        }
        if (Time.time > 10)
            NextLevel();
    }

    public void UpdateSequence(string character) {
		currentSequence += character;
        Debug.Log(currentSequence);
        if (currentSequence.Equals(winSequence, StringComparison.Ordinal)) {
            Debug.Log("equal");
		  NextLevel();
		} else if (!winSequence.StartsWith(currentSequence))
        {
            Debug.Log("Reset");
            currentSequence = "";
        }
	}

	private void NextLevel ()
	{
		// we are just loading the specified next level (scene)
		  SceneManager.LoadScene (nextLevel);		
	}	
}
