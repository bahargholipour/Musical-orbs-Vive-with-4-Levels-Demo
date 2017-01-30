using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
	public string winSequence = "CA";
	public string currentSequence = "";
	
	public string levels[] = {""MusicalOrbs","FireWatch"};

	private string nextLevel = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void UpdateSequence(string character) {
		currentSequence += character;
		if (currentSequence.Equals(winSequence, StringComparison.Ordinal)) {
			NextLevel();
		}

	}

	public void NextLevel ()
	{
		// we are just loading the specified next level (scene)
		Application.LoadLevel (levels[nextLevel]);
	}	
}
