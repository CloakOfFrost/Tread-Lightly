using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasseyVariables : MonoBehaviour
{
    public float left = 0f;
    public float right = 0f;
    public float vertical = 0;
    private float hardness = 1f;
    public float health = 1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("found something");
        if (collision.transform.gameObject.name.Contains("Projectile"))
        {
            Debug.Log(collision.transform.GetComponent<bulletScript>().penetration);
            if (collision.transform.GetComponent<bulletScript>().penetration >= hardness)
            {
                health -= collision.transform.GetComponent<bulletScript>().damage;
                if (collision.transform.GetComponent<bulletScript>().penetration == hardness) Destroy(collision.gameObject);
            }
            else Destroy(collision.gameObject);
        }
    }
    void Update()
    {
        if (health <= 0) Destroy(transform.parent.gameObject);
    }
}
