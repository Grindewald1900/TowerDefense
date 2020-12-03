using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void GotoSettings()
    {
        Debug.Log("Setting");
        GameObject.Find("MainMenu").gameObject.SetActive(false);
        GameObject.Find("OptionMenu").gameObject.SetActive(true);

    }
    
    public void GotoMainMenu()
    {
        Debug.Log("Main");
        GameObject.Find("MainMenu").gameObject.SetActive(true);
        GameObject.Find("OptionMenu").gameObject.SetActive(false);
    }
}
