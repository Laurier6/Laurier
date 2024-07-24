using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxWalkState : FoxStateBase
{
    public override void OnEnter(Fox fox)
    {
        fox.anim.SetBool("Walk",true);
    }
    public override void OnUpdate(Fox fox)
    {
        fox.inputVertical = Input.GetAxis("Vertical");//縦方向の入力
        fox.inputHorizontal = Input.GetAxis("Horizontal");//横方向の入力
        //カメラの平面
        Vector3 camForward = Vector3.Scale(fox.cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        //移動ベクトル
        Vector3 moveForward = camForward * fox.inputVertical + fox.cam.transform.right * fox.inputHorizontal;
        //移動ベクトルとプレイヤーの正面の内積
        float dot = Vector3.Dot(moveForward.normalized, fox.transform.forward.normalized);
        if (!Mathf.Approximately(dot, 1))//回転
        {
            float cross = Vector3.Cross(moveForward, fox.transform.forward).y;
            moveForward = fox.transform.forward;
            if (cross < 0)//右回転
            {
                Quaternion rot = Quaternion.AngleAxis(9, Vector3.up);
                fox.transform.rotation = fox.transform.rotation * rot;
            }
            else//左回転
            {
                Quaternion rot = Quaternion.AngleAxis(-9, Vector3.up);
                fox.transform.rotation = fox.transform.rotation * rot;
            }
        }
        moveForward = moveForward.normalized;
        //移動させる
        fox.Move(moveForward * fox.Speed);
        //動いていない場合元に戻す
        if (fox.inputVertical == 0 && fox.inputHorizontal == 0)
        {
            fox.StateChange(fox.foxIdolState);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            fox.StateChange(fox.foxAttackState);
        }
    }
    public override void OnExit(Fox fox)
    {

    }
}
