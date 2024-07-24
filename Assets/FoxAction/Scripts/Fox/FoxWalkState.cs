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
        fox.inputVertical = Input.GetAxis("Vertical");//�c�����̓���
        fox.inputHorizontal = Input.GetAxis("Horizontal");//�������̓���
        //�J�����̕���
        Vector3 camForward = Vector3.Scale(fox.cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        //�ړ��x�N�g��
        Vector3 moveForward = camForward * fox.inputVertical + fox.cam.transform.right * fox.inputHorizontal;
        //�ړ��x�N�g���ƃv���C���[�̐��ʂ̓���
        float dot = Vector3.Dot(moveForward.normalized, fox.transform.forward.normalized);
        if (!Mathf.Approximately(dot, 1))//��]
        {
            float cross = Vector3.Cross(moveForward, fox.transform.forward).y;
            moveForward = fox.transform.forward;
            if (cross < 0)//�E��]
            {
                Quaternion rot = Quaternion.AngleAxis(9, Vector3.up);
                fox.transform.rotation = fox.transform.rotation * rot;
            }
            else//����]
            {
                Quaternion rot = Quaternion.AngleAxis(-9, Vector3.up);
                fox.transform.rotation = fox.transform.rotation * rot;
            }
        }
        moveForward = moveForward.normalized;
        //�ړ�������
        fox.Move(moveForward * fox.Speed);
        //�����Ă��Ȃ��ꍇ���ɖ߂�
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
