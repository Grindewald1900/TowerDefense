using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenTextManager : MonoBehaviour
{
    public static ScreenTextManager SharedInstance;
    public TMP_Text MeshProScore;
    public TMP_Text MeshProLevel;
    // Start is called before the first frame update
    private void Start()
    {
        SharedInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
