using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Goblin : MonoBehaviour
{
    public Slider healthBar;
    public Text healthText;
    public int goblinLevel;
    // public GameObject StartPoint;
    // public GameObject EndPoint;

    private Image _image;
    private float _maxHealth;
    private float _health;
    private float _detectRange;
    private NavMeshAgent _agent;
    private DefenseTower _tower;

    // Start is called before the first frame update
    private void Awake()
    {
        _image = healthBar.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        _maxHealth = 100f * goblinLevel;
        _health = _maxHealth;
        _detectRange = 5f;
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(gameObject.name + " : " + other.gameObject.name);
        if (other.gameObject.name.Contains("cannon"))
        {
            _tower = other.gameObject.GetComponent<DefenseTower>();
            other.gameObject.GetComponent<DefenseTower>().Attack(this);
        }

        if (other.gameObject.name.Contains("bullet"))
        {
            GetAttacked(10);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("cannon"))
        {
            other.gameObject.GetComponent<DefenseTower>().StopAttack();
        }
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
            _tower.StopAttack();
            _health = _maxHealth;
            healthBar.value = _health;
            InitConfig.SharedInstance.score += 10*goblinLevel;
            ScreenTextManager.SharedInstance.MeshProScore.text = "Coins:" + InitConfig.SharedInstance.score;
            // destroyAudio.Play();
            // if(gameObject.activeInHierarchy) 
            //     DrawCrossHair.SharedInstance.AddScore(1);
            // Invoke("InactiveEnemy",1f);
        }
    }
    
    public void ResetEnemy()
    {
        Debug.Log("Reset_gobilin" + gameObject.name);
        gameObject.SetActive(true);
        // transform.position = StartPoint.transform.position;
        transform.position = new Vector3(15, 1, 1);

        if (ReferenceEquals(_agent, null))
            _agent = GetComponent<NavMeshAgent>();

        _agent.destination = new Vector3(15, 1, 36f);
        healthBar.value = _maxHealth;
        _image.color = Color.green;
    }
}
