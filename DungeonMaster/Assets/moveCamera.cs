using UnityEngine;
using System.Collections;

public class moveCamera : MonoBehaviour {

	public GameObject Target;
	public GameObject FatedCameraPosition;

	public bool LockRotation;
	public bool LockMovement;

	public float MoveSpeed = 10f;

	public float dist;

	private float movespd = 10;
	private float windUp = 0;
	
	void Start () {
	
		}

	void LateUpdate () {
			if (!LockMovement) {
						//Set dist as distance between Camera and Camera.Target
						dist = Vector3.Distance (FatedCameraPosition.transform.position, transform.position);
		
						//Check if the speed the camera wants to move is not higher than the maximum movement speed
						if (((movespd * (dist + 2f) * Time.deltaTime) * windUp) > MoveSpeed) {
								movespd = MoveSpeed;
						}
		
						//Determine movement speed
						float step = (movespd * (dist + 0.2f) * Time.deltaTime) * windUp;

						//If the distance between Camera and Camera.Target is not 0, move Camera
						if (dist > 0) {

								transform.position = Vector3.MoveTowards (transform.position, FatedCameraPosition.transform.position, step);
						} else {
								windUp = 0;
						}
					
						if (!LockRotation) {
								//Make Camera look at Camera.Target
								transform.LookAt (Target.transform.position);
						}

						if (windUp < 1f)
								windUp += 0.01f;
				}
	}
}
