using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{
    public GameObject Prefab;
    public int Count;
    // Start is called before the first frame update
    void Awake()
    {
        for(int i=0;i<Count;i++)
        {
            GameObject.Instantiate(Prefab);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
