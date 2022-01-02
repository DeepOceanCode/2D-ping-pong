using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Mov();
    }

    void Mov()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
        }
    }
}
