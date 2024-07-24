using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyBase
{
    public int SlimePower = 2;
    Animator SlimeAnim;
    // Start is called before the first frame update
    void Start()
    {
        SlimeAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy_HP <= 0)
        {
            SlimeAnim.SetInteger("SlimeState", -1);
        }
    }
}
