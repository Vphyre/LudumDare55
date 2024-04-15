using System;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private SpriteRenderer bossWeak;
    [SerializeField] private GameObject startingDialogue;
    [SerializeField] private GameObject battleDialogue;
    [SerializeField] private GameObject finishDialogue;
    [SerializeField] private float currentHp = 100;
    [SerializeField] private float maxHp = 100;
    [SerializeField] private int timeSummoning = 30;
    [SerializeField] private int timeVulnerability = 10;
    [SerializeField] private float damageAmount = 10;
    [SerializeField] private bool isVulnerable = false;
    [SerializeField] private ElementalColor currentColor;
    public UnityEvent OnPlayerDamage;
    public UnityEvent OnBossDamage;
    public UnityEvent OnBossDefeted;
    public UnityEvent OnVulnerable;
    public UnityEvent OnInvulnerable;
    private bool battleDialogShowed;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        battleDialogShowed = true;

        if (battleDialogue != null)
        {
            battleDialogue.SetActive(false);
            battleDialogShowed = false;
        }

        if (startingDialogue != null)
        {
            startingDialogue.SetActive(true);
        }

        if (finishDialogue != null)
        {
            finishDialogue.SetActive(false);
        }

        Invoke("BecomeVulnerable", timeSummoning);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     ReceiveDamage(ElementalColor.Orange, 5);
        // }
    }

    private void SetCurrentColor()
    {
        int i = UnityEngine.Random.Range(0, 4);
        currentColor = (ElementalColor)Enum.Parse(typeof(ElementalColor), i.ToString());

        if (currentColor == ElementalColor.Blue)
        {
            bossWeak.color = Color.blue;
        }
        else if (currentColor == ElementalColor.Orange)
        {
            bossWeak.color = new Color(1.0f, 0.64f, 0.0f); // Laranja
        }
        else if (currentColor == ElementalColor.Red)
        {
            bossWeak.color = Color.red;
        }
        else if(currentColor == ElementalColor.Green)
        {
            bossWeak.color = Color.green;
        }
        else if(currentColor == ElementalColor.Yellow)
        {
            bossWeak.color = Color.yellow; 
        }
    }

    private void BecomeVulnerable()
    {
        if (!battleDialogShowed && battleDialogue != null)
        {
            battleDialogue.SetActive(true);
            battleDialogShowed = true;
        }
        OnVulnerable.Invoke();
        SetCurrentColor();
        isVulnerable = true;
        Invoke("BecomeInvulnerable", timeVulnerability);
        Debug.Log("Stop spawn!");
    }

    private void BecomeInvulnerable()
    {
        isVulnerable = false;
        Invoke("BecomeVulnerable", timeSummoning);
        OnInvulnerable.Invoke();
        Debug.Log("Start spawn!");
    }

    private void ApplyDamage()
    {
        OnPlayerDamage.Invoke();
        Debug.Log("Aplicou " + damageAmount + " ao jogador!");
    }

    public void ReceiveDamage(string colorName)
    {
        ElementalColor color;
        Enum.TryParse(colorName, out color);
        if (isVulnerable && color.Equals(currentColor))
        {
            currentHp -= 15;
            OnBossDamage.Invoke();

            if (currentHp.CompareTo(0) <= 0)
            {
                if(finishDialogue != null)
                {
                    finishDialogue.SetActive(true);
                }
                OnBossDefeted.Invoke();
                boss.SetActive(false);
                Debug.Log("Boss Derrotado");
            }

            SetCurrentColor();
        }
        else if (isVulnerable && !color.Equals(currentColor))
        {
            ApplyDamage();
        }
    }
}
