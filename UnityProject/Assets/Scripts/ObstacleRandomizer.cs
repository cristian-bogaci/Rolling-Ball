using UnityEngine;
using System.Collections;

public class ObstacleRandomizer : MonoBehaviour {

	public float xPosition;
	private float obMax = 11;
	private float obMin = -11;

	void Start () {
		GameObject[] StartingObsArray = GameObject.FindGameObjectsWithTag("Obstacle2");


		foreach(GameObject Obstacle in StartingObsArray){
			Vector3 startingObs = Obstacle.transform.position;
			xPosition = startingObs.x;
			startingObs.x = Random.Range (obMin, obMax);
			Obstacle.transform.position = startingObs;
		}
	}

	void Update () {
		Randomizer();
	}

	void Randomizer(){
		xPosition = Random.Range (obMin, obMax);
	}
}
