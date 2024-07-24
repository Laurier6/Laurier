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
    //�t�F�C�h�A�E�g�J�n������ۂɃV�[���J�ڊJ�n�܂ł̎���
    [Header("�V�[���J�ڎ���")]
    [Range(0.0f, 5.0f)]
    public float transitionTime = 1f;
    //�t�F�C�h�A�E�g�J�n�܂ł̒x������
    [Header("�x�����s")]
    [Range(0.0f, 5.0f)]
    public float DelayActiveTime = 0.5f;

    //�񓯊����[�h�p
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

    // �����p���[�h�R���[�`��
    private IEnumerator LoadLevel()
    {
        //�x��
        yield return new WaitForSeconds(DelayActiveTime);
        //�A�j���[�V�����Đ�
        LoadUI.SetFloat("Speed", 1);
        yield return new WaitForSeconds(transitionTime);
        //���[�h�J�n
        StartCoroutine(LoadAsync());
    }

    // �񓯊����[�h����
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

    //���[�h��ʓ�����
    private void InLoading()
    {
        if (!LoadOperation.allowSceneActivation)
        {
             LoadOperation.allowSceneActivation = true;
        }
    }

}

