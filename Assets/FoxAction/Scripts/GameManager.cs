using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject TitleUi;
    public GameObject SelectUi;
    public enum GameState
    { 
        Title,
        Load,
        Run,
        Slect,
        Play,
        Result,
    }

    public static GameState gameState;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        gameState = GameState.Title;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState!=GameState.Title)
        {
            TitleUi.SetActive(false);
        }
    }
    public static void ChangeState(GameState state)
    {
        gameState = state;

    }
}
