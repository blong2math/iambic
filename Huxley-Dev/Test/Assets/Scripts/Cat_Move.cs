using UnityEngine;
using System.Collections;

public class Cat_Move : MonoBehaviour {

	public float speed = 1f;
	public float rotateHeadAngle = 36.8f;
	public float minJumpInteral = 1.5f;
	public float jumpTime = 2f;
	private Animator animator;
	private Transform fishTransform;
	private bool isOnTheRight;
	private float lastJumpTime;
	private int jumpContinueCount;

	private const float kMaxXFloat = 20f;
	private const float kRightZBoundary = 3.34f;
	private const float kLeftZBoundary = 6.94f;
	private const float kCatRightPositionZ = -2.623f;
	private const float kCatLeftPositionZ = 12.35f;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		fishTransform = GameObject.Find("Fish").transform;

		isOnTheRight = true;
		lastJumpTime = -1f;
		jumpContinueCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tPosition = transform.position;
		if (fishTransform.position.z > kLeftZBoundary && isOnTheRight){
			Debug.Log ("Need to jump left");
			animator.SetTrigger("JumpTrigger");
			isOnTheRight = false;
			JumpSide(kCatLeftPositionZ);
		}
		else if (fishTransform.position.z < kRightZBoundary && !isOnTheRight){
			Debug.Log ("Need to jump right");
			animator.SetTrigger("JumpTrigger");
			isOnTheRight = true;
			JumpSide(kCatRightPositionZ);
		}
		transform.position = tPosition;
	}

	void FixedUpdate(){
		if (transform.position.x >= fishTransform.position.x - 1){
			// 猫逮到了鱼，利用ik系统完成抓鱼动画？
			// 广播关卡失败
			GameObject obj = GameObject.Find ("Main Camera");
			obj.SendMessage("ReceiveMessage", Judgement.kGameFailed);
		}
	}

	void OnAnimatorMove() {
		if (animator){
			Vector3 tPosition = transform.position;
			tPosition.x = Mathf.Lerp(tPosition.x, fishTransform.position.x + Random.Range(-2, 3), Time.deltaTime * speed);
			tPosition.x = tPosition.x < kMaxXFloat ? tPosition.x : kMaxXFloat;
			transform.position = tPosition;
		} else throw new UnityException("No Animator Found");
	}

	void JumpSide(float targetPositionZ){
		float digTime = Time.time - lastJumpTime;
		if (digTime < minJumpInteral)
			jumpContinueCount++;
		else
			jumpContinueCount = 0;
		if (jumpContinueCount < 3){
			iTween.MoveTo(gameObject, iTween.Hash("x", transform.position.x + 1, "z", targetPositionZ, "time", jumpTime));
		} else {
			iTween.MoveTo(gameObject, iTween.Hash ("x", fishTransform.position.z, "z", fishTransform.position.z, "time", 1));
		}
	}
}
