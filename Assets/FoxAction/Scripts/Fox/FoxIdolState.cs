using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxIdolState : FoxStateBase
{ 
    public override void OnEnter(Fox fox)
    {
        fox.Move(Vector3.zero);
        fox.anim.SetBool("Walk",false);
    }
    public override void OnUpdate(Fox fox)
    {
        fox.inputVertical = Input.GetAxis("Vertical");//c•ûŒü‚Ì“ü—Í
        fox.inputHorizontal = Input.GetAxis("Horizontal");//‰¡•ûŒü‚Ì“ü—Í
        if (fox.inputVertical != 0 || fox.inputHorizontal != 0)
        {
            fox.StateChange(fox.foxWalkState);
        }
        //if(Input.GetKeyDown(KeyCode.Q))
        //{
        //    fox.StateChange(fox.foxDiedState);
        //}
        if (Input.GetKeyDown(KeyCode.E))
        {
            fox.StateChange(fox.foxAttackState);
        }
    }
    public override void OnExit(Fox fox)
    {

    }
}
