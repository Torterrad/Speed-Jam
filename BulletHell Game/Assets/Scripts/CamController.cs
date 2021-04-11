using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;

    private float startY;
    void Start()
    {
        startY = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.position = new Vector3(target.position.x, startY, transform.position.z);
        }
    }
}
