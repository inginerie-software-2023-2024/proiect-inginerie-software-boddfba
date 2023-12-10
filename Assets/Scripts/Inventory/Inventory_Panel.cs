using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Panel : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryTab;
    static string status;

    void Start()
    {
        status = "CLOSED";
        inventoryTab.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (status.Equals("CLOSED"))
            {
                 open();
            }
            else
            {
                close();
            }
        }
    }

    public void open()
    {
        inventoryTab.SetActive(true);
        status = "OPENED";
    }

    public void close()
    {
        inventoryTab.SetActive(false);
        status = "CLOSED";
    }

    public static string getInventoryStatus()
    {
        return status;
    }
}
