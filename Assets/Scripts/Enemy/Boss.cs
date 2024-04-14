using System;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private float currentHp = 100;
    [SerializeField] private float maxHp = 100;
    [SerializeField] private int timeSummoning;
    [SerializeField] private int timeVulnerability;
    [SerializeField] private float damageAmount = 10;
    [SerializeField] private bool isVulnerable = false;
    [SerializeField] private ElementalColor currentColor;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        Invoke("BecomeVulnerable", timeSummoning);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ReceiveDamage(ElementalColor.Orange, 5);
        }
    }

    private void SetCurrentColor()
    {
        int i = UnityEngine.Random.Range(0, 4);
        currentColor = (ElementalColor)Enum.Parse(typeof(ElementalColor), i.ToString());
    }

    private void BecomeVulnerable()
    {
        SetCurrentColor();
        isVulnerable = true;
        Invoke("BecomeInvulnerable", timeVulnerability);
        Debug.Log("Stop spawn!");
    }

    private void BecomeInvulnerable()
    {
        isVulnerable = false;
        Invoke("BecomeVulnerable", timeSummoning);
        Debug.Log("Start spawn!");
    }

    private void ApplyDamage()
    {
        Debug.Log("Aplicou " + damageAmount + " ao jogador!");
    }

    public void ReceiveDamage(ElementalColor color, float damage)
    {
        if (isVulnerable && color.Equals(currentColor))
        {
            currentHp -= damage;

            if (currentHp.CompareTo(0) < 0)
            {
                Debug.Log("Stop spawn!");
                boss.SetActive(false);
            }

            SetCurrentColor();
        }
        else if (isVulnerable && !color.Equals(currentColor))
        {
            ApplyDamage();
        }
    }
}
