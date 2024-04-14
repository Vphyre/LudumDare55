using System;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject startingDialog;
    [SerializeField] private GameObject battleDialog;
    [SerializeField] private float currentHp = 100;
    [SerializeField] private float maxHp = 100;
    [SerializeField] private int timeSummoning = 30;
    [SerializeField] private int timeVulnerability = 10;
    [SerializeField] private float damageAmount = 10;
    [SerializeField] private bool isVulnerable = false;
    [SerializeField] private ElementalColor currentColor;
    public UnityEvent OnPlayerDamage;

    private bool battleDialogShowed;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        battleDialogShowed = true;

        if (battleDialog != null)
        {
            battleDialog.SetActive(false);
            battleDialogShowed = false;
        }

        if (startingDialog != null)
        {
            startingDialog.SetActive(true);
        }

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
        if (!battleDialogShowed && battleDialog != null)
        {
            battleDialog.SetActive(true);
            battleDialogShowed = true;
        }

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
        OnPlayerDamage.Invoke();
        Debug.Log("Aplicou " + damageAmount + " ao jogador!");
    }

    public void ReceiveDamage(ElementalColor color, float damage)
    {
        if (isVulnerable && color.Equals(currentColor))
        {
            currentHp -= damage;

            if (currentHp.CompareTo(0) <= 0)
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
