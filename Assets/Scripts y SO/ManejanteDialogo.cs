using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManejanteDialogo : MonoBehaviour
{
    [SerializeField] GameObject UIElements;
    [SerializeField] Text dialogueTxt;
    [SerializeField] string[] NPCDialogue;
    [SerializeField] NPCDialogo NPCDialogueScript;
    public int dialogueIndex = 0;
    bool CanInteract = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
            
            if (Input.GetKeyDown(KeyCode.R) && CanInteract == true && dialogueIndex <= NPCDialogue.Length)
            {
                Debug.Log("funciona");
                dialogueTxt.text = NPCDialogue[dialogueIndex];
                dialogueIndex++;
            }
        
    }

    void OnTriggerEnter(Collider other)
    {
        NPCDialogueScript = other.gameObject.GetComponent<NPCDialogo>();
        if (NPCDialogueScript)
        {
            UIElements.SetActive(true);
            NPCDialogue = NPCDialogueScript.data.LineasDialogo;
            ShowNextDialogue();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            UIElements.SetActive(false);
            dialogueIndex = 0;
            CanInteract = false;
        }
    }

    public void ShowNextDialogue()
    {
        CanInteract = true;
        //if (dialogueIndex <= NPCDialogue.Length)
        //{
        //    dialogueTxt.text = NPCDialogue[dialogueIndex];
        //}
    }
}
