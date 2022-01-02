using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed2;

    void Update()
    {
        Mov2();
    }

    void Mov2()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, speed2 * Time.deltaTime, 0f);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, -speed2 * Time.deltaTime, 0f);
        }
    }
}
