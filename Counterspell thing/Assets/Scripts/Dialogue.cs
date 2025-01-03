using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI textNames;

    [TextArea]
    public string[] lines;
    public string[] names;
    public float textSpeed;
    public static bool playDialogue = false;

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
        textNames.text = names[index];
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
            textNames.text = names[index];
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            playDialogue = false;
        }
    }
}