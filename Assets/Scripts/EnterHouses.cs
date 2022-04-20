using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouses : MonoBehaviour
{
    public GameObject spriteExt;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = spriteExt.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sprite.color = new Color(1, 1, 1, 0);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sprite.color = new Color(1, 1, 1, 255);
        }
    }
}
