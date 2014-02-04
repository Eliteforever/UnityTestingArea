using UnityEngine;
using System.Collections;

public class playerHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		abstractPlayableCharacter Player1 = new abstractPlayableCharacter ();

		itemsHandler iH = new itemsHandler ();	
		spellsHandler sH = new spellsHandler ();	

		Player1.WearingList["Shoulders"] = iH.AllItems [1523];
		Player1.WearingList["Legs"] = iH.AllItems [256];

		Player1.InventoryList [1] = iH.AllItems [1523];
		Player1.RefreshStats ();

		Player1.SpellBook [1] = sH.AllSpells [1];

		Player1.SpellBook[1].Cast(Player1, GameObject.Find("CameraTarget"));
		//print (Player1.SpellBook[1].spellName);

	}
}
