using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour
{
    public Image FadeImg;
    public float fadeSpeed = 0.5f;
	private bool fadeIn = true;


    void Awake()
    {
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


    void FadeToBlack()
    {
        // Lerp the colour of the image between itself and black.

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


    public void EndSceneRoutine()
    {
        // Make sure the RawImage is enabled.
        FadeImg.enabled = true;
		FadeImg.color = Color.white;
		FadeImg.canvasRenderer.SetAlpha( 0.0f );
		FadeImg.CrossFadeAlpha(100,10f,true);
    }

    public void EndScene()
    {
        fadeIn = false;
       EndSceneRoutine();
    }
}   