using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f; // Velocidade de movimento

    void Update()
    {
        // Movimenta o objeto ao longo do eixo Z a cada frame
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}

