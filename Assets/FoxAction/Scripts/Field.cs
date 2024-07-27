using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public float Theta;

    private Vector3 axis;

    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        axis = Vector3.up;
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameState!=GameManager.GameState.Play)
        {
            Quaternion rot = Quaternion.AngleAxis(Theta, axis);
            _transform.rotation =  transform.rotation*rot ;
        }
    }
}
