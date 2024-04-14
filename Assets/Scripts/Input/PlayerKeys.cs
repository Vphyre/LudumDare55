using UnityEngine;
using UnityEngine.Events;

public class PlayerKeys : MonoBehaviour
{
    public KeyCode key1 = KeyCode.Z; // Tecla 1
    public KeyCode key2 = KeyCode.X; // Tecla 2
    public KeyCode key3 = KeyCode.C; // Tecla 3
    public KeyCode key4 = KeyCode.N; // Tecla 4
    public KeyCode key5 = KeyCode.M; // Tecla 5
    public UnityEvent onKey1Pressed; // Evento para a tecla 1
    public UnityEvent onKey2Pressed; // Evento para a tecla 2
    public UnityEvent onKey3Pressed; // Evento para a tecla 3
    public UnityEvent onKey4Pressed; // Evento para a tecla 4
    public UnityEvent onKey5Pressed; // Evento para a tecla 5

    void Update()
    {
        if (Input.GetKeyDown(key1))
        {
            onKey1Pressed.Invoke();
        }
        if (Input.GetKeyDown(key2))
        {
            onKey2Pressed.Invoke();
        }
        if (Input.GetKeyDown(key3))
        {
            onKey3Pressed.Invoke();
        }
        if (Input.GetKeyDown(key4))
        {
            onKey4Pressed.Invoke();
        }
        if (Input.GetKeyDown(key5))
        {
            onKey5Pressed.Invoke();
        }
    }
}
