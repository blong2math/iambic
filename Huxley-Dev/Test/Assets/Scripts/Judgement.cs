using UnityEngine;
using System.Collections;

public class Judgement : MonoBehaviour {

	public const string kGamePass = "Succceed";
	public const string kGameFailed = "Failed";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ReceiveMessage(string msg){
		if (msg == kGamePass){
			Debug.Log ("Scence passed!");
			// TODO: 关卡通过流程
		} else if (msg == kGameFailed){
			Debug.Log ("Scence failed!");
			GrayscaleEffect grayscaleEffect = gameObject.GetComponent<GrayscaleEffect>();
			grayscaleEffect.enabled = true;
			BlurEffect blurEffect = gameObject.GetComponent<BlurEffect>();
			blurEffect.enabled = true;
		}
	}
}
