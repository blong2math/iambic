using UnityEngine;
using System.Collections;

public class Fish_Control : MonoBehaviour {
	public float swamSpeed = 5f;
	public float downSpeed = 0.6f;
	public float swimTime = 0.5f;
	public float swimEnlargeRatio = 1.1f;

	private float gabbishCollisionCount; // Unused in real swim judgement
	private Judgement judgement;

	private const float kMinXfloat = -11.88f;
	private const float kMaxXfloat = 21f;
	private const float kMinYfloat = 4.1f;
	private const float kMaxYfloat = 5.62f;
	private const float kMinZfloat = -0.26f;
	private const float kMaxZfloat = 10.53f;

	// Use this for initialization
	void Start () {
		gabbishCollisionCount = 0;
		judgement = GameObject.Find ("Main Camera").GetComponent<Judgement>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tPosition = transform.position;
		if (judgement.stateInfo == Judgement.kGameDoing && transform.position.x >= kMaxXfloat){
			// 广播关卡通过
			GameObject obj = GameObject.Find ("Main Camera");
			obj.SendMessage("ReceiveMessage", Judgement.kGameFailed);
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
			swimTime *= swimEnlargeRatio;
			StartCoroutine("SwimCoroutine");
		} else if (collision.gameObject.name == "Cat" && judgement.stateInfo == Judgement.kGameDoing){
			// 广播关卡失败
			GameObject obj = GameObject.Find ("Main Camera");
			obj.SendMessage("ReceiveMessage", Judgement.kGameFailed);
		}
	}

	IEnumerator SwimCoroutine(){
		yield return new WaitForSeconds(swimTime);
	}
}
