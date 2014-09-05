using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class MovementWithAccelerometer : MonoBehaviour {
	public float speed = 100.0f;
	public float moveZSpeed = 50.0f;
	public float moveX = Input.acceleration.x;
	public float moveY = Input.acceleration.y;
	public float moveZ = Input.acceleration.z;
	public int zeroZFlag;
	public Vector3 forward;

	void Update() {		
		moveX = Input.acceleration.x * 1;
		moveY = Input.acceleration.y * 1;
		moveZ = (1 + (Input.acceleration.z));
		// need to figure out debounce
		//need to figure out how to make accelerometer faster
	CharacterController controller = GetComponent<CharacterController>();
		if (moveZ >= 0.04 || moveZ <= -0.04) {
			zeroZFlag = 1;			
				moveZ = moveZ * moveZSpeed; 	  //multiply by 40 to make it faster when going forward
				if (moveY >= 0) {		
					forward = transform.TransformDirection(moveX,0,moveZ);
					controller.SimpleMove (forward * speed);
				}
				if (moveY <= 0){
					forward = transform.TransformDirection(moveX,0,-moveZ);
					controller.SimpleMove (forward * speed);
				}
			}
			else {
				zeroZFlag = 0;  
			}
	}

	public float ReportMoveZ (){ // use this so that SendingToArduino knows where to get moveZ
		return moveZ;
	}
}
	