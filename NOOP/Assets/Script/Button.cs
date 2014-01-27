using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {
		if (GUI.RepeatButton (new Rect (0, 0, 100, 50), "Down")) {
			// DeskMove.SetDirection (-1.0f);
			gameObject.transform.Translate(Vector3.down * 1);
		}
		
		if (GUI.RepeatButton (new Rect (0, 60, 100, 50), "Up")) {
			// DeskMove.SetDirection (1.0f);
			gameObject.transform.Translate(Vector3.up * 1);
		}
	}
}