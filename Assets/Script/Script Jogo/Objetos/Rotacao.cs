using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacao : MonoBehaviour
{
    public int Vel_Rot;
    public float x = 0, y = 0, z = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x, y, z) * Vel_Rot * Time.deltaTime);
    }
}
