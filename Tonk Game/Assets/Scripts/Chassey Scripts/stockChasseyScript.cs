using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stockChasseyScript : MonoBehaviour
{
    public float turnSpeed = 50;
    public float moveSpeed = 1;
    public float left = 0f;
    public float right = 0f;
    public float vertical = 0;
    // Update is called once per frame
    void Update()
    {
        left = gameObject.GetComponent<chasseyVariables>().left;
        right = gameObject.GetComponent<chasseyVariables>().right;
        vertical = gameObject.GetComponent<chasseyVariables>().vertical;
        move(left, right);
        float moveDegrees = 0;
        if (transform.rotation.z > 0) moveDegrees = -90 + transform.rotation.z;
        else if (transform.rotation.z <= 0) moveDegrees = 90 + transform.rotation.z;
    }
    void move(float left, float right)
    {
        Debug.Log(left.ToString() + " " + vertical.ToString() + " " + right.ToString());
        transform.position += transform.up * moveSpeed * Time.deltaTime * vertical;
        if (left > 0) transform.RotateAround(transform.Find("Stock Chassey Right Pivot").position, Vector3.back, turnSpeed * Time.deltaTime * vertical);
        if (right > 0) transform.RotateAround(transform.Find("Stock Chassey Left Pivot").position, Vector3.forward, turnSpeed * Time.deltaTime * vertical);
        if (vertical == 0)
        {
            if (left > right) transform.RotateAround(transform.position, Vector3.forward, -turnSpeed * Time.deltaTime);
            if (left < right) transform.RotateAround(transform.position, Vector3.forward, turnSpeed * Time.deltaTime);
        }
        /*
        //turn left
        if (right == 1 && left == 0) transform.RotateAround(transform.Find("Stock Chassey Right Pivot").position, Vector3.back, turnSpeed * Time.deltaTime);
        //turn right
        else if (right == 0 && left == 1) transform.RotateAround(transform.Find("Stock Chassey Left Pivot").position, Vector3.forward, turnSpeed * Time.deltaTime);
        if (Mathf.Abs(left) == 1 && Mathf.Abs(right) == 1)
        {
            //move foward/backward
            if (left == right) transform.position += transform.up * moveSpeed * Time.deltaTime * left;
            else
            {
                //rotate in place
                Quaternion rotation = Quaternion.AngleAxis(transform.position.z + 1 * turnSpeed * right, Vector3.forward);
                Quaternion.RotateTowards(transform.rotation, rotation, turnSpeed * Time.deltaTime);
            }
        }
        */
    }
}
