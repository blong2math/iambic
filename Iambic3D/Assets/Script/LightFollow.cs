using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {
	public bool isUsed = false; // It must be true if this script is on use.

	private Transform playerTransform;
	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (isUsed){
			Vector3 tmp = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
			transform.position = tmp;
		}
	}
}
