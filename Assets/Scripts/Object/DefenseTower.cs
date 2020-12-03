using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseTower : MonoBehaviour
{
    private Goblin _aimObject;
    private bool _isTriggered;
    private bool _isShooting;
    private int shootDelay;

    public GameObject Pivot;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        shootDelay = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isTriggered)
        {
            // Tower`s rotate
            Vector3 direction = _aimObject.transform.position - transform.position;
            direction.y = 0;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Pivot.transform.rotation = Quaternion.Slerp(Pivot.transform.rotation, rotation, 5 * Time.deltaTime);
            if (!_isShooting)
            {
                StartCoroutine(Shoot(direction));
            }
        }
    }

    IEnumerator Shoot(Vector3 direction)
    {
        Debug.Log("Shoot");
        _isShooting = true;
        yield return new WaitForSeconds(shootDelay);
        var bullet = Instantiate(Bullet);
        bullet.transform.position = Pivot.transform.position;
        bullet.GetComponent<Rigidbody>().velocity = direction;
        StartCoroutine(StopBullet(bullet));
        _isShooting = false;
    }

    IEnumerator StopBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(1.5f);
        bullet.SetActive(false);
    }
    public void Attack(Goblin goblin)
    {
        if(_isTriggered) return;
        _isTriggered = true;
        _aimObject = goblin;
        Debug.Log("Attack" + _aimObject.transform.position);
    }

    public void StopAttack()
    {
        _isTriggered = false;
        Debug.Log("Stop Attack" + _aimObject.transform.position);
    }
}
