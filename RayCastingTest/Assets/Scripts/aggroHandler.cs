using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class aggroHandler : MonoBehaviour {

	public List<aggroClass> AggroList = new List<aggroClass>();
	private bool HasAggro;

	// Use this for initialization
	void Start () {
	
	}
	
	void PushThreat(int senderGUID, int enemyGUID, decimal amount)
	{
		bool exists = false;
		
		foreach (aggroClass a in AggroList)
		{
			if (a.thisGUID == senderGUID)
			{
				a.Threat += amount;
				exists = true;
			}
		}
		
		if (!exists)
		{
			aggroClass a = new aggroClass(senderGUID, enemyGUID, amount);
			AggroList.Add(a);
		}			
	}
	
	// Update is called once per frame
	void Update () {

	}
}
