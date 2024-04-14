using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float maxHp = 100;
    [SerializeField] private float currentHp;
    [SerializeField] private int damageAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ApplyDamage(ElementalColor color)
    {
        Debug.Log("Aplicar " + damageAmount + " ao inimigo.");
    }

    public void ReceiveDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp.CompareTo(0) <= 0)
        {
            player.SetActive(false);
            Debug.Log("Mostrar tela de game over");
        }
    }
}
