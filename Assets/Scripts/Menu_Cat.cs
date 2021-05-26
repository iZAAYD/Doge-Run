using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Cat : MonoBehaviour
{[SerializeField]
    private float Vel = 1;

    void Update()
    {
        var movement = transform.position += Vector3.right * (Time.deltaTime * Vel);
        transform.position = movement;
    }
}
