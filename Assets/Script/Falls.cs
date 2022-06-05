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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != gameObject.tag)
        {
            Destroy(gameObject);
        }
    }


}