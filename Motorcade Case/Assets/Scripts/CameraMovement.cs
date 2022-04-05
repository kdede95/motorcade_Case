using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;        


    private Vector3 offset;            

    
    void Start()
    {

        offset = transform.position - player.transform.position;
    }

    
    void LateUpdate()
    {
        Vector3 zFollow = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + offset.z);
        transform.position = zFollow;
    }
}
