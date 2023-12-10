using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Inventory : MonoBehaviour
{
    static int selectedInventorySlot;
    static GameObject playerInventoryHolder;
    [SerializeField]
    GameObject playerInventoryHolderHelper;
    KeyCode[] keyCodes = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 };
    public delegate void OnItemSelected();       //when a new inventory slot from the inventory bar is selected
    public static OnItemSelected onItemSelected;
    public delegate void OnItemDeselected();
    public static OnItemDeselected onItemDeselected;


    void Awake()
    {
        selectedInventorySlot = 0;
        playerInventoryHolder = playerInventoryHolderHelper;
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
        for (int i = 1; i <= 3; i++)
            if (Input.GetKeyDown(keyCodes[i - 1]))
            {
                selectedInventorySlot = i - 1;
                break;
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
}
