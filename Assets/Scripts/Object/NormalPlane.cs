using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NormalPlane : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " : " + other.gameObject.name);
        if (other.name.Contains("bullet(Clone)"))
        {
            ShowExplosion(other.gameObject);
        }
    }

    private void ShowExplosion(GameObject bullet)
    {
        var explore = Instantiate(explosion, bullet.transform.position, transform.rotation);
        StartCoroutine(DestroyExplosion(explore));
    }

    IEnumerator DestroyExplosion(GameObject ex)
    {
        yield return new WaitForSeconds(2);
        Destroy(ex);
    }
     
}
