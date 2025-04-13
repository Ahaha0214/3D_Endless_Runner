using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    
    Rigidbody rb;
    [SerializeField] float jumpforce;
    bool canjump=true;
    int score=0;
    
    
    [SerializeField]public GameObject obstacle;
    [SerializeField]public GameObject scoredetect;

    [SerializeField]public Text scoretext;
    
    [SerializeField] int maxJumps = 2;
    [SerializeField] float jumpCooldown = 0.1f; // 跳躍冷卻時間
    private float jumpTimer = 0f; // 跳躍計時器

    // Start is called before the first frame update
    void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpTimer += Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && canjump)
        {   
            jump();
            maxJumps--;

        }
        
        if(maxJumps == 0)
        {
            canjump=false;
        }
        
    }
    void jump()
    {
        rb.AddForce(Vector3.up * jumpforce,ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canjump = true;
            maxJumps = 2;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game");
        }
        if(other.gameObject.tag == "ScoreDetect")
        {
            score++;
            scoretext.text=score.ToString();
        }
    }

}
