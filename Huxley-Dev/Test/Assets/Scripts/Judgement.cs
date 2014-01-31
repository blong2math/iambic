using UnityEngine;
using System.Collections;

public class Judgement : MonoBehaviour {
	public float blurTransitionTime = 1f;

	public const string kGamePass = "Succceed";
	public const string kGameFailed = "Failed";
	public const string kGameDoing = "Unknow";

	private string state;

	private GrayscaleEffect grayscaleEffect;
	private BlurEffect blurEffect;

	// Use this for initialization
	void Start () {
		state = kGameDoing;
		grayscaleEffect = gameObject.GetComponent<GrayscaleEffect>();
		blurEffect = gameObject.GetComponent<BlurEffect>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void ReceiveMessage(string msg){
		if (msg == kGamePass){
			Debug.Log ("Scence passed!");
			state = kGamePass;
			// TODO: 关卡通过流程
		} else if (msg == kGameFailed){
			Debug.Log ("Scence failed!");
			state = kGameFailed;
			grayscaleEffect.enabled = true;
			blurEffect.enabled = true;
			iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 2, "time", blurTransitionTime, "onupdate", "OnBlurChanging"));
		}
	}

	void OnBlurChanging(int value){
		blurEffect.iterations = value;
	}

	public string stateInfo{
		get{
			return this.state;
		}
	}
}
