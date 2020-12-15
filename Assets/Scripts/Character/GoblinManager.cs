using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinManager : MonoBehaviour
{
    private float PRODUCE_TIME = 3f;
    private float _countDownTime;
    public static GoblinManager SharedInstance;
    public Goblin GoblinObject;
    public bool isGaming;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _countDownTime = PRODUCE_TIME;
        SharedInstance = this;
        isGaming = true;
        CreateEnemy();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isGaming)
        {
            return;
        }
        if (_countDownTime <= 0)
        {
            CreateEnemy();
            _countDownTime = PRODUCE_TIME;
        }
        _countDownTime -= Time.deltaTime;
    }

    private void CreateEnemy()
    {
        var goblin = ObjectGenerater.SharedInstance.GetGoblins();
        if (ReferenceEquals(goblin, null))
            goblin = Instantiate(GoblinObject);
        goblin.ResetEnemy();
    }

    public void SetTime(float time)
    {
        PRODUCE_TIME = time;
    }
}
