using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        deleteInventoryFromPreviousSessions();
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    void deleteInventoryFromPreviousSessions()
    {
        for (int i = 0; i < 16; i++)
        {
            PlayerPrefs.SetInt("Inventory_Item_Code_" + i, 0);
            PlayerPrefs.SetInt("Inventory_Item_Quantity_" + i, 0);
        }
    }
}
