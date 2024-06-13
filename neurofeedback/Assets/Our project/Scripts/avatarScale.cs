using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarScale : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float period = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            transform.localScale = new Vector3(0.6f + Random.Range(-0.4f, 0.4f), 1f, 1);
        }
    }
}
