using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("적생성")]
    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] createnemy;
    [SerializeField] float creat_time;

    void Start()
    {
        InvokeRepeating("creat", 0, creat_time);
    }

    void Update()
    {
        
    }

    void creat()
    {
        int i = Random.Range(0, 4);

        Instantiate(enemy, createnemy[i].position, createnemy[i].rotation);
    }
}
