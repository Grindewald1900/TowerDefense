using System.Collections;
using System.Collections.Generic;
using Scrpts.ToolScripts;
using UnityEngine;

public class InitConfig : MonoBehaviour
{
    public static InitConfig SharedInstance;

    public const int BoardWidth = 16;
    public const int BoardHeight = 20;
    public const int CannonType1 = 101;
    public const int CannonType2 = 102;
    public const int CannonType3 = 103;
    public Dictionary<string, int> enemyCount;
    public const int BaseCost = 50;

    public const string TagObstacle = "Obstacle";

    public int gameLevel = 1;
    public int CANNON_TYPE = 0;
    public int DifficultLevel = 1;
    public int score;
    public int passCount;

    private int Level1Enemy1, Level2Enemy1, Level3Enemy1, Level2Enemy2, Level3Enemy2, Level3Enemy3;
    


    // Start is called before the first frame update

    private void Start()
    {
        SharedInstance = this;
        score = 200;
        passCount = 0;
        enemyCount = new Dictionary<string, int>();
        enemyCount.Add("Level1Goblin1", 30);
        enemyCount.Add("Level2Goblin1", 40);
        enemyCount.Add("Level3Goblin1", 50);
        enemyCount.Add("Level2Goblin2", 10);
        enemyCount.Add("Level3Goblin2", 20);
        enemyCount.Add("Level3Goblin3", 5);

        Level1Enemy1 = enemyCount["Level1Goblin1"];
        Level2Enemy1 = enemyCount["Level2Goblin1"];
        Level3Enemy1 = enemyCount["Level3Goblin1"];
        Level2Enemy2 = enemyCount["Level2Goblin2"];
        Level3Enemy2 = enemyCount["Level3Goblin2"];
        Level3Enemy3 = enemyCount["Level3Goblin3"];
    }

    public void EnemyCounter(int enemyType)
    {
        Debug.Log("Type: " + enemyType +"Level:" + gameLevel + " G1:" + Level3Enemy1 + " G2:" + Level3Enemy2 + " G3:"+Level3Enemy3 );
        switch (gameLevel)
        {
            case 1:
                Level1Enemy1--;
                if (Level1Enemy1 <= 0)
                {
                    gameLevel = 2;
                    ScreenTextManager.SharedInstance.MeshProHint.text = "Level Completed!";
                    ScreenTextManager.SharedInstance.MeshProLevel.text = "LEVEL 2";
                    StartCoroutine(ScreenTextManager.SharedInstance.ClearText(2));
                    GoblinManager.SharedInstance.isEnemy2 = true;
                }
                break;
            case 2:
                if (enemyType == 1)
                    Level2Enemy1--;
                if (enemyType == 2)
                    Level2Enemy2--;
                if (Level2Enemy1 <= 0 && Level2Enemy2 <= 0)
                {
                    gameLevel = 3;
                    ScreenTextManager.SharedInstance.MeshProHint.text = "Level Completed!";
                    ScreenTextManager.SharedInstance.MeshProLevel.text = "LEVEL 3";
                    StartCoroutine(ScreenTextManager.SharedInstance.ClearText(2));
                    GoblinManager.SharedInstance.isEnemy3= true;
                }
                break;
            case 3:
                if (enemyType == 1)
                    Level3Enemy1--;
                if (enemyType == 2)
                    Level3Enemy2--;
                if (enemyType == 3)
                    Level3Enemy3--;
                if (Level3Enemy1 <= 0 && Level3Enemy2 <= 0 && Level3Enemy3 <= 0)
                {
                    ScreenTextManager.SharedInstance.MeshProHint.text = "You Win!";
                    ScreenTextManager.SharedInstance.ShowGameMenu(true);
                    GoblinManager.SharedInstance.isGaming = false;
                    ObjectGenerater.SharedInstance.ResetGame();
                    gameLevel = 0;
                }
                break;
        }
    }
    

}
