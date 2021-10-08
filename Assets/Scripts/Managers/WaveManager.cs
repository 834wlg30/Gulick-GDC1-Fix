using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject[] waves = new GameObject[10];
    public float Interval = 3f;
    public GameObject ObjToSpawn = null;
    private Transform Origin = null;
    public int repairChance;
    public GameObject repairRing;
    void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag("SpawnOrigin").transform;
    }
    void Start()
    {
        InvokeRepeating("Spawn", 0f, Interval);
    }
    void Spawn()
    {
        Origin = GameObject.FindGameObjectWithTag("SpawnOrigin").transform;
        if (Origin == null)
        {
            return;
        }
        ObjToSpawn = waves[Random.Range(0, 5)];

        Vector3 SpawnPos = Origin.position + new Vector3(0f, 0f, 15f);
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z); Instantiate(ObjToSpawn, SpawnPos, Quaternion.identity);

        repairChance = Random.Range(0, 4);
        if (repairChance > 2)
        {
            Instantiate(repairRing, new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10)), Quaternion.identity);
        }
    }
}