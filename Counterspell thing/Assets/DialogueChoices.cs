using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueChoices : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    [TextArea]
    public string[] lines;
    public float textSpeed;
    public static bool playDialogue = false;

    public GameObject button1;
    public GameObject button2;

    private int index;

    void OnEnable()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playDialogue){
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
        
    }

    void StartDialogue()
    {
        playDialogue = true;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            button1.SetActive(true);
            button2.SetActive(true);
            playDialogue = false;
        }
    }
}