using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime;
    public float createTime = 1.0f;
    public GameObject enemy;

    public float minTime = 2.0f;
    public float maxTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0.0f;
        createTime = UnityEngine.Random.Range(minTime, maxTime);
        Debug.LogFormat("Create Time : {0}", createTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            GameObject newEnemy = Instantiate(enemy);
            newEnemy.transform.position = transform.position;

            currentTime = 0.0f;
            createTime = UnityEngine.Random.Range(minTime, maxTime);
            Debug.LogFormat("Create Time : {0}", createTime);
        }
    }
}

