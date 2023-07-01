using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripleGunScript : MonoBehaviour
{
    private float bulletStart = 0.85f;
    private float cooldown = 0f;
    public GameObject bullet;
    private int phase = 0;
    private bool shoot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shoot = transform.parent.gameObject.GetComponent<turretScript>().shoot;
        if (phase >= 3) phase = 0;
        if (shoot && cooldown <= 0)
        {
            Instantiate(bullet, transform.position + transform.up * bulletStart + (transform.right * 0.2f * phase - transform.right * 0.2f), transform.rotation, transform.parent.parent); ;
            phase++;
            cooldown = 0.67f;
        }
        cooldown -= Time.deltaTime;
    }
}
