using UnityEngine;
using System.Collections;

public class ObstacleLooper : MonoBehaviour {
	
	private float obstacleDistance = 20f;
	private int nrOfObstacles = 5;
	public GameObject[] obstacleArray;
	private int currentObs;
	private GameObject player;
	private int score;
	public GameObject[] movingObstacleArray;
	private int currentMovingObs;

	void Start(){
		currentObs = 0;
		currentMovingObs = 0;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update(){
		score = player.GetComponent<ScoreTrigger>().score;
	}
	

	void OnTriggerEnter(Collider other){
		if(other.GetComponent<Collider>().tag == "Obstacle2"){
			if(score <= 15){
				Debug.Log("triggered by obstacle");
				Vector3 obstaclePosition = obstacleArray[currentObs].transform.position;
				obstaclePosition.z += obstacleDistance * nrOfObstacles;
				obstaclePosition.x = GetComponent<ObstacleRandomizer>().xPosition;
				obstacleArray[currentObs].transform.position = obstaclePosition;
				currentObs++;
				if(currentObs > 4){
					currentObs  = 0;
				}
			}
			if(score > 15){
				Debug.Log("triggered by moving obstacle");
				Vector3 movingObstaclePosition = movingObstacleArray[currentMovingObs].transform.position;
				movingObstaclePosition.z += obstacleDistance * nrOfObstacles;
				movingObstaclePosition.x = GetComponent<ObstacleRandomizer>().xPosition;
				movingObstaclePosition.y = 0.5f;
				movingObstacleArray[currentMovingObs].transform.position = movingObstaclePosition;
				currentMovingObs++;
				if(currentMovingObs > 4){
					currentMovingObs  = 0;
				}
			}
		}
	}
}
