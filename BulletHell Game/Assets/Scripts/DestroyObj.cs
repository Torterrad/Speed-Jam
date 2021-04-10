using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public float timeUntilDeath = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilDeath -= Time.deltaTime;
        if (timeUntilDeath <= 0)
        {
            Destroy(gameObject);
        }
    }
}
