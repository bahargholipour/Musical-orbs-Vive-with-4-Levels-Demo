using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
    public enum PuzzleType {Time, Music, Collect};
    public PuzzleType puzzle = PuzzleType.Time;
	public string musicPuzzle = "CA";
    public string collectPuzzle = "ABC";
    public int timePuzzle = 20;

	public string nextLevel;

	private string currentSequence = "";
    private bool puzzleSolved = false;

	void Awake () {

        if (gm == null)
            gm = this.gameObject.GetComponent<GameManager>();
    }

	void Update () {
        if (puzzle == PuzzleType.Time) {
            UpdateTimePuzzle();
        }
        if (puzzleSolved) {
            NextLevel();
        }
    }

    public void UpdateMusicPuzzle(string character) {
        if (puzzle != PuzzleType.Music) {
            return;
        }
		currentSequence += character;
        Debug.Log(currentSequence);
        if (currentSequence.Equals(musicPuzzle, StringComparison.Ordinal)) {
            Debug.Log("equal");
            puzzleSolved = true;
		} else if (!musicPuzzle.StartsWith(currentSequence))
        {
            Debug.Log("Reset");
            currentSequence = "";
        }
	}

    public void UpdateCollectPuzzle(string character) {
        if (puzzle != PuzzleType.Collect) {
            return;
        }
		currentSequence += character;
        Debug.Log(currentSequence);
        bool collected = true;
        foreach (char c in collectPuzzle) {
            if (!currentSequence.Contains("" + c)) {
                collected = false;
                break;
            }
        }
        puzzleSolved = collected;
	}

    public void UpdateTimePuzzle() {
        if (Time.time > timePuzzle) {
            puzzleSolved = true;
        }
	}

	private void NextLevel ()
	{
        if (nextLevel.Length > 0) {
		// we are just loading the specified next level (scene)
		SceneManager.LoadScene (nextLevel);		
        }
	}
}
