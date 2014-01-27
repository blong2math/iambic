using UnityEngine;
using System.Collections;

public class CharactorMove : MonoBehaviour {
	public float speed = 1.2f; // The speed of the charactor
	
	private bool isFaceRight = true;
	private float deltaX;

	private Quaternion rotation;
	private Vector3 position;

	void Start(){
		rotation = transform.rotation;
		position = transform.position;
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag != "Background"){
			deltaX = col.transform.position.x - transform.position.x;
			if (deltaX > 0 && isFaceRight){
				isFaceRight = !isFaceRight;
				rotation.y = 180;
			}
			else if (deltaX < 0 && !isFaceRight){
				isFaceRight = !isFaceRight;
				rotation.y = 0;
			}
			transform.rotation = rotation;
		}
	}

	void FixedUpdate(){
		transform.rotation = rotation;
		position.x = transform.position.x;
		transform.position = position;
		if (isFaceRight)
			speed = Mathf.Abs(speed);
		else
			speed = -Mathf.Abs(speed);
		rigidbody.velocity = new Vector3(speed, 0, rigidbody.velocity.z);
	}
}
