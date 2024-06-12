using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  //dùng để add component trực tiếp vào Opjiect khuyến khích dùng 
public class Player : MonoBehaviour
{
    [SerializeField] private float _froce = 10f ;
    private Rigidbody rb;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            // var force1 = Vector3.forward * _froce;
            var force = transform.forward * _froce;
            rb.AddForce(force, ForceMode.VelocityChange);
        }   
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("obstacle"))
        
            {
            Debug.Log("Player Conllision with " + other.gameObject.name);
            Debug.Log("Player Conllision with force " + other.impulse);
            Debug.Log("Player Conllision with relative velocity " + other.relativeVelocity);
            Debug.Log("Player Conllision with contact points" + other.contacts[0].point);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Destroy(other.gameObject, 1f);
    }
}
