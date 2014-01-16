using UnityEngine;
using System.Collections;

public class aggroClass {

	public int thisGUID;
	public int enemyGUID;
	public decimal Threat;

	public aggroClass(int tg, int eg, decimal t)
	{
		this.thisGUID = tg;
		this.enemyGUID = eg;
		this.Threat = t;
	}
}
