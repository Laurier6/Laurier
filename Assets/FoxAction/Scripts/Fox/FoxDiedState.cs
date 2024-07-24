using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDiedState : FoxStateBase
{
    public override void OnEnter(Fox fox)
    {
        fox.Move(Vector3.zero);
        fox.anim.SetTrigger("isDied");
    }
    public override void OnUpdate(Fox fox)
    {
        
    }
    public override void OnExit(Fox fox)
    {

    }
}
