using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    [SerializeField]
    Sprite[] spriteArrayHelper;
    [SerializeField]
    string[] nameArrayHelper;
    [SerializeField]
    string[] descriptionArrayHelper;
    [SerializeField]
    int[] inventoryLimitHelper;      //max number per inventory slot for this item (ex 20 resources, 1 grappler)

    static Sprite[] spriteArray;
    static string[] nameArray;
    static string[] descriptionArray;
    static int[] inventoryLimit;

    void Awake()
    {
        spriteArray = spriteArrayHelper;
        nameArray = nameArrayHelper;
        descriptionArray = descriptionArrayHelper;
        inventoryLimit = inventoryLimitHelper;
    }

    public static Sprite getSprite(int itemCode)
    {
        return spriteArray[itemCode];
    }

    public static string getName(int itemCode)
    {
        return nameArray[itemCode];
    }

    public static string getDescription(int itemCode)
    {
        return descriptionArray[itemCode];
    }

    public static int getInventoryLimit(int itemCode)
    {
        return inventoryLimit[itemCode];
    }

    public static int getItemCode(string itemTag)
    {
        int itemCode = itemTag[5] - '0';
        itemCode = itemCode * 10 + itemTag[6] - '0';
        itemCode = itemCode * 10 + itemTag[7] - '0';

        return itemCode;
    }
}
