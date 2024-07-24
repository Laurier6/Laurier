using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float speed = 0.1f;

    private float distance;

    public static bool Title = true;


    [SerializeField]private GameObject Player;
    private Vector3 PlayerPos;

    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = Player.transform.position;
        _transform = this.transform;

        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position += Player.transform.position - PlayerPos;
        PlayerPos = Player.transform.position;
        //switch (GameManager.gameState)
        //{
        //    case GameManager.GameState.Title:
        //        //Debug.Log(LoadManager.instance.backpos.position.y);
        //        break;
        //    case GameManager.GameState.Load:
        //        //if (LoadManager.instance.backpos.position.y == 540)
        //        //{ 
        //        //    TitleCam.SetActive(false);                
        //        //    PlayCam.SetActive(true);
        //        //    LoadManager.instance.Discover();
        //        //    GameManager.ChangeState(GameManager.GameState.Play);
        //        //}
        //        break;
        //    case GameManager.GameState.Run:
        //        break;
        //    case GameManager.GameState.Play:
        //        _transform.position += Player.transform.position - PlayerPos;
        //        PlayerPos = Player.transform.position;
        //        //if (Input.GetMouseButton(1))
        //        //{
        //        //    float MouseInput = Input.GetAxis("Mouse X");
        //        //    transform.RotateAround(PlayerPos, Vector3.up, MouseInput * Time.deltaTime * 200f);
        //        //}
        //        break;
        //    default:
        //        break;
        //}
        
    }

    private bool MoveCam(Transform currentPos,Transform tragetPos,float Speed)
    {
        distance += Time.deltaTime * Speed;
        //Debug.Log(distance);
        _transform.position = Vector3.Slerp(currentPos.position, tragetPos.position, distance);
        _transform.rotation = Quaternion.Lerp(currentPos.rotation, tragetPos.rotation, distance);
        if (distance >= 1)
        {
            distance = 0;
            return true;
        }
        return false;
    }

}
