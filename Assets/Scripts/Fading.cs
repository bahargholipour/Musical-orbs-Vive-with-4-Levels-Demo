using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour
{
    public Image FadeImg;
    public float fadeSpeed = 0.5f;
	private bool fadeIn = true;


    void Start()
    {
	    fadeIn = true;
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        if (fadeIn)
            StartFadeIn();
    }


    void FadeToClear()
    {
        // Lerp the colour of the image between itself and transparent.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeOut()
    {
        // Lerp the colour of the image between itself and black.
        FadeImg.color = Color.Lerp(FadeImg.color, Color.white, fadeSpeed * Time.deltaTime);
    }


    void StartFadeIn()
    {
        // Fade the texture to clear.
        FadeToClear();

        // If the texture is almost clear...
        if (FadeImg.color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the RawImage.
            FadeImg.color = Color.clear;
            FadeImg.enabled = false;

            // The scene is no longer starting.
            fadeIn = false;
        }
    }

    public IEnumerator EndSceneRoutine(string SceneNumber)
    {
        // Make sure the RawImage is enabled.
        FadeImg.enabled = true;
        do	
        {
            // Start fading towards black.
            FadeOut();

            // If the screen is almost black...
            if (FadeImg.color.a >= 0.95f)
            {
                // ... reload the level
                SceneManager.LoadScene(SceneNumber);
                yield break;
            }
            else
            {
                yield return null;
            }
        } while (true);
    }

    public void EndScene(string nextLevel)
    {
        fadeIn = false;
		if (nextLevel.Length > 0) {
        	StartCoroutine("EndSceneRoutine", nextLevel);
		}
    }
}   