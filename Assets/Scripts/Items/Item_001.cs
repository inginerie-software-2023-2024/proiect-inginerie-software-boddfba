using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_001 : Item
{
    [SerializeField]
    private float healthIncrease;
    void Update()
    {
        if (itemCode == selectedItemCode)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && Inventory_Panel.getInventoryStatus() == "CLOSED")
                consume();
        }
    }

    private void consume()
    {
        FindAnyObjectByType<PlayerStats>().changeHealth(healthIncrease);
        int playerInventorySlot = Player_Inventory.getSelectedSlot();
        Player_Inventory.getPlayerInventoryHolder().GetComponent<Inventory>().decreaseQuantity(1, playerInventorySlot);
    }
}
