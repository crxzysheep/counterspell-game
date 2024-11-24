using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI textName;
    
    [TextArea]
    public string[] lines;
    public string[] names;
    
    public float textSpeed;
    public static bool playDialogue = false; 

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        textName.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(EventVariables.intro){
            EventVariables.intro=false;
            StartDialogue();
        }

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
        index = 0;
        textName.text = names[index];
        StartCoroutine(TypeLine());
        playDialogue = true;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            textName.text = names[index];
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            playDialogue = false;
        }
    }
}