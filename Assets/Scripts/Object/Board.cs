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

    private void Start()
    {
        SharedInstance = this;
        obsList = new List<Obstacle>();
        obstacles = GameObject.FindGameObjectsWithTag(InitConfig.TagObstacle);
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
        InitConfig.SharedInstance.CANNON_TYPE = type;
        foreach (var item in obsList)
        {
            item.HighLight();
        }
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
}
