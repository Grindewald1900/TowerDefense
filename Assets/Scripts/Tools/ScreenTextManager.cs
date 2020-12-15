using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScreenTextManager : MonoBehaviour
{
    public static ScreenTextManager SharedInstance;
    public TMP_Text MeshProScore;
    public TMP_Text MeshProLevel;
    public TMP_Text MeshProHint;
    public Button BtnMain;
    public Button BtnRestart;
    private bool isShowMenu;


    // Start is called before the first frame update
    private void Start()
    {
        SharedInstance = this;
        ShowGameMenu(false);
        isShowMenu = false;
        BtnRestart.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            ShowGameMenu(!isShowMenu);
        }
    }

    private void FixedUpdate()
    {
        
    }
    

    public void ShowGameMenu(bool isShow)
    {
        isShowMenu = isShow;
        Time.timeScale = isShow ? 0.1f : 1;
        BtnMain.gameObject.SetActive(isShow);
        BtnRestart.gameObject.SetActive(isShow);
    }

    public void RestartGame()
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
