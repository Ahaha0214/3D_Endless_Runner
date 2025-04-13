using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField]public GameObject obstacle;
    [SerializeField]public Transform SpawnPoint;
    [SerializeField]public Transform SpawnPoint2;
    [SerializeField]public GameObject Detector;
    [SerializeField]public GameObject playbuttom;
    [SerializeField]public GameObject player;
    public GameObject newObstacle;
    public GameObject newDetector;
    float maxWaitTime = 2f;

    
    void Start()
    {
        Time.timeScale=0f;
        player.SetActive(false);
    }
    IEnumerator SpawnObstacles()
    {
        while(true)
        {
            float WaitTime=Random.Range(1f,maxWaitTime);
            yield return new WaitForSeconds(WaitTime);
            newObstacle = Instantiate(obstacle,SpawnPoint.position,Quaternion.identity);
            newDetector = Instantiate(Detector,SpawnPoint2.position,Quaternion.identity);
            Destroy(newObstacle, 3f);
            Destroy(newDetector, 3f);
            maxWaitTime -= 0.1f;
            maxWaitTime = Mathf.Max(maxWaitTime, 0.5f);
        }
    }

    public void GameStart()
    {
        Time.timeScale=1f;
        player.SetActive(true);
        playbuttom.SetActive(false);
        StartCoroutine("SpawnObstacles");
        
    
    }

}
