using UnityEngine;
using System.Collections;

public class DeskMove : MonoBehaviour {

	public float deskSpeed;

	public static float direction = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// 通过外界change它的direction来改变他的移动。
	void Update () {
		gameObject.transform.Translate (Vector3.right * direction * deskSpeed * Time.deltaTime);
		direction = 0f;
	}

	public static void SetDirection(float dir){
		direction = dir;
	}
}