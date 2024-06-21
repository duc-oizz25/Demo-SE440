using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumb : MonoBehaviour
{
    [SerializeField] private float jumb=3f;
    [SerializeField] private float jumbTime=1f;

    [SerializeField] private  Vector3 jumbStep;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            transform.DOJump(transform.position + jumbStep,
                jumb, 1, jumbTime);
        }
    }
}
