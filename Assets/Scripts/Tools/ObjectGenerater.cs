using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectGenerater : MonoBehaviour
{
    public Goblin goblinObject;
    public List<Goblin> goblinList;
    public static ObjectGenerater SharedInstance;
    private int _goblinAmount;


    private void Awake()
    {
        SharedInstance = this;
        _goblinAmount = 5;
    }

    private void Start()
    {
        goblinList = new List<Goblin>();
        for (var i = 0; i < _goblinAmount; i++)
        {
            var goblin = Instantiate(goblinObject);
            goblin.gameObject.SetActive(false);
            goblinList.Add(goblin);
        }
    }

    public Goblin GetGoblins()
    {
        // for (int i = 0; i < _goblinAmount; i++)
        // {
        //     if (!goblinList[i].gameObject.activeInHierarchy)
        //     {
        //         return goblinList[i];
        //     }
        // }
        //
        // return Instantiate(goblinObject);
        return  goblinList.FirstOrDefault(t => !t.gameObject.activeInHierarchy);
    }
}
