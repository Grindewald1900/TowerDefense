using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectGenerater : MonoBehaviour
{
    public Goblin goblinObject1;
    public Goblin goblinObject2;
    public Goblin goblinObject3;

    public List<Goblin> goblinList1;
    public List<Goblin> goblinList2;
    public List<Goblin> goblinList3;

    public static ObjectGenerater SharedInstance;
    private int _goblinAmount;


    private void Awake()
    {
        SharedInstance = this;
        _goblinAmount = 50;
    }

    private void Start()
    {
        goblinList1 = new List<Goblin>();
        goblinList2 = new List<Goblin>();
        goblinList3 = new List<Goblin>();
        for (var i = 0; i < _goblinAmount; i++)
        {
            var goblin1 = Instantiate(goblinObject1);
            var goblin2 = Instantiate(goblinObject2);
            var goblin3 = Instantiate(goblinObject3);

            goblin1.gameObject.SetActive(false);
            goblin2.gameObject.SetActive(false);
            goblin3.gameObject.SetActive(false);

            goblinList1.Add(goblin1);
            goblinList2.Add(goblin2);
            goblinList3.Add(goblin3);

        }
    }

    public Goblin GetGoblins(int type)
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
        switch (type)
        {
            case 1:
                return  goblinList1.FirstOrDefault(t => !t.gameObject.activeInHierarchy);
            case 2:
                return  goblinList2.FirstOrDefault(t => !t.gameObject.activeInHierarchy);
            case 3:
                return  goblinList3.FirstOrDefault(t => !t.gameObject.activeInHierarchy);
            default:
                return  goblinList1.FirstOrDefault(t => !t.gameObject.activeInHierarchy);
        }
    }

    public void ResetGame()
    {
        for (var i = 0; i < _goblinAmount; i++)
        {
            goblinList1[i].gameObject.SetActive(false);
            goblinList2[i].gameObject.SetActive(false);
            goblinList3[i].gameObject.SetActive(false);

        }
    }
}
