using UnityEngine;
using System.Collections;

public class Item {

	public int ItemID;
	public Mesh ItemMesh;

	public string itemName;
	public string itemDescription;
	public string itemLoreText;
	public int rarity;
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
	public int mana;

	public Item(int id, string iN, string iD, string iLT, int rar, int ad, int arm, int mr, int ap, int cr, int dodg, int blck, int parr, int def, float aS, int hp, int mp)
	{
		this.ItemID = id;
		this.itemName = iN;
		this.itemDescription = iD;
		this.itemLoreText = iLT;
		this.rarity = rar;
		this.attackDamage = ad;
		this.armor = arm;
		this.magicResist = mr;
		this.magicPower = ap;
		this.crit = cr;
		this.dodge = dodg;
		this.block = blck;
		this.parry = parr;
		this.defense = def;
		this.attackSpeed = aS;
		this.health = hp;
		this.mana = mp;
	}
}
