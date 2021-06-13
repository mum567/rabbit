using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public List<Transform> locations;
    public Transform patrolRoute;
    public Transform player;
    private int locationIndex = 0;
    private UnityEngine.AI.NavMeshAgent agent;

    private int _lives = 3;
    public int EnemyLives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            if(_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy is Killed");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        patrolRoute = GameObject.Find("PatrolRoute").transform;
        InitializePatrolRoute();
        MoveToNextPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolPoint();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            agent.destination = player.position;
            Debug.Log("Player detected - Attack");

        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }

    void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolPoint()
    {
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "StoneShoot(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Enemy Hit!");
        }
    }
}
