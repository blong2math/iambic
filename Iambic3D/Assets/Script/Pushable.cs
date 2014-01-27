using UnityEngine;
using System.Collections;

public class Pushable : MonoBehaviour {
	public float Magnification = 1000f;

	private Rigidbody rigid;
	private Vector2 startPosition;
	private Vector2 endPosition;

	void Start(){
		rigid = GetComponentInChildren<Rigidbody>();
		// code for debug
		if (rigid == null)
			throw new UnityException("No Rigidbody component.");
	}

	void OnMouseDown(){
		Debug.Log ("This is a test");
		getMousePositionToVector2(out startPosition);

	}

	void OnMouseUp(){
		getMousePositionToVector2(out endPosition);
		Debug.Log ("This is a test");
		rigid.AddForce(Magnification * Vector3.right * (endPosition - startPosition).x);
	}

	void getMousePositionToVector2(out Vector2 position){
		position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	}

}
