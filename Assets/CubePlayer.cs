using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class CubePlayer : MonoBehaviour
{

    Rigidbody rb;


    [SerializeField]
    TMP_Text AttemptCounter;

    [SerializeField]
    TMP_Text Timer;



    float StartTime;  
  
    
    public static int Attempts = 0; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        StartTime = Time.time;
    }

    void Update () { 
        AttemptCounter.text = "Attempts: " + Attempts; 
        float t = Time.time - StartTime; 
        string minute = ((int) t / 60).ToString();
        string secound = (t % 60).ToString("f2");

        Timer.text = minute + ":" + secound;

    }
    // Update is called once per frame
    void FixedUpdate() 
    {
        rb.AddForce(Input.GetAxis("Horizontal") * 50, 0, Input.GetAxis("Vertical") *50); 
    }

    void OnTriggerEnter (Collider other) {
        if(other.gameObject.CompareTag("EnemyReset")) {
            UnityEngine.Debug.Log("I've been hit");
            ++Attempts;
            Destroy(this.gameObject); 
            SceneManager.LoadScene("SampleScene");
        }

            if (other.gameObject.CompareTag("Winner")) {
                Debug.Log("I have hit the unity scene");
                 Time.timeScale = 0;
            }
    }
}
