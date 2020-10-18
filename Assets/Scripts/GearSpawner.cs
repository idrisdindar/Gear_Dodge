using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSpawner : MonoBehaviour
{
    [SerializeField] private int maxCount = 0;
    [SerializeField] private GameObject gearPrefab = null;
    [SerializeField] private float minTime = 0f, maxTime = 0f;

    private float tempTime = 0f;
    internal static int count = 0;
    void Start()
    {
        count = 0;
        tempTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        if(tempTime <= 0f && maxCount > count)
        {
            GameObject temp = Instantiate(gearPrefab, new Vector2(0,0), Quaternion.identity);
            tempTime = Random.Range(minTime, maxTime);
            count++;
        }
        else if(maxCount > count)
        {
            tempTime -= Time.deltaTime;
        }
    }
}
