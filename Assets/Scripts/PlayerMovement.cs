using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;
    public AudioSource pasos;
    bool vActive;
    bool hActive;

    void Start()
    {

        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (Input.GetButtonDown("Horizontal"))
        {
            if (vActive == false)
            {
                hActive = true;
                pasos.Play();
            }
        }

        if (Input.GetButtonDown("Vertical"))
        {
            if (hActive == false)
            {
                vActive = true;
                pasos.Play();
            }
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            hActive = false;
            if (vActive == false)
            {
                pasos.Pause();
            }
        }

        if (Input.GetButtonUp("Vertical"))
        {
            vActive = false;
            if (hActive == false)
            {
                pasos.Pause();
            }
        }
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
    }

}
