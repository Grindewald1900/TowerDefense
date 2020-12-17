using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[] obstacles;
    private List<Obstacle> obsList;
    public static Board SharedInstance;
    public AudioSource Source;

    private void Start()
    {
        Debug.Log("Music play");
        SharedInstance = this;
        Source = gameObject.GetComponent<AudioSource>();
        obsList = new List<Obstacle>();
        obstacles = GameObject.FindGameObjectsWithTag(InitConfig.TagObstacle);
        StartCoroutine(PlayBGM());
        // InitConfig.SharedInstance.gameLevel = 1;
        foreach (var obj in obstacles)
        {
            obsList.Add(obj.GetComponent<Obstacle>());
            // _obstacles.Append(obj.GetComponent<Obstacle>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(gameObject.name + " : " + other.gameObject.name);
    }

    public void ShowAvailableSlice(int type)
    {
        Debug.Log("ShowAvailableSlice");
        InitConfig.SharedInstance.CANNON_TYPE = type;
        foreach (var item in obsList)
        {
            item.HighLight();
        }
    }

    public void Heal()
    {
        if(InitConfig.SharedInstance.score < 200)
            return;
        InitConfig.SharedInstance.score -= 200;
        ScreenTextManager.SharedInstance.MeshProScore.text = "COINS:" + InitConfig.SharedInstance.score;
        InitConfig.SharedInstance.passCount -= 1;
        PlayerStats.Instance.Heal(1);
    }

    public void ResetBoardColor()
    {
        foreach (var item in obsList)
        {
            item.Normal();
        }
    }

    public void ResetBoard()
    {
        
    }

    public void RemoveSlice(Obstacle obstacle)
    {
        obsList.Remove(obstacle);
    }

    IEnumerator PlayBGM()
    {
        yield return new WaitForSeconds(2);
        Source.Play();
        Debug.Log("Music play2");

    }
}
