﻿using UnityEngine;
using System.Collections;

public class Fish_Control : MonoBehaviour {
	public float swamSpeed = 5f;
	public float downSpeed = 0.6f;
	public float swimTime = 0.5f;

	private const float kMinXfloat = -11.88f;
	private const float kMaxXfloat = 21f;
	private const float kMinYfloat = 4.1f;
	private const float kMaxYfloat = 5.62f;
	private const float kMinZfloat = -0.26f;
	private const float kMaxZfloat = 10.53f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tPosition = transform.position;
		if (transform.position.x >= kMaxXfloat){
			// 广播关卡通过
			tPosition.x += swamSpeed * 4 * Time.deltaTime;
			transform.position = tPosition;
		} else {
			float tVerticalInput = Input.GetAxis("Vertical") > 0 ? Input.GetAxis("Vertical") : 0;
			tPosition.z += -Input.GetAxis("Horizontal") * swamSpeed * Time.deltaTime;
			tPosition.x += tVerticalInput * swamSpeed * Time.deltaTime;
			tPosition.z = Mathf.Clamp(tPosition.z, kMinZfloat, kMaxZfloat);
			tPosition.x = Mathf.Clamp(tPosition.x, kMinXfloat, kMaxXfloat);
		}
		if (Input.GetKey(KeyCode.Space)){
			tPosition.y -= downSpeed * Time.deltaTime;
			tPosition.y = tPosition.y > kMinYfloat ? tPosition.y : kMinYfloat;
		} else 
			tPosition.y = Mathf.Lerp(tPosition.y, kMaxYfloat, Time.deltaTime);
		transform.position = tPosition;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "gabbish"){
			StartCoroutine("SwimCoroutine");
		}
	}

	IEnumerator SwimCoroutine(){
		yield return new WaitForSeconds(swimTime);
	}
}
