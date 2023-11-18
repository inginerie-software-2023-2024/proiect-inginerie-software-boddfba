using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMainToDessert : MonoBehaviour
{
    // Start is called before the first frame update
    public string scenename;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(scenename);
        }
    }
}
