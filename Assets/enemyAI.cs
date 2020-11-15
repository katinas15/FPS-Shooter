using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float range = 5f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMesh;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if(isProvoked){
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed );

            if(distanceToTarget >= navMesh.stoppingDistance){
                navMesh.SetDestination(target.position);
            }

            if(distanceToTarget <= navMesh.stoppingDistance){
                Debug.Log("attacking");
            }

        } else if (distanceToTarget <= range){
            isProvoked = true;
            navMesh.SetDestination(target.position);
        }
        
    }


    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, range);
    }
}
