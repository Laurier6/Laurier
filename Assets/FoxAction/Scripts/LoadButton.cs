using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    public Canvas Title;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TitleButton();
        }
    }
    public void TitleButton()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Title.sortingOrder = -1;
        this.gameObject.transform.parent = null;
        LoadManager.instance.LoadScene();
        GameManager.ChangeState(GameManager.GameState.Load);
    }
}
