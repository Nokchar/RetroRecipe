using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HSJ
{
    public class UIManager : Singleton<UIManager>
    {
        public GameObject bookButton;
        public FadeScreen fadeScreen;
        private Image slotImage;
        private Button newButton;
        private Button saveButton;
        private Button loadButton;
        private Button backButton;
        private Button optionsButton;
        private Button quitButton;

        private void Start()
        {
            newButton.onClick.AddListener(OnClickNew);
            saveButton.onClick.AddListener(OnClickSave);
            loadButton.onClick.AddListener(OnClickLoad);
            backButton.onClick.AddListener(OnClickBack);
            optionsButton.onClick.AddListener(OnClickOptions);
            quitButton.onClick.AddListener(OnClickQuit);
        }

        public void OnClickNew()
        {
            SoundManager.Instance.PlaySoundEffect("Correct");

            StartCoroutine(OnClickStartRoutine());
        }

        private IEnumerator OnClickStartRoutine()
        {
            fadeScreen.gameObject.SetActive(true);
            fadeScreen.FadeOut();

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            asyncOperation.allowSceneActivation = false;

            float timer = 0.0f;
            while (timer <= fadeScreen.fadeDuration && !asyncOperation.isDone)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            asyncOperation.allowSceneActivation = true;
        }

        public void OnClickSave()
        {
            SoundManager.Instance.PlaySoundEffect("Click");
            DataManager.Instance.Save();
        }

        public void OnClickLoad()
        {
            SoundManager.Instance.PlaySoundEffect("Click");
            slotImage.gameObject.SetActive(true);
        }

        public void OnClickBack()
        {
            SoundManager.Instance.PlaySoundEffect("Back");
            slotImage.gameObject.SetActive(false);
        }

        public void OnClickOptions()
        {
            SoundManager.Instance.PlaySoundEffect("Click");
        }

        public void OnClickQuit()
        {
#if UNITY_EDITOR
            SoundManager.Instance.PlaySoundEffect("Click");
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
