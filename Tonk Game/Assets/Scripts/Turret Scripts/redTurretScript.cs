using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redTurretScript : MonoBehaviour
{
    public GameObject playerChassey;
    public bool shoot;
    void Update()
    {
        if (playerChassey == null)
        {
            foreach (Transform child in transform.parent.parent)
            {
                if (child.gameObject.name.Contains("Player"))
                {
                    Debug.Log(child.GetChild(0).gameObject.name);
                    foreach (Transform child2 in child)
                    {
                        if (child2.gameObject.name.Contains("Chassey"))
                        {
                            playerChassey = child.Find(child2.gameObject.name).GetChild(0).gameObject;
                            Debug.Log("playerChassey = " + child2.GetChild(0).gameObject.name);
                        }
                    }
                }
            }
        }
        else
        {
            Vector3 playerPos = playerChassey.transform.position;
            //rotate to player slowly
            float angle = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, gameObject.GetComponent<turretScript>().speed * Time.deltaTime);
            if (transform.rotation == Quaternion.RotateTowards(transform.rotation, rotation, gameObject.GetComponent<turretScript>().speed * Time.deltaTime)) shoot = true;
            else shoot = false;
            gameObject.GetComponent<turretScript>().shoot = shoot;
        }
    }
}
