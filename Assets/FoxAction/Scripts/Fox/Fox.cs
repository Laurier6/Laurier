using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public int HP = 10;//プレイヤーキャラの体力
    public float Speed = 10f;//移動速度に使う

    public GameObject AttackCollider;

    public GameObject cam;//カメラの情報を取得

    public Rigidbody rb;//移動用
    public Animator anim;//アニメーション

    private FoxStateBase foxState;

    public float inputVertical;//縦方向の入力
    public float inputHorizontal;//横方向の入力

    public FoxIdolState   foxIdolState   = new FoxIdolState();
    public FoxWalkState   foxWalkState   = new FoxWalkState();
    public FoxAttackState foxAttackState = new FoxAttackState();
    public FoxDiedState   foxDiedState   = new FoxDiedState();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        AttackCollider.SetActive(false);
        foxState = foxIdolState;
        foxState.OnEnter(this);
    }
    private void Update()
    {
        foxState.OnUpdate(this);
        if(HP<=0)
        {
            StateChange(foxDiedState);
        }
    }

    public void StateChange(FoxStateBase nextState)
    {
        foxState.OnExit(this);
        foxState = nextState;
        foxState.OnEnter(this);
    }

    public void Move(Vector3 v3)
    {
        rb.velocity = v3;
    }

    public void AttackOn()
    {
        AttackCollider.SetActive(true);
    }
    public void AttackOff()
    {
        AttackCollider.SetActive(false);
    }
    public void AttackEnd()
    {
        StateChange(foxIdolState);
    }
}

