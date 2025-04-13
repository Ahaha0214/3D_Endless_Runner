using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Detector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float Detector_Speed=8f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,-Detector_Speed*Time.deltaTime);
        
    }
}
