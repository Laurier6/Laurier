using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxTitle : MonoBehaviour
{
    private Vector3 LocalPos;
    private Transform _transform;
    void Start()
    {
        LocalPos = new Vector3(-450.0f, 0.0f, -3.0f);
        _transform = transform;
    }
    void Update()
    {
        _transform.localPosition = LocalPos;
    }

}
