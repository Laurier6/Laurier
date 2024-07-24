using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAttackState : FoxStateBase
{
    public override void OnEnter(Fox fox)
    {
        fox.Move(Vector3.zero);
        fox.anim.SetTrigger("isAttack");
    }
    public override void OnUpdate(Fox fox)
    {

    }
    public override void OnExit(Fox fox)
    {

    }
}
