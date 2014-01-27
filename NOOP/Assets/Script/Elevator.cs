using UnityEngine;
using System.Collections;

// 需要改CollisionStay2D的两个判定标签.
// 需要改Update当撞到底部的判定坐标.

public class Elevator : MonoBehaviour {

	public string bg = "Background";
	public string p = "Player";
	public float bottom = -60.3f;
	private Rigidbody2D Rb2D;
	private Collider2D Cl2D;

	// Use this for initialization
	void Start () {
		Rb2D = gameObject.GetComponent<Rigidbody2D>();
		Cl2D = gameObject.GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
		
		if (gameObject.transform.position.y <= bottom) {
			Rb2D.gravityScale = 0;
			Rb2D.isKinematic = true;
		}
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag != bg && coll.gameObject.tag != p) {
			Rb2D.gravityScale = 1;
		}
	}
}
