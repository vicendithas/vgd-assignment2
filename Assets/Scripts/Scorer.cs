using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scorer : MonoBehaviour {

	public GameObject ball1;
	public GameObject ball2;
	public GameObject ball3;
	private int score;
	public GUIText WinText;
	public GUIText ScoreText;
	public GUIText instructions;
	private bool gameover;
	private float timer;
	public GUIText TimerText;
	
	void Start(){
		WinText.text = "";
		ScoreText.text = "Score: 0";
		score = 0;
		SetInstructionText ();
		gameover = false;
		timer = 0f;
	}
	
	void Update(){
		score = CheckBalls ();
		ScoreText.text = "Score: " + score;
		if(score == 3){
			WinText.text = "You Win!";
			gameover = true;
		}

		//Reset game when "R" key is pressed
		if (Input.GetKeyDown (KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

		if(!gameover){
			timer += Time.deltaTime;
		}

		SetTimerText ();

	}

	int CheckBalls(){
		int temp = 0;

		if(ball1.transform.position.y < -1){
			ball1.SetActive(false);
			temp++;
		}

		if(ball2.transform.position.y < -1){
			ball2.SetActive(false);
			temp++;
		}

		if(ball3.transform.position.y < -1){
			ball3.SetActive(false);
			temp++;
		}

		return temp;
	}

	void SetInstructionText(){
		string msg0 = "Controls";
		string dash = "\n------------------------";
		string msg1 = "\nArrow/WASD: Move Player";
		string msg2 = "\nShift (hold): Sprint";
		string msg3 = "\nSpace: Jump";
		string msg7 = "\nR: Restart game";
		
		instructions.text = msg0 + dash + msg1 + msg2 + msg3 + msg7;
	}

	void SetTimerText(){
		TimerText.text = "Time: " + timer.ToString ("#0.00");
	}
}
