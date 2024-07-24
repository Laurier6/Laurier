using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAttack : MonoBehaviour
{
    public int Power = 2;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.gameObject.tag=="Enemy")
        {
            EnemyBase enemy = other.GetComponent<EnemyBase>();
            enemy.Enemy_HP-=Power;
            if(enemy.Enemy_HP <= 0)
            {
                Destroy(other);
            }
        }
    }
}
