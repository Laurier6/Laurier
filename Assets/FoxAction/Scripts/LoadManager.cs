using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;
    [SerializeField] private Animator LoadUI;
    //フェイドアウト開始から実際にシーン遷移開始までの時間
    [Header("シーン遷移時間")]
    [Range(0.0f, 5.0f)]
    public float transitionTime = 1f;
    //フェイドアウト開始までの遅延時間
    [Header("遅延実行")]
    [Range(0.0f, 5.0f)]
    public float DelayActiveTime = 0.5f;

    //非同期ロード用
    private AsyncOperation LoadOperation;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void LoadScene()
    {
        StartCoroutine(LoadLevel());
    }

    // 内部用ロードコルーチン
    private IEnumerator LoadLevel()
    {
        //遅延
        yield return new WaitForSeconds(DelayActiveTime);
        //アニメーション再生
        LoadUI.SetFloat("Speed", 1);
        yield return new WaitForSeconds(transitionTime);
        //ロード開始
        StartCoroutine(LoadAsync());
    }

    // 非同期ロード処理
    private IEnumerator LoadAsync()
    {
        LoadOperation = SceneManager.LoadSceneAsync("GameScene");
        //LoadOperation.allowSceneActivation = TransitionAuto_LoadFinish;

        while (!LoadOperation.isDone)
        {
            InLoading();
            yield return null;
        }

        LoadUI.SetFloat("Speed", -1);

    }

    //ロード画面内処理
    private void InLoading()
    {
        if (!LoadOperation.allowSceneActivation)
        {
             LoadOperation.allowSceneActivation = true;
        }
    }

}

