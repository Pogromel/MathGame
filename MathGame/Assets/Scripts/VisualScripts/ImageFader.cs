using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFader : MonoBehaviour
{
    [SerializeField] private SpriteRenderer image; //Source of the X,Y graph sprite
    [SerializeField] private float fadeStartDelay = 120f; //timer after fading will start working
    [SerializeField] private float fadeDuration = 60f; //how long for sprite to completly dissapear 

    private void Start()
    {
        
        StartCoroutine(FadeOutWithDelay());
    }

    private IEnumerator FadeOutWithDelay()
    {
        
        yield return new WaitForSeconds(fadeStartDelay);

        float elapsedTime = 0f;
        Color color = image.color;

        
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1 - elapsedTime / fadeDuration);
            image.color = color;
            yield return null;
        }

        
        color.a = 0;
        image.color = color;
    }
}