using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {
	
	private int currentPoint;
	public float moveSpeed;
	private Vector3 patrolPos1;
	private Vector3 patrolPos2;
	private Vector3[] patrolPoints = new Vector3[2];
	private int randomPoint;

	void Start () {
		moveSpeed = 2;
		currentPoint = 0;
		randomPoint = Random.Range(0,1);
	}

	void Update () {
		patrolPos1 = transform.position;
		patrolPos1.x = 11;
		patrolPos2 = transform.position;
		patrolPos2.x = -11;
		if(randomPoint == 0){
			patrolPoints[0] = patrolPos1;
			patrolPoints[1] = patrolPos2;
		}
		if(randomPoint == 1){
			patrolPoints[0] = patrolPos2;
			patrolPoints[1] = patrolPos1;
		}
		if(transform.position == patrolPoints[currentPoint]){
			currentPoint++;
			if(currentPoint > 1){
				currentPoint = 0;
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint], moveSpeed * Time.deltaTime);
	}
}
