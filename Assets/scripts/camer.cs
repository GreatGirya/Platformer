using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camer : MonoBehaviour
{
    
    float speed = 2;
    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.CompareTag("Hero"))
        {
            float speed = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position,target.position,speed*Time.fixedDeltaTime);
    }
}
