using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosScript : MonoBehaviour
{

    public GameObject parent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = parent.transform.position;
    }
}
