using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Inventory_Slot : MonoBehaviour, IPointerDownHandler, IDropHandler, IDragHandler, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField]
    Image itemImage;
    [SerializeField]
    TextMeshProUGUI quantityText;
    [SerializeField]
    Image outline;
    [SerializeField]
    private int slot;

    void Start()
    {
        itemImage.gameObject.SetActive(false);
        quantityText.gameObject.SetActive(false);
        getInventoryHolder().GetComponent<Inventory>().onInventoryChange += onChange;
        onChange();

        if (outline != null)    //it means this a player inventory slot bar, all other slots don't have an outline assigned so it's null
        {
            outline.enabled = false;
            Player_Inventory.onItemSelected += setOutlineEnable;
        }
    }

    void onChange()
    {
        int itemCode = getInventoryHolder().GetComponent<Inventory>().getItemCode(slot);

        if (itemCode != 0)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = ItemsList.getSprite(itemCode);
            quantityText.gameObject.SetActive(true);
            quantityText.text = getInventoryHolder().GetComponent<Inventory>().getQuantity(slot).ToString();
        }
        else
        {
            itemImage.gameObject.SetActive(false);
            quantityText.gameObject.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        int itemCode = getInventoryHolder().GetComponent<Inventory>().getItemCode(slot);
        int quantity = 0;

        if (eventData.button == PointerEventData.InputButton.Left)
            quantity = getInventoryHolder().GetComponent<Inventory>().getQuantity(slot);
        else if (eventData.button == PointerEventData.InputButton.Right)
            quantity = 1;

        FindObjectOfType<Inventory_Exchange>().dragStart(itemCode, quantity, this.gameObject);
    }

    public void OnDrop(PointerEventData eventData)     //when the drag ends
    {

        int itemCode = getInventoryHolder().GetComponent<Inventory>().getItemCode(slot);
        int quantity = getInventoryHolder().GetComponent<Inventory>().getQuantity(slot);

        FindObjectOfType<Inventory_Exchange>().dragEnd(itemCode, quantity, this.gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)     //in case a slot is just clicked but without any darg
    {
        int itemCode = getInventoryHolder().GetComponent<Inventory>().getItemCode(slot);
        int quantity = getInventoryHolder().GetComponent<Inventory>().getQuantity(slot);

        FindObjectOfType<Inventory_Exchange>().dragEnd(itemCode, quantity, this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)    //used for info slot image
    {
        int itemCode = getInventoryHolder().GetComponent<Inventory>().getItemCode(slot);
    }

    public void OnDrag(PointerEventData eventData)     //if we don't have this the start and end drag don't work; idk why
    {

    }

    void setOutlineEnable()
    {
        if (Player_Inventory.getSelectedSlot() == slot)
            outline.enabled = true;
        else
            outline.enabled = false;
    }

    public GameObject getInventoryHolder()          //the object that holds the inventory script
    {
        GameObject inventoryHolder = this.gameObject;

        while (inventoryHolder.GetComponent<Inventory>() == null)
            inventoryHolder = inventoryHolder.transform.parent.gameObject;

        return inventoryHolder;
    }

    public int getSlotNumber()
    {
        return slot;
    }

    void OnDestroy()
    {
        getInventoryHolder().GetComponent<Inventory>().onInventoryChange -= onChange;

        if (outline != null)
            Player_Inventory.onItemSelected -= setOutlineEnable;
    }
}
