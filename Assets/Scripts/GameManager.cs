using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
	public string winSequence = "CA";
	private string currentSequence = "";
	
	public string nextLevel;
	public int maxTime = 10;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > maxTime) {
			NextLevel();
		}
	}

	public void UpdateSequence(string character) {
		currentSequence += character;
		if (currentSequence.Equals(winSequence, StringComparison.Ordinal)) {
		  NextLevel();
		} else if (winSequence.StartsWith(currentSequence)) {
          return;
		} else {
			currentSequence = "";
		}
	}

	private void NextLevel ()
	{
		// we are just loading the specified next level (scene)
		  Application.LoadLevel (nextLevel);
		
	}	
}
