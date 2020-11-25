using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinManager : MonoBehaviour
{
    private float PRODUCE_TIME = 5f;
    private float _countDownTime;
    public Goblin GoblinObject;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _countDownTime = PRODUCE_TIME;
        CreateEnemy();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
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
