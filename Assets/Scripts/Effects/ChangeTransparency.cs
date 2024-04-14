using UnityEngine;

public class ChangeTransparency : MonoBehaviour
{
    public Material material; // O material que você deseja modificar
    public float alphaValue = 90.0f; // O valor de alpha que você deseja definir
    public void ChangeAlpha(float value)
    {
        // Converte o valor de alpha de 0-255 para 0-1
        float alpha = value / 255.0f;

        // Obtém a cor atual de albedo do material
        Color color = material.color;

        // Altera o valor de alpha da cor
        color.a = alpha;

        // Define a nova cor de albedo do material
        material.color = color;

    }
}
