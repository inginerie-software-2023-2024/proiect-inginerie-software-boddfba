using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string scenename;
    [SerializeField]
    private int[] itemCodesRequired;
    [SerializeField]
    private int[] itemQuantitiessRequired;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && FindAnyObjectByType<Inventory>().verifyItemsExistence(itemQuantitiessRequired, itemCodesRequired))
        {
            FindAnyObjectByType<Inventory>().saveData();
            SceneManager.LoadScene(scenename);
        }
    }
}
