using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
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
        this.gameObject.transform.parent = null;
        LoadManager.instance.LoadScene();
        GameManager.ChangeState(GameManager.GameState.Load);
    }
}
