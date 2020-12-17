using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinManager : MonoBehaviour
{
    private float PRODUCE_E1_TIME = 3f;
    private float PRODUCE_E2_TIME = 5f;
    private float PRODUCE_E3_TIME = 10f;
    private float _countDownTime1, _countDownTime2, _countDownTime3;
    
    public static GoblinManager SharedInstance;
    public Goblin GoblinObject1;
    public Goblin GoblinObject2;
    public Goblin GoblinObject3;

    public bool isGaming;
    public bool isEnemy2;
    public bool isEnemy3;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _countDownTime1 = PRODUCE_E1_TIME;
        _countDownTime2 = PRODUCE_E2_TIME;
        _countDownTime3 = PRODUCE_E3_TIME;
        SharedInstance = this;
        isGaming = true;
        isEnemy2 = false;
        isEnemy3 = false;
        // CreateEnemy(1);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isGaming)
        {
            return;
        }
        if (_countDownTime1 <= 0) {
            CreateEnemy(1);
            _countDownTime1 = PRODUCE_E1_TIME;
        }
        if (_countDownTime2 <= 0) {
            CreateEnemy(2);
            _countDownTime2 = PRODUCE_E2_TIME;
        }
        if (_countDownTime3 <= 0) {
            CreateEnemy(3);
            _countDownTime3 = PRODUCE_E3_TIME;
        }
        _countDownTime1 -= Time.deltaTime;
        if(isEnemy2)
            _countDownTime2 -= Time.deltaTime;
        if(isEnemy3)
            _countDownTime3 -= Time.deltaTime;

    }

    private void CreateEnemy(int type)
    {
        var goblin = ObjectGenerater.SharedInstance.GetGoblins(type);
        if (ReferenceEquals(goblin, null))
            switch (type)
            {
                case  1:
                    goblin = Instantiate(GoblinObject1);
                    break;
                case  2:
                    goblin = Instantiate(GoblinObject2);
                    break;
                case  3:
                    goblin = Instantiate(GoblinObject3);
                    break;

            }
        InitConfig.SharedInstance.EnemyCounter(type);
        goblin.gameObject.transform.position = new Vector3(15, 1, 1);
        goblin.ResetEnemy();
    }
    
}
