using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVariables : MonoBehaviour
{
    private float hardness = 2f;
    public float health = 1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("wall hit");
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
        if (health <= 0) Destroy(gameObject);
    }
}