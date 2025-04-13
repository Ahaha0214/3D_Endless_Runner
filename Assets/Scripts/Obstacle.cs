using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]float Obstacle_Speed=8f;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,-Obstacle_Speed*Time.deltaTime);

    }

}
