using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Goblin : MonoBehaviour
{
    public Slider healthBar;
    public Text healthText;
    // public GameObject StartPoint;
    // public GameObject EndPoint;

    private Image _image;
    private float _maxHealth = 100f;
    private float _health;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    private void Awake()
    {
        _image = healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        _health = _maxHealth;
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GetAttacked(float damage)
    {
        _health -= Random.Range(damage, damage * 0.5f);
        healthBar.value = _health;
        healthText.text = (int)_health + " / " + _maxHealth;

        if (_health <= _maxHealth * 0.3f)
            healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;
        if (_health <= 0)
        {
            gameObject.SetActive(false);

            // destroyAudio.Play();
            // if(gameObject.activeInHierarchy) 
            //     DrawCrossHair.SharedInstance.AddScore(1);
            // Invoke("InactiveEnemy",1f);
        }
    }
    
    public void ResetEnemy()
    {
        gameObject.SetActive(true);
        // transform.position = StartPoint.transform.position;
        transform.position = new Vector3(-3, 1.2f, -30);

        if (ReferenceEquals(_agent, null))
            _agent = GetComponent<NavMeshAgent>();
        // _agent.destination = EndPoint.transform.position;

        _agent.destination = new Vector3(-3, 1.2f, 30f);
        healthBar.value = healthBar.maxValue;
        _image.color = Color.green;
    }
}
