using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {

	public int score = 0;
	public int highScore;
	public GameObject scoreText;
	public GameObject scoreText2;
	public GameObject highScoreText;
	public bool didCount;
	private GameObject player;
	public GameObject[] movingObstacles;


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		highScore = PlayerPrefs.GetInt("highscore", highScore);
		didCount = false;
	}

	IEnumerator scoreCounter(){
		yield return new WaitForSeconds(1f);
			for(int i=0;i<=score;i++){
				scoreText2.GetComponent<Text>().text = "Score: " + i;
				yield return new WaitForSeconds(0.02f);
			}
			if(score > highScore){
				for(int i=0;i<=highScore;i++){
					highScoreText.GetComponent<Text>().text = "High Score: " + i;
					yield return new WaitForSeconds(0.02f);
				}
			}
	}

	void Update () {
		scoreText.GetComponent<Text>().text = "Score: " + score;
		highScoreText.GetComponent<Text>().text = "High Score: " + highScore;
		if(didCount == false && GetComponent<PlayerDeath>().dead == true){
			StartCoroutine(scoreCounter());
			didCount = true;
		}
		if(score >=10 && score <30){
			player.GetComponent<PlayerMovement>().maxSpeed = 21;
			Debug.Log ("increased max speed to 21");
		}
		if(score >= 20 && score < 40){
			foreach(GameObject MovingObstacle in movingObstacles){
				MovingObstacle.GetComponent<ObstacleMovement>().moveSpeed = 4;
			}
		}
		if(score >=30 && score <50){
			player.GetComponent<PlayerMovement>().maxSpeed = 22;
		}
		if(score >= 40 && score < 50){
			foreach(GameObject MovingObstacle in movingObstacles){
				MovingObstacle.GetComponent<ObstacleMovement>().moveSpeed = 6;
			}
		}
		if(score >=50 && score < 70){
			foreach(GameObject MovingObstacle in movingObstacles){
				MovingObstacle.GetComponent<ObstacleMovement>().moveSpeed = 8;
			}
		}
		if(score >= 70){
			player.GetComponent<PlayerMovement>().maxSpeed = 23;
		}
	}

	void OnTriggerEnter(Collider scored){
		if(scored.GetComponent<Collider>().tag == "Score"){
			score ++;
		}
	}
}
