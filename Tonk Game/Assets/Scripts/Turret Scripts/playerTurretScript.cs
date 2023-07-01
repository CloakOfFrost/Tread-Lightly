using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTurretScript : MonoBehaviour
{
    public bool shoot;
    // Update is called once per frame
    void Update()
    {
        //movement
        float left = 0;
        float vertical = 0;
        float right = 0;
        if (Input.GetKey("w"))
        {
            vertical += 1;
        }
        if (Input.GetKey("s"))
        {
            vertical -= 1;
        }
        if (Input.GetKey("a"))
        {
            left += 0;
            right += 1;
        }
        if (Input.GetKey("d"))
        {
            left += 1;
            right += 0;
        }
        gameObject.GetComponent<turretScript>().chasseyPos.GetComponent<chasseyVariables>().vertical = vertical;
        gameObject.GetComponent<turretScript>().chasseyPos.GetComponent<chasseyVariables>().right = right;
        gameObject.GetComponent<turretScript>().chasseyPos.GetComponent<chasseyVariables>().left = left;
        //rotate to mouse slowly
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, gameObject.GetComponent<turretScript>().speed * Time.deltaTime);
        //shoot
        if (Input.GetMouseButton(0)) shoot = true;
        else shoot = false;
        gameObject.GetComponent<turretScript>().shoot = shoot;
    }
}