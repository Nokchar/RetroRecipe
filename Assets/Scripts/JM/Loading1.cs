using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Loading1 : MonoBehaviour
{
    public CanvasGroup Fade_img;
    float fadeDuration = 2; //�����Ǵ� �ð�
    public GameObject Loading2;
    public Text Loading_text; //�ۼ�Ʈ ǥ���� �ؽ�Ʈ


    IEnumerator LoadScene(string sceneName)
    {
        Loading2.SetActive(true); //�ε� ȭ���� ���

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false; //�ۼ�Ʈ �����̿�

        float past_time = 0;
        float percentage = 0;

        while (!(async.isDone))
        {
            yield return null;

            past_time += Time.deltaTime;

            if (percentage >= 90)
            {
                percentage = Mathf.Lerp(percentage, 100, past_time);

                if (percentage == 100)
                {
                    async.allowSceneActivation = true; //�� ��ȯ �غ� �Ϸ�
                }
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90) past_time = 0;
            }
            Loading_text.text = percentage.ToString("0") + "%"; //�ε� �ۼ�Ʈ ǥ��
        }
    }
    



    public void ChangeScene()
    {
        Fade_img.DOFade(1, fadeDuration)
        .OnStart(() => {
            Fade_img.blocksRaycasts = true; //�Ʒ� ����ĳ��Ʈ ����
        })
        .OnComplete(() => {
            StartCoroutine("LoadScene", "Intro"); /// �� �ε� �ڷ�ƾ ���� ///
        });
        


       
    }
    
    public static Loading1 Instance
    {
        get
        {
            return instance;
        }
    }
    private static Loading1 instance;

    void Start()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded; // �̺�Ʈ�� �߰�
       


    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // �̺�Ʈ���� ����*
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Fade_img.DOFade(0, fadeDuration)
        .OnStart(() =>
        {
            Loading2.SetActive(false);
        })
        .OnComplete(() =>
        {
            Fade_img.blocksRaycasts = false;
        });
    }




}
