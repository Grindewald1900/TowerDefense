using System.Collections;
using System.Collections.Generic;
using Scrpts.ToolScripts;
using UnityEngine;

public class InitConfig : MonoBehaviour
{
    public const int BoardWidth = 16;
    public const int BoardHeight = 20;
    public const int CannonType1 = 101;
    public const int CannonType2 = 102;
    public const int CannonType3 = 103;
    public const int Level1Goblin1 = 30;
    public const int Level2Goblin1 = 40;
    public const int Level3Goblin1 = 50;
    public const int Level2Goblin2 = 10;
    public const int Level3Goblin2 = 20;
    public const int Level3Goblin3 = 5;


    
    public const string TagObstacle = "Obstacle";

    public int CANNON_TYPE = 0;
    public int DifficultLevel = 1;
    public int score = 200;
    public int passCount = 0;
    public static InitConfig SharedInstance;


    // Start is called before the first frame update

    private void Start()
    {
        SharedInstance = this;
    }
    

}
