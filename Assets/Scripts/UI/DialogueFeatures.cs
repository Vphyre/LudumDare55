using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueFeatures : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text characterSpeech;
    [SerializeField] private Image characterImage;
    public CharacterDialogue content;

    private void Start()
    {
        StartCoroutine(MoveThroughDialogue());
    }

    private IEnumerator MoveThroughDialogue()
    {
        Debug.Log(content.dialogueContent.Length);

        for (int i = 0; i < content.dialogueContent.Length; i++)
        {
            characterName.text = content.dialogueContent[i].characterName;
            characterSpeech.text = content.dialogueContent[i].characterSpeech;
            characterImage.sprite = content.dialogueContent[i].characterImage;

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            yield return null;
        }

        dialogueBox.SetActive(false);
    }
}
