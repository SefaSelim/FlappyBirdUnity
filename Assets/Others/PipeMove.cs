using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{

public float speed;
    void Start()
    {
        if (!StaticSettings.isGameFreezed)
        {
            Destroy(gameObject, 6f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!StaticSettings.isGameFreezed)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
    }
}
