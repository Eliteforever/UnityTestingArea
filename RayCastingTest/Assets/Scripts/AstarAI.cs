using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use %Pathfinding
using Pathfinding;
public class AstarAI : MonoBehaviour {
	//The point to move to
	public Vector3 targetPosition;
	public Transform orientation;
	private Transform o;
	
	private Seeker seeker;
	private CharacterController controller;

	private GameObject player;

	private bool IsInLos = false;
	
	//The calculated path
	public Path path;
	
	//The AI's speed per second
	public float speed = 100;
	
	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	
	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;
	
	public void Start () {
		player = GameObject.Find ("Player");

		StartCoroutine("FP");
	}

	private IEnumerator FP()		
	{		
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
	
	public void FixedUpdate () {
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
						
						transform.LookAt(path.vectorPath[currentWaypoint + 1]);
						//transform.rotation = Quaternion.Lerp(transform.rotation, orientation.rotation, Time.deltaTime * 20);
					
						//Check if we are close enough to the next waypoint
						//If we are, proceed to follow the next waypoint
						if (Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]) < nextWaypointDistance) {
								currentWaypoint++;
								return;
						}
		}
	}
} 
















