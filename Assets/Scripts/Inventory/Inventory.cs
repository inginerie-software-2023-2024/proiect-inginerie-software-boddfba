using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
{
    [SerializeField]
    int[] itemCodeArray;
    [SerializeField]
    int[] quantityArray;
    public delegate void OnInventoryChange();
    public OnInventoryChange onInventoryChange;

    void Awake()
    {

    }

    public int addItem(int itemCode, int quantity)
    {
        int inventoryLimit = ItemsList.getInventoryLimit(itemCode);
        int addedSlot = -1; //this is used for the items that can be only one per slot so when you add it adds maximum to one slot; used for ex for batteries to know the slot and set slot charge

        for (int i = 0; i < itemCodeArray.Length; i++)
            if (itemCodeArray[i] == itemCode)
            {
                if (quantityArray[i] + quantity < inventoryLimit)
                {
                    quantityArray[i] += quantity;
                    quantity = 0;
                }
                else
                {
                    quantity -= inventoryLimit - quantityArray[i];
                    quantityArray[i] = inventoryLimit;
                }

                if (quantity == 0)
                    break;
            }

        if (quantity != 0)         //after filling all slots that already got this item, if we still have remaining quantity we search for a free slot to add
            for (int i = 0; i < itemCodeArray.Length; i++)
                if (itemCodeArray[i] == 0)
                {
                    if (quantity <= inventoryLimit)
                    {
                        itemCodeArray[i] = itemCode;
                        quantityArray[i] = quantity;
                        quantity = 0;
                        addedSlot = i;
                    }
                    else
                    {
                        itemCodeArray[i] = itemCode;
                        quantity -= inventoryLimit;
                        quantityArray[i] = inventoryLimit;
                    }

                    if (quantity == 0)
                        break;
                }

        onInventoryChange();
        return addedSlot;     //-1 if nothing was added; if a certain quantity was added, and some dropped, it still returns the item slot where it was added
    }

    public void consumeItem(int itemCode, int quantity)
    {
        int quantityLeft = quantity;

        for (int i = 0; i < itemCodeArray.Length; i++)
            if (itemCodeArray[i] == itemCode)
            {
                if (quantityArray[i] - quantityLeft >= 0)
                {
                    quantityArray[i] -= quantityLeft;
                    quantityLeft = 0;
                }
                else
                {
                    quantityLeft -= quantityArray[i];
                    quantityArray[i] = 0;
                }

                if (quantityLeft == 0)
                    break;
            }

        onInventoryChange();
    }

    void checkEmpty()
    {
        for (int i = 0; i < itemCodeArray.Length; i++)
            if (quantityArray[i] == 0)
            {
                itemCodeArray[i] = 0;
            }
    }

    public void decreaseQuantity(int quantity, int slot)    //we know the slot 
    {
        quantityArray[slot] -= quantity;
        onInventoryChange();
    }

    public int getTotalQuantity(int itemCode)      //returns the total quantity of a given itemCode
    {
        int quantity = 0;

        for (int i = 0; i < itemCodeArray.Length; i++)
            if (itemCodeArray[i] == itemCode)
                quantity += quantityArray[i];

        return quantity;
    }

    public void executeOnInventoryChange()
    {
        onInventoryChange();
    }

    public int getNumberOfSlots()
    {
        return itemCodeArray.Length;
    }

    public int getItemCode(int slot)    //return the item code for the given inventory slot
    {
        return itemCodeArray[slot];
    }

    public int getQuantity(int slot)
    {
        return quantityArray[slot];
    }

    public void setSlot(int slot, int itemCode, int quantity)      //sets the code and quantity for the given slot
    {
        if (quantity == 0)
            itemCodeArray[slot] = 0;
        else
            itemCodeArray[slot] = itemCode;

        quantityArray[slot] = quantity;

        onInventoryChange();
    }

    void OnDestroy()
    {
        onInventoryChange -= checkEmpty;
    }
}
