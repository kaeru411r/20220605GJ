using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Falls : MonoBehaviour
{
    [SerializeField] float time;

    Vector2 bufVelocity;

    private void Start()
    {
        Destroy(gameObject, time);
    }

    private void OnEnable()
    {
        GameManeger.Instance._OnPause += OnPause;
        GameManeger.Instance._OnResume += OnResume;
    }

    private void OnDisable()
    {
        GameManeger.Instance._OnPause -= OnPause;
        GameManeger.Instance._OnResume -= OnResume;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != gameObject.tag)
        {
            Destroy(gameObject);
        }
    }


    public void OnPause()
    {
        var rb = GetComponent<Rigidbody2D>();
        bufVelocity = rb.velocity;
        rb.Sleep();
    }

    public void OnResume()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.WakeUp();
        rb.velocity = bufVelocity;
    }

}