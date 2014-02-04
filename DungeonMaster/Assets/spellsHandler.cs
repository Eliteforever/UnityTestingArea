using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spellsHandler {
	public IDictionary<int, Spell> AllSpells = new Dictionary<int, Spell>();

	public spellsHandler()
	{
		spell1 s1 = new spell1 (); AllSpells [1] = s1;
		spell2 s2 = new spell2 (); AllSpells [2] = s2;
	}

	
}
