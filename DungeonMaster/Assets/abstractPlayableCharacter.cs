using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class abstractPlayableCharacter{

	public IDictionary<string, Item> WearingList = new Dictionary<string, Item>();
	public IDictionary<int, Item> InventoryList = new Dictionary<int, Item>();
	public IDictionary<int, Spell> SpellBook = new Dictionary<int, Spell> ();
	//public IDictionary<int, Buff> BuffList = new Dictionary<int, Buff>();
	//public IDictionary<int, DeBuff> DeBuffList = new Dictionary<int, DeBuff>();

	public int playerID;
	public string name;

	public int attackDamage;
	public int armor;
	public int magicResist;
	public int magicPower;
	public int crit;
	public int dodge;
	public int block;
	public int parry;
	public int defense;
	public float attackSpeed;
	public int health;
	public int resource;
	public int resourceType;

	public abstractPlayableCharacter()
	{

	}

	public void RefreshStats()
	{
		foreach (KeyValuePair<string, Item> item in WearingList)
		{
			this.attackDamage += item.Value.attackDamage;
			this.armor += item.Value.armor;
			this.magicResist += item.Value.magicResist;
			this.magicPower += item.Value.magicPower;
			this.crit += item.Value.crit;
			this.dodge += item.Value.dodge;
			this.block += item.Value.block;
			this.parry += item.Value.parry;
			this.defense += item.Value.defense;
			this.attackSpeed += item.Value.attackSpeed;
			this.health += item.Value.health;
			if (this.resourceType == 0)
				this.resource += item.Value.mana;
		}
	}
}
