using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Material[] _renderMaterials;
    private Color defaultColor;
    public DefenseTower towerObject1;
    public DefenseTower towerObject2;
    public DefenseTower towerObject3;

    private void Start()
    {
        _renderMaterials = GetComponent<MeshRenderer>().materials;
        defaultColor = _renderMaterials[0].color;
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        Board.SharedInstance.ResetBoardColor();
        
        if(InitConfig.SharedInstance.CANNON_TYPE == 0)
            return;
        var cost = InitConfig.BaseCost * InitConfig.SharedInstance.CANNON_TYPE;
        InitConfig.SharedInstance.score -= cost;
        if (InitConfig.SharedInstance.score < 0)
        {
            InitConfig.SharedInstance.score += cost;
            return;
        }

        ScreenTextManager.SharedInstance.MeshProScore.text = "COINS:" + InitConfig.SharedInstance.score;

        DefenseTower cannon;
        switch (InitConfig.SharedInstance.CANNON_TYPE)
        {
            case 1:
                cannon = Instantiate(towerObject1);
                break;
            case 2:
                cannon = Instantiate(towerObject2);
                break;
            case 3:
                cannon = Instantiate(towerObject3);
                break;
            default:
                cannon = Instantiate(towerObject1);
                break;
        }
        cannon.transform.position = transform.position + new Vector3(0, 0.5f, 0);
        InitConfig.SharedInstance.CANNON_TYPE = 0;
    }

    public void HighLight()
    {
        _renderMaterials[0].color = Color.yellow;
    }
    
    public void Normal()
    {
        _renderMaterials[0].color = defaultColor;
    }
    
    
}
