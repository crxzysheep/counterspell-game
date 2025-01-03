using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject dialogue;

    public void openDialogue(){
        if (dialogue != null){
            dialogue.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
