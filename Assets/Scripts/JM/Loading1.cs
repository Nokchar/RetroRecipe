using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Loading1 : MonoBehaviour
{
    public CanvasGroup Fade_img;
    float fadeDuration = 2; //암전되는 시간
    public GameObject Loading2;
    public Text Loading_text; //퍼센트 표시할 텍스트


    IEnumerator LoadScene(string sceneName)
    {
        Loading2.SetActive(true); //로딩 화면을 띄움

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false; //퍼센트 딜레이용

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
                    async.allowSceneActivation = true; //씬 전환 준비 완료
                }
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90) past_time = 0;
            }
            Loading_text.text = percentage.ToString("0") + "%"; //로딩 퍼센트 표기
        }
    }
    



    public void ChangeScene()
    {
        Fade_img.DOFade(1, fadeDuration)
        .OnStart(() => {
            Fade_img.blocksRaycasts = true; //아래 레이캐스트 막기
        })
        .OnComplete(() => {
            StartCoroutine("LoadScene", "Intro"); /// 씬 로드 코루틴 실행 ///
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
        SceneManager.sceneLoaded += OnSceneLoaded; // 이벤트에 추가
       


    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 이벤트에서 제거*
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
