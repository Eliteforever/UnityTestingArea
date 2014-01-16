using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameHandler : MonoBehaviour {

	public List<GameObject> NPCList = new List<GameObject>();
	
	void UpdateNPCList()
	{
		NPCList.Clear();

		GameObject[] objects = GameObject.FindGameObjectsWithTag( "NPC" );

		foreach (GameObject go in objects)
		{
			NPCList.Add(go);
			//print (go.
		}
	}

	// Use this for initialization
	void Start () {
		UpdateNPCList ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
