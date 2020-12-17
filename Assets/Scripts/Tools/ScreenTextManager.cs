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
    public TMP_Text MeshProSpeed;
    public Button BtnMain;
    public Button BtnRestart;
    public Button BtnSpeedUp;
    public Button BtnSpeedDown;
    private bool isShowMenu;
    private int speed;
    private float timeScale;


    // Start is called before the first frame update
    private void Start()
    {
        SharedInstance = this;
        isShowMenu = false;
        speed = 0;
        timeScale = 1;
        BtnRestart.onClick.AddListener(RestartGame);
        BtnMain.onClick.AddListener(LoadMainMenu);
        BtnSpeedUp.onClick.AddListener(SpeedUp);
        BtnSpeedDown.onClick.AddListener(SpeedDown);

        MeshProSpeed.text = (speed + 4).ToString();
        ShowGameMenu(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            ShowGameMenu(!isShowMenu);
        }
    }

    public void ShowGameMenu(bool isShow)
    {
        isShowMenu = isShow;
        Debug.Log("Time:" + timeScale);
        Time.timeScale = isShow ? 0.1f : timeScale;
        BtnMain.gameObject.SetActive(isShow);
        BtnRestart.gameObject.SetActive(isShow);
        BtnSpeedUp.gameObject.SetActive(isShow);
        BtnSpeedDown.gameObject.SetActive(isShow);
        MeshProSpeed.gameObject.SetActive(isShow);
    }

    public void RestartGame()
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public IEnumerator ClearText(int sec)
    {
        yield return new WaitForSeconds(sec);
        ScreenTextManager.SharedInstance.MeshProHint.text = "";
    }

    public void SpeedUp()
    {
        speed++;
        timeScale = 1 + speed * 0.3f;
        MeshProSpeed.text = (speed + 4).ToString();
        Time.timeScale = timeScale;
    }
    
    public void SpeedDown()
    {
        if(0.3 * (speed - 1) < -1)
            return;
        speed--;
        timeScale = 1 + speed * 0.3f;
        MeshProSpeed.text = (speed + 4).ToString();
        Time.timeScale = timeScale;
    }

    

}
