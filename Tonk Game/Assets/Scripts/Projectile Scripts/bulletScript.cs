using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private float bulletSpeed;
    public float penetration;
    public float damage;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform.parent)
        {
            if (child.gameObject.name.Contains("Turret"))
            {
                transform.rotation = transform.parent.Find(child.gameObject.name).GetChild(0).rotation;
                bulletSpeed = transform.parent.Find(child.gameObject.name).GetChild(0).GetComponent<gunVariables>().bulletSpeed;
                penetration = transform.parent.Find(child.gameObject.name).GetChild(0).GetComponent<gunVariables>().penetration;
                damage = transform.parent.Find(child.gameObject.name).GetChild(0).GetComponent<gunVariables>().damage;
                Debug.Log(child.GetChild(0).gameObject.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
        if (time >= 10) Destroy(gameObject);
    }
}
