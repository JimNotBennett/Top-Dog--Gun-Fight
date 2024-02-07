using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public int speed;
   
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
