using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Inventory : MonoBehaviour
{
    [SerializeField]
    Image infoSlotImage;     //the top image that shows the hovered item
    [SerializeField]
    TextMeshProUGUI hoveredItemName;
    [SerializeField]
    TextMeshProUGUI hoveredItemDescription;
    static int selectedInventorySlot;
    static GameObject playerInventoryHolder;
    [SerializeField]
    GameObject playerInventoryHolderHelper;
    KeyCode[] keyCodes = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };

    public delegate void OnItemSelected();       //when a new inventory slot from the inventory bar is selected
    public static OnItemSelected onItemSelected;
    public delegate void OnItemDeselected();
    public static OnItemDeselected onItemDeselected;



    void Awake()
    {
        infoSlotImage.enabled = false;
        hoveredItemName.enabled = false;
        hoveredItemDescription.enabled = false;
        selectedInventorySlot = 0;
        playerInventoryHolder = playerInventoryHolderHelper;
        onItemDeselected += Item.destroyUsedObject;
    }

    private void Start()
    {
       
    }

    void Update()
    {
        selectInventorySlot();
    }

    void selectInventorySlot()     //when you press a numeric key on keyboard it will select that slot in inventory bar
    {
        bool newSelection = false;

        for (int i = 1; i <= 9; i++)
            if (Input.GetKeyDown(keyCodes[i - 1]))
            {
                selectedInventorySlot = i - 1;
                newSelection = true;
                break;
            }

        if (newSelection || getPlayerInventoryHolder().GetComponent<Inventory>().getItemCode(selectedInventorySlot) != Item.getSelectedItemCode())
        {
            Item.setSelectedItemCode(getPlayerInventoryHolder().GetComponent<Inventory>().getItemCode(selectedInventorySlot));
            onItemDeselected();
            onItemSelected();
        }
    }

    public void setHoveredItem(int itemCode)   //used to show the sprite, name and description for the hovered item
    {
        if (itemCode != 0)
        {
            infoSlotImage.enabled = true;
            hoveredItemName.enabled = true;
            hoveredItemDescription.enabled = true;
            infoSlotImage.sprite = ItemsList.getSprite(itemCode);
            hoveredItemName.text = ItemsList.getName(itemCode);
            hoveredItemDescription.text = ItemsList.getDescription(itemCode);
        }
        else
        {
            infoSlotImage.enabled = false;
            hoveredItemName.enabled = false;
            hoveredItemDescription.enabled = false;
        }
    }
    public static int getSelectedSlot()
    {
        return selectedInventorySlot;
    }

    public static GameObject getPlayerInventoryHolder()          //the object that holds the player invenotry script holds also the inventory
    {
        return playerInventoryHolder;
    }

    void OnDestroy()
    {
        onItemDeselected -= Item.destroyUsedObject;
    }
}
