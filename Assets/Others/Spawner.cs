using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Movement bird;
    public GameObject pipes;
    public float timeBetweenSpawn;
    public float heightGap;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnPipes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator spawnPipes()
    {
       while (!bird.isDead)
       {
         yield return new WaitForSeconds(timeBetweenSpawn);

         Instantiate(pipes,new Vector3(1.4f,UnityEngine.Random.Range(-heightGap+0.05f,heightGap+0.15f),0),quaternion.identity);


       }
    }
}
