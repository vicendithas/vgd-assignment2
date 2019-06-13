using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	void OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.gameObject.tag.Equals ("Wall")){
			Vector3 direction = GetComponent<Rigidbody>().velocity;
			Vector3 newVelocity = Vector3.Reflect(direction, collisionInfo.contacts[0].normal);
			GetComponent<Rigidbody>().velocity = newVelocity;
			//print ("A ball collided! Old Velocity:" + direction.ToString() + " New Velocity: " + newVelocity.ToString());
		}
	}
}
