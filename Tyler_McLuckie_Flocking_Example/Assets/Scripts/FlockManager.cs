using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numCube = 20;
    public GameObject[] allCube;
    public Vector3 flyLimits = new Vector3(5, 5, 5);
    public Vector3 goalPos;

    [Header("Butterfly Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        allCube = new GameObject[numCube];
        for (int i = 0; i < numCube; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-flyLimits.x, flyLimits.x),
                                                                Random.Range(-flyLimits.y, flyLimits.y),
                                                                Random.Range(-flyLimits.z, flyLimits.z));
            allCube[i] = (GameObject)Instantiate(cubePrefab, pos, Quaternion.identity);
            allCube[i].GetComponent<Flock>().myManager = this;
        }
        goalPos = this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 10)
            goalPos = this.transform.position + new Vector3(Random.Range(-flyLimits.x, flyLimits.x),
                                                           Random.Range(-flyLimits.y, flyLimits.y),
                                                           Random.Range(-flyLimits.z, flyLimits.z));

    }
}


