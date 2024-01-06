using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    protected int itemCode;
    static protected int selectedItemCode;
    static int[] chargingItems = { 17 };      //the list of items that work on charges, like batteries

    static int usedObjectItemCode;
    static GameObject usedObject;           //the object that is currently used (ex tools, weapons, building you are placing); is null if it is an object you won't have in hands
                                            //when it is selected from inventory (ex resource)

    public static bool checkChargeableItem(int itemCode)     //checks if a given item got a charges, like the battery
    {
        for (int i = 0; i < chargingItems.Length; i++)
            if (chargingItems[i] == itemCode)
                return true;

        return false;
    }

    public static void destroyUsedObject()   //destroys the prefab of the object you have in your hands
    {
        if (usedObject != null)
        {
            Destroy(usedObject);
            usedObject = null;
            usedObjectItemCode = 0;
        }
    }

    public static void setUsedObject(GameObject usedObject, int usedObjectItemCode)
    {
        Item.usedObject = usedObject;
        Item.usedObjectItemCode = usedObjectItemCode;
    }

    public static GameObject getUsedObject()
    {
        return usedObject;
    }

    public static int getUsedObjectItemCode()
    {
        return usedObjectItemCode;
    }

    public static void setSelectedItemCode(int code)
    {
        selectedItemCode = code;
    }

    public static int getSelectedItemCode()
    {
        return selectedItemCode;
    }
}
