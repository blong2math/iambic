using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float cameraSize = 2.5f; // The orthographic size of the following camera.
	public float xSmooth = 8f;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public Vector2 maxXAndY;		// The maximum x and y coordinates the camera can have.
	public Vector2 minXAndY;		// The minimum x and y coordinates the camera can have.

	private Transform hero;
	// Use this for initialization
	void Start () {
		hero = GameObject.FindGameObjectWithTag("Player").transform;
		// Debug code
		if (hero == null)
			throw new UnityException("No GameObject called 'hero'.");
	}

	void FixedUpdate(){

		cameraSize -= Input.GetAxis("Mouse ScrollWheel"); // For tester to set the proper 'cameraSize' parameter.

		camera.orthographicSize = cameraSize;
		TrackHero();
	}

	void TrackHero(){
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		targetX = Mathf.Lerp(transform.position.x, hero.position.x, xSmooth * Time.deltaTime);
		targetY = Mathf.Lerp(transform.position.y, hero.position.y, ySmooth * Time.deltaTime);

		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.y);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
