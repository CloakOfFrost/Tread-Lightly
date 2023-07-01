using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretScript : MonoBehaviour
{
    public GameObject chasseyPos;
    public float speed = 75f;
    public GameObject chassey;
    public GameObject gun;
    public bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gun, transform.position + new Vector3(0, 0, 0.1f), transform.rotation, transform);
        Instantiate(chassey, transform.position + new Vector3(0, 0, 0.2f), transform.rotation, transform.parent);
    }

    // Update is called once per frame
    void Update()
    {
        //check for chassey
        if (chasseyPos == null)
        {
            foreach (Transform child in transform.parent)
            {
                if (child.gameObject.name.Contains("Chassey"))
                {
                    chasseyPos = transform.parent.Find(child.gameObject.name).gameObject;
                    Debug.Log(child.gameObject.name);
                }
            }
        }
        //set position
        transform.position = chasseyPos.transform.position + new Vector3(0, 0, -0.2f);
    }
}
