using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyController : MonoBehaviour {
    NavMeshAgent navMeshAgent;
    Transform transformPlayer;
    Animator animatorController;
    

	// Use this for initialization
	void Awake () {
		navMeshAgent= GetComponent<NavMeshAgent>();
        transformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        animatorController = GetComponentInParent<Animator>();


        // animatorController.SetFloat("speed", Mathf.Abs(navMeshAgent.velocity.x) + Mathf.Abs(navMeshAgent.velocity.z));

       // navMeshAgent.Warp(GetComponent<Transform>().position);


        //navMeshAgent.SetDestination(transformPlayer.position);


    }

    // Update is called once per frame
    void Update () {



      //  navMeshAgent.Warp(GetComponent<Transform>().position);


        navMeshAgent.SetDestination(transformPlayer.position);








    }
}
