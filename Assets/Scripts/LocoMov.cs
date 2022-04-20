using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoMov : MonoBehaviour
{

    public float horizontalSpeed;
    private Rigidbody2D rb2Loco;

    private bool withPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2Loco = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (withPlayer == false)
        {
            rb2Loco.velocity = new Vector2(horizontalSpeed, rb2Loco.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            withPlayer = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
