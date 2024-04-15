using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float maxHp = 100;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float currentHp;
    public UnityEvent OnGameOver;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
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
            OnGameOver.Invoke();
        }
    }
    public void RecoveryHP(int hp)
    {
        Debug.Log("Recuperou HP");
        currentHp += hp;

        if (currentHp >= maxHp)
        {
            currentHp = maxHp;
            Debug.Log("HP Máximo!");
        }
    }
}
