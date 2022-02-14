using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPlayer : MonoBehaviour
{
    public GameObject jugador;
    public Vector2 minimo;
    public Vector2 maximo;
    public float suavizado;
    Vector2 Velocity;


    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, jugador.transform.position.x, ref Velocity.x, suavizado);
        float posY = Mathf.SmoothDamp(transform.position.y, jugador.transform.position.y, ref Velocity.y, suavizado);

        transform.position = new Vector3(Mathf.Clamp(posX, minimo.x, maximo.x), Mathf.Clamp(posY, minimo.y, maximo.y), transform.position.z);
    }
}
