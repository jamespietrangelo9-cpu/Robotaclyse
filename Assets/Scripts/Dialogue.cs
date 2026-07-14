using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [Header("UI References")]
    public GameObject dialogueBox;
    public GameObject speakerImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    [Header("Typing Settings")]
    public float typingSpeed = 0.03f;

    [Header("Player")]
    public GameObject Player;

    [Header("Dialogue Data")]
    public DialogueLine[] dialogueLines;

    private int index = 0;
    private Coroutine typingCoroutine;
    private bool isTalking = false;

    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;

        [TextArea(2, 5)]
        public string dialogue;

        public Sprite speakerSprite;
    }

    void Start()
    {
        dialogueBox.SetActive(false);
    }

    void Update()
    {
    if (!isTalking)
            return;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            NextDialogue();
        }
    }

    public void StartDialogue()
    {
        isTalking = true;
        index = 0;
        dialogueBox.SetActive(true);
        Player.GetComponent<PlayerMovement>().isMoveable = false;
        ShowLine();
    }

    public void NextDialogue()
    {
        // if still typing, skip instead of advancing
        if (typingCoroutine != null)
        {
            SkipTyping();
            return;
        }

        index++;

        if (index >= dialogueLines.Length)
        {
            EndDialogue();
            return;
        }

        ShowLine();
    }

    void ShowLine()
    {
        DialogueLine line = dialogueLines[index];

        nameText.text = line.speakerName;

        Image img = speakerImage.GetComponent<Image>();
        if (img != null)
        {
            img.sprite = line.speakerSprite;
        }

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(line.dialogue));
    }

    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";

        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        typingCoroutine = null;
    }

    public void SkipTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = dialogueLines[index].dialogue;
            typingCoroutine = null;
        }
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueBox.SetActive(false);
        Player.GetComponent<PlayerMovement>().isMoveable = true;
    }
}