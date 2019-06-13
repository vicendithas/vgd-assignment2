using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public GUIText positionText;
	public GUIText instructions;

	void Start()
	{
		SetPositionText (Vector3.zero);
		SetInstructionText ();
	}
	
	void FixedUpdate()
	{
		//Get movement in X and Z
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		float moveVertical = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);

		//Apply forces to player
		GetComponent<Rigidbody>().AddForce (movement);

		SetPositionText (gameObject.transform.position);
		
	}
	

	void SetPositionText(Vector3 position)
	{
		string xmsg = "Position(x): " + position.x.ToString ("#0.00");
		string zmsg = "\nPosition(z): " + position.z.ToString ("#0.00");
		positionText.text = xmsg + zmsg;
	}

	void SetInstructionText(){
		string msg0 = "Controls";
		string dash = "\n------------------------";
		string msg1 = "\nArrow/WASD: Move Player";
		string msg7 = "\nR: Restart game";

		instructions.text = msg0 + dash + msg1 + msg7;
	}

}