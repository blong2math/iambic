using UnityEngine;
using System.Collections;

public class CharactorMove : MonoBehaviour {
	public float speed = 1.2f; // The speed of the charactor
	public float smooth = 2.0f;
	
	private bool isFaceRight = true;

	private Quaternion rotation;
	private Vector3 position;
	private Animator anim;

	void Start(){
		anim = GetComponentInChildren<Animator>();
		rotation = transform.rotation;
		position = transform.position;
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag != "background"){
			if (isFaceRight)
				rotation.y = 180; 
			else
				rotation.y = 0;
			isFaceRight = !isFaceRight;
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
		rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * speed, rigidbody2D.velocity.y);
	}
}
