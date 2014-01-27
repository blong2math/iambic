using UnityEngine;
using System.Collections;

public class Pushable : MonoBehaviour {
	public float Magnification = 1000f;

	private Rigidbody2D rigid;
	private Vector2 startPosition;
	private Vector2 endPosition;

	void Start(){
		rigid = GetComponentInChildren<Rigidbody2D>();
		// code for debug
		if (rigid == null)
			throw new UnityException("No Rigidbody2D component.");
	}

	void OnMouseDown(){
		getMousePositionToVector2(out startPosition);
	}

	void OnMouseUp(){
		getMousePositionToVector2(out endPosition);

		rigid.AddForce(Magnification * Vector2.right * (endPosition - startPosition).x);
	}

	void getMousePositionToVector2(out Vector2 position){
		position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	}

}
