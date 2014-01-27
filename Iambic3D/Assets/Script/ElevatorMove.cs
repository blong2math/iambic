using UnityEngine;
using System.Collections;

public class ElevatorMove : MonoBehaviour {
	// This script is only suitable for level1's elevator. 

	public bool isUsed = false;
	public float speed = 0.1f;
	public float startPositionY;
	public float endPositionY;

	private Transform ropeStartTransform;
	private Transform ropeEndTransform;
	
	private Quaternion fixedRotation;
	private Vector3 fixedPosition;
	private float deltaY = 0;

	// Use this for initialization

	void Start () {
		ropeStartTransform = GameObject.Find("Prefab_Rope_Start").transform;
		ropeEndTransform = GameObject.Find ("Prefab_Rope_End").transform;
		fixedPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		fixedRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = fixedRotation;
		transform.position = fixedPosition;
		if (isUsed){
			if (transform.position.y > endPositionY){
				float targetY = Mathf.Lerp(transform.position.y, endPositionY, Time.deltaTime * speed);
				deltaY = targetY - fixedPosition.y;
				fixedPosition.y = targetY;
				UpdateRopes();
			} else {
				fixedPosition.y = endPositionY;
			}
		}
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Desk")
			isUsed = true;
	}

	void UpdateRopes(){
		Vector3 tmpRopeEnd = ropeEndTransform.position;
		tmpRopeEnd.y += deltaY;
		ropeEndTransform.position = tmpRopeEnd;
	}
}
