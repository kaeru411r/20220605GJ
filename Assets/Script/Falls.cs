using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falls : MonoBehaviour
{
    [SerializeField] float time;
    private void Start()
    {
        Destroy(gameObject, time);
    }
    private void OnTriggerEnter(Collider other)
    {
            Destroy(gameObject);

    }
       

}