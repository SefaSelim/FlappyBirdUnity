using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{

public float speed;
    void Start()
    {
        Destroy(gameObject,6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left*Time.deltaTime * speed;
    }
}
