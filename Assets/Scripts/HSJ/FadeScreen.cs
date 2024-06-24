using System.Collections;
using UnityEngine;

namespace HSJ
{
    public class FadeScreen : MonoBehaviour
    {
        public bool fadeOnStart { get; private set;}
        public float fadeDuration { get; private set;}
        public Color fadeColor { get; private set; }

        private Renderer render;

        private void Awake()
        {
            fadeOnStart = true;
            fadeDuration = 2.0f;
            render = GetComponent<Renderer>();
        }

        private void Start()
        {
            if (fadeOnStart)
            {
                FadeIn();
            }
        }

        public void FadeIn()
        {
            Fade(1.0f, 0.0f);
        }

        public void FadeOut()
        {
            Fade(0.0f, 1.0f);
        }

        public void Fade(float alphaIn, float alphaOut)
        {
            StartCoroutine(FadeRoutine(alphaIn, alphaOut));
        }

        private IEnumerator FadeRoutine(float alphaIn, float alphaOut)
        {
            float timer = 0.0f;
            while (timer <= fadeDuration)
            {
                Color newColor = fadeColor;
                newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

                render.material.SetColor("_Color", newColor);

                timer += Time.deltaTime;
                yield return null;
            }

            Color newColor2 = fadeColor;
            newColor2.a = alphaOut;

            render.material.SetColor("_Color", newColor2);

            gameObject.SetActive(false);
        }
    }
}
