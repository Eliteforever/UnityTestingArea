using UnityEngine;
using System.Collections;

public class raycastScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}

	GameObject player;

	// Update is called once per frame
	void Update () {
		Vector3 playerPos = player.transform.position;
		Vector3 foePos = transform.position;
		Vector3 direction = (foePos - playerPos).normalized;

		RaycastHit hitInfo;

		if (Physics.Linecast (foePos, playerPos, out hitInfo)) {
						if (hitInfo.transform.tag == "Player") {
							transform.LookAt(playerPos);
						}

						//print (hitInfo.collider.gameObject.ToString());
				}

		Debug.DrawRay(playerPos, direction * 20);
	}
}
