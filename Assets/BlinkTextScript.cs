using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkTextScript : MonoBehaviour
{
    public Text text;
    public float blinkTime;
    public float fadeTime;

    private bool isFadingOut = false;

    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        float startTime = Time.time;
        float elapsedTime = 0f;
        float startAlpha = text.color.a;
        float endAlpha = 0f;
        
        while (true)
        {
            if (isFadingOut)
            {
                // Fade out
                elapsedTime = Time.time - startTime;
                float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeTime);
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

                if (elapsedTime >= fadeTime)
                {
                    isFadingOut = false;
                    startTime = Time.time;
                    elapsedTime = 0f;
                    startAlpha = endAlpha;
                    endAlpha = 1f - endAlpha;
                }
            }
            else
            {
                // Fade in
                elapsedTime = Time.time - startTime;
                float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeTime);
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

                if (elapsedTime >= fadeTime)
                {
                    isFadingOut = true;
                    startTime = Time.time;
                    elapsedTime = 0f;
                    startAlpha = endAlpha;
                    endAlpha = 1f - endAlpha;
                }
            }

            yield return null;
        }
    }
}
