using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public Transform rayEmitter; 

    private RaycastHit hit; 
    private Renderer rend; 

    bool canshoot = true; 

    [SerializeField]
    Transform GameObject; 

    [SerializeField]
    Rigidbody Sphere; 

    void Start() {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(rayEmitter.position, transform.forward, out hit)) {
            if(hit.collider.CompareTag("Player")) {
                rend.material.color = Color.red; 
                Debug.Log("I have hit");
                if (canshoot == true) {  
                
                Rigidbody bullet = Instantiate(Sphere, GameObject.position, GameObject.rotation); 
                bullet.AddForce(transform.forward*30, ForceMode.Impulse);
                canshoot = false; 
                 StartCoroutine(Wait());
                } 
            } else {
                rend.material.color = Color.green;
                Debug.DrawRay(rayEmitter.position, transform.forward *10, Color.white, 1); 
            }
        }
         Debug.DrawRay(rayEmitter.position, transform.forward *10, Color.white, 1); 

    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1);
        canshoot = true;
    }
}
