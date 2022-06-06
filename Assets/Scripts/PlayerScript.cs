using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 3;
    bool isPlay = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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



    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = 0;
        if (isPlay)
        {
            x = Input.GetAxisRaw("Horizontal");
        }

        if (x > 0)
        {
            var lS = transform.localScale;
            transform.localScale = new Vector3(Mathf.Abs(lS.x), lS.y, lS.z);
            Debug.Log("right");
        }
        else if (x < 0)
        {
            var lS = transform.localScale;
            transform.localScale = new Vector3(-Mathf.Abs(lS.x), lS.y, lS.z);
            Debug.Log("left");
        }

        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
    }


    public void OnPause()
    {
        isPlay = false;
    }

    public void OnResume()
    {
        isPlay = true;
    }
}
