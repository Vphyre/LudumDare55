using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float maxHp = 100;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float currentHp;
    [SerializeField] private TMP_Text _hpText;
    public UnityEvent OnGameOver;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        UpdateHP();
    }
    private void UpdateHP()
    {
        _hpText.text = currentHp.ToString();
    }
    private void ApplyDamage(ElementalColor color)
    {
        Debug.Log("Aplicar " + damageAmount + " ao inimigo.");
    }

    public void ReceiveDamage(int damage)
    {
        currentHp -= damage;
        UpdateHP();
        if (currentHp.CompareTo(0) <= 0)
        {
            player.SetActive(false);
            currentHp = 0;
            UpdateHP();
            OnGameOver.Invoke();
        }
    }
    public void RecoveryHP(int hp)
    {
        currentHp += hp;
        UpdateHP();

        if (currentHp >= maxHp)
        {
            currentHp = maxHp;
            UpdateHP();
        }
    }
}
