using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField] Image image;

    public void FadeBlack()
    {
        StartCoroutine(Fade(0, 1));
    }

    public void FadeFromBlack()
    {
        StartCoroutine(Fade(1,0));
    }

    IEnumerator Fade(float start, float end)
    {
        float time = 0f;
        Color c = image.color;

        while (time < 1f) {
            time += Time.deltaTime;
            c.a = Mathf.Lerp(start, end, time / 1);
            image.color = c;
            yield return null;
        }

        c.a = end;
        image.color = c;
    }
}