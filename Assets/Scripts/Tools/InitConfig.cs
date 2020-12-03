using System.Collections;
using System.Collections.Generic;
using Scrpts.ToolScripts;
using UnityEngine;

public class InitConfig : MonoBehaviour
{
    public const int BOARD_WIDTH = 16;
    public const int BOARD_HEIGHT = 20;
    public const string TAG_OBSTACLE = "Obstacle";

    public int CANNON_TYPE = 0;

    public static InitConfig SharedInstance;


    // Start is called before the first frame update

    private void Start()
    {
        SharedInstance = this;
    }
    

}
