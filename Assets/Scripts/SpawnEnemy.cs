/****
 * Created by: William Gulick
 * Date Created: 9/22/2021
 * 
 * Last edited by:
 * Last updated: 9/22/2021
 * 
 * Description: Spawns enemies at a set interval
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float MaxRadius = 1f;
    public float Interval = 2f;
    public GameObject ObjToSpawn = null;
    private Transform Origin = null;
    void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        InvokeRepeating("Spawn", 0f, Interval);
    }
    void Spawn()
    {
        if (Origin == null)
        {
            return;
        }
        Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius;
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z); Instantiate(ObjToSpawn, SpawnPos, Quaternion.identity);
    }
}
