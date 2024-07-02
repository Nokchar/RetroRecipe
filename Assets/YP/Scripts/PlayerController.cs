using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Color updateColor;
    private Transform destination;

    public void MovetoMakingView()
    {
        destination = ObjectManager.Instance.makingView.transform;
        StartCoroutine(FadeAndMove());
    }

    public void MovetoCstmrView()
    {
        destination = ObjectManager.Instance.cstmrView.transform;
        StartCoroutine(FadeAndMove());
    }

    private IEnumerator FadeAndMove()
    {
        //yield return StartCoroutine(ovrScreenFade.Fade(0, 1));
        //yield return StartCoroutine(FadeOut());
        this.transform.position = destination.position;
        this.transform.rotation = destination.rotation;
        yield return null;
        //yield return StartCoroutine(FadeIn());
        //yield return StartCoroutine(ovrScreenFade.Fade(1.0f, 0.0f));
    }

    //private IEnumerator FadeOut()
    //{
    //    float elapsedTime = 0f;
    //    float fadeDuration = 1f;
    //    while (elapsedTime < fadeDuration)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        updateColor.a = Mathf.Clamp01(elapsedTime / fadeDuration);
    //        ObjectManager.Instance.fadeImg.GetComponent<Image>().color = updateColor;
    //        Canvas.ForceUpdateCanvases();
    //        yield return null;
    //    }
    //}

    //private IEnumerator FadeIn()
    //{
    //    float elapsedTime = 0f;
    //    float fadeDuration = 1f;
    //    while (elapsedTime < fadeDuration)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        updateColor.a = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
    //        ObjectManager.Instance.fadeImg.GetComponent<Image>().color = updateColor;
    //        Canvas.ForceUpdateCanvases();
    //        yield return null;
    //    }
    //}
}
