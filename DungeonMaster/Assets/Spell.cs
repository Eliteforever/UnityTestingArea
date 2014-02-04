using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Spell {

	public int SpellID;
	public string spellName;
	public string spellDescription;
	public int resourceType;
	public int resourceCost;
	public int CastTime;

	public Spell()
	{

	}

	virtual public void Cast(abstractPlayableCharacter sender, GameObject target)
	{

	}
}

public class spell1 : Spell{

	public spell1()
	{
		this.SpellID = 1;
		this.spellName = "pew pew";
		this.spellDescription = "pew pew around you dealing pew pew damage";
	}

	public override void Cast(abstractPlayableCharacter sender, GameObject target)
	{
		Debug.Log ("dealing " + (sender.attackDamage - 30) + " physical damage to the enemy!");
	}
}

public class spell2 : Spell{

	public spell2()
	{
		this.SpellID = 2;
	}
	
	public override void Cast(abstractPlayableCharacter sender, GameObject target)
	{
		
	}
}
