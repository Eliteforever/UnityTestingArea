using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class itemsHandler {

	public IDictionary<int, Item> AllItems = new Dictionary<int, Item>();
	
	public itemsHandler () {
		Item item1 = new Item (1523, "Shoulders of Epicness", "This item is so epic!", "LORE TEXT IS EPIC ASWELL!", 5, 1337, 1337, 1337, 0, 0, 0, 0, 0, 0, 0, 0, 0);
		Item item2 = new Item (256, "Leggins of Awesomeness", "This item is so awesome!", "LORE TEXT IS AWESOME ASWELL!", 5, 0, 0, 0, 256, 256, 256, 0, 0, 0, 0, 0, 0);
		AllItems.Add (1523, item1);
		AllItems.Add (256, item2);
	}
}
