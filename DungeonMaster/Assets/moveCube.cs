using UnityEngine;
using System.Collections;



public class moveCube : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private Vector3 currPos;

	void LateUpdate()
	{
		float translationX = Input.GetAxis("Vertical") * 0.5f;
		float translationZ = Input.GetAxis("Horizontal") * 0.5f;

		transform.Translate(translationX *= -1, 0, translationZ);
	}
}
