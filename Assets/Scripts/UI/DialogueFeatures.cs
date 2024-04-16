using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueFeatures : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text characterSpeech;
    [SerializeField] private Image characterImage;
    [SerializeField] private CharacterDialogue content;

    public UnityEvent onFinish;

    private void Awake()
    {
        StartCoroutine(MoveThroughDialogue());
    }

    private IEnumerator MoveThroughDialogue()
    {
        Time.timeScale = 0;

        for (int i = 0; i < content.dialogueContent.Length; i++)
        {
            characterName.text = content.dialogueContent[i].characterName;
            characterSpeech.text = content.dialogueContent[i].characterSpeech;
            characterImage.sprite = content.dialogueContent[i].characterImage;

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return));

            yield return null;
        }

        Time.timeScale = 1;
        onFinish.Invoke();
        dialogueBox.SetActive(false);
    }
}
