using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use %Pathfinding
using Pathfinding;
using System.Collections.Generic;

public class AstarAI : MonoBehaviour {
	//The point to move to
	public Vector3 targetPosition;
	public Transform orientation;
	public List<GameObject> AggroList = new List<GameObject>();

	private Transform o;
	
	private Seeker seeker;
	private CharacterController controller;

	private GameObject player;

	private bool IsInLos = false;
	
	//The calculated path
	public Path path;
	
	//The AI's speed per second
	public float speed = 100;

	public int RotationSpeed = 180;
	
	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;

	public void Start () {
		//StartCoroutine("FP");
	}

	public IEnumerator FP()		
	{	
		player = GameObject.Find ("Player");
		while(true)			
		{			
			yield return new WaitForSeconds(0.3f); // wait half a second			
			FindPath();			
		}
		
	}

	private void FindPath()
	{
		seeker = GetComponent<Seeker>();
		controller = GetComponent<CharacterController>();
		
		targetPosition.x = player.transform.position.x;
		targetPosition.y = player.transform.position.y;
		targetPosition.z = player.transform.position.z;			
		
		//Start a new path to the targetPosition, return the result to the OnPathComplete function
		seeker.StartPath (transform.position,targetPosition, OnPathComplete);
		}
	
	public void OnPathComplete (Path p) {
		Debug.Log ("Yey, we got a path back. Did it have an error? "+p.error);
		if (!p.error) {
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 0;
		}
	}
	
	public void LateUpdate () {
		if (path == null) {
			return;
		}
		
		if (currentWaypoint >= path.vectorPath.Count) {
			Debug.Log ("End Of Path Reached");
			return;
		}

		Vector3 playerPos = player.transform.position;
		Vector3 foePos = transform.position;
		Vector3 dir;
		
		RaycastHit hitInfo;
		
		if (Physics.Linecast (foePos, playerPos, out hitInfo)) {
						if (hitInfo.transform.tag == "Player") {
								dir = (playerPos - foePos).normalized;
								dir *= speed * Time.fixedDeltaTime;
								controller.SimpleMove (dir);
								print ("Alalalala!");
								IsInLos = true;
								RotateToTarget (playerPos, false);
						} else {
								IsInLos = false;
						}
				}

		if (!IsInLos) {
		
						//Direction to the next waypoint
						dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;
						Vector3 lookdir = dir;
						lookdir.y = player.transform.position.y;
						dir *= speed * Time.fixedDeltaTime;
						controller.SimpleMove (dir);

						RotateToTarget(path.vectorPath[currentWaypoint], false);
						
						if (Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]) < nextWaypointDistance) {
								currentWaypoint++;
								return;
						}
		}
	}

	public void RotateToTarget(Vector3 target, bool IfReset)
	{
		float r = 20;
		if (!IsInLos && !IfReset)
				r = RotationSpeed * Time.deltaTime;

		target.y = transform.position.y;
		
		Quaternion wantFace = Quaternion.LookRotation(target - transform.position);

		transform.rotation = Quaternion.RotateTowards(transform.rotation,
		                                              wantFace, r);
	}
} 
















