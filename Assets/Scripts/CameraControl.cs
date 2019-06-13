using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private float angle;

	// Use this for initialization
	void Start ()
	{
		angle = 0f;
		offset = transform.position;
		transform.position = player.transform.position + offset;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 playerpos = player.transform.position;
		Vector3 playervel = player.GetComponent<Rigidbody>().velocity;

		if(playervel.x < 0.01f && playervel.z < 0.01f){
			angle = 90;
		} else {
			angle = Mathf.Atan2 (playervel.z, playervel.x) * Mathf.Rad2Deg;
		}
		//float currentangle = transform.eulerAngles.z * Mathf.Deg2Rad;
		float newangle = -1 * angle + 90;

		//float anglediff = angle - currentangle;

		float newx = playerpos.x + (offset.x * Mathf.Cos (angle * Mathf.Deg2Rad));
		float newz = playerpos.z + (offset.z * Mathf.Sin (angle * Mathf.Deg2Rad));
		
		transform.position = new Vector3 (newx, offset.y, newz);

		transform.eulerAngles = new Vector3 (45f, newangle, 0f);

		debugPrint ();

	}

	void debugPrint(){
		print ("Velocity angle:" + angle.ToString("#0.00") + "\tCamera angles:" + this.transform.eulerAngles.ToString("#0.00"));
	}
}
