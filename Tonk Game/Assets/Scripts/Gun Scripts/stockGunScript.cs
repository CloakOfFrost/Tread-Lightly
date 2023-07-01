using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stockGunScript : MonoBehaviour
{
    private float bulletStart = 0.85f;
    private float cooldown = 0f;
    public GameObject bullet;
    private bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shoot = transform.parent.gameObject.GetComponent<turretScript>().shoot;
        if (shoot && cooldown <= 0)
        {
            Instantiate(bullet, transform.position + transform.up * bulletStart, transform.rotation, transform.parent.parent); ;
            cooldown = 2;
        }
        cooldown -= Time.deltaTime;
    }
}
