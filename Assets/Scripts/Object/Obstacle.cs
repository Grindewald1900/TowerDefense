using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Material[] _renderMaterials;
    public DefenseTower towerObject;
    private void Start()
    {
        _renderMaterials = GetComponent<MeshRenderer>().materials;
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        var cannon = Instantiate(towerObject);
        cannon.transform.position = transform.position + new Vector3(0, 0.5f, 0);
    }

    public void HighLight()
    {
        _renderMaterials[0].color = Color.yellow;
    }
    
    
}
