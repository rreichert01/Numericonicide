using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeInit;
    public float timeDuration = 5f;
    // Start is called before the first frame update
    void Start()
    {
        timeInit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeInit + timeDuration < Time.time) 
        {
            Destroy(gameObject);
        }
    }
}
