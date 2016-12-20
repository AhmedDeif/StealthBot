using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigationScript : MonoBehaviour
{

	//This class controlls the enemy to navigate from a start point to an end point.
	//When the enemy agent reaches one of these points he switches directions making him move endlessly in a specific path.
	public GameObject target;
	private bool turn;
	NavMeshAgent enemyAgent;
	private float targetPoint;
	private int counter = 10;

	Animator animator;

	// Use this for initialization
	void Start ()
	{
		turn = false;
		targetPoint = 3f;
		animator = GetComponent<Animator> ();
		enemyAgent = GetComponent <NavMeshAgent> ();
		target.transform.position = new Vector3 (enemyAgent.transform.position.x, enemyAgent.transform.position.y, targetPoint);

		animator.SetBool ("Turn", false);

	}

	// Update is called once per frame
	void Update ()
	{

		enemyAgent.SetDestination (target.transform.position);
	
		if (turn) {
			animator.SetBool ("Turn", true);
			turn = false;

		}
		counter--;
		if (counter == 0) {
			targetPoint = -1 * targetPoint;
			target.transform.position = new Vector3 (0, 0.5f, (targetPoint));
			Debug.Log ("New Target position =   " + target.transform.position);


		}

	}

	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("Gowa OnTrigger");
		if (other.CompareTag ("EnemyEndPoint")) {
			turn = true;
			Debug.Log ("Turn ");
		}
	}


}
