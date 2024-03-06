using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;

public class startCutscene : MonoBehaviour
{
    public Animator canAnim;
    public static bool isCutsceneOn;
    public Player playerscript;
    public bool hasCut = false;
    public GameObject dialogueHolder;
    public GameObject chatBubble;

    
    void Update()
    {
        if (DialogueHolder.isDialogueDone && !hasCut) {
            hasCut = true;
            canAnim.SetBool("cutscene1", true);
            chatBubble.SetActive(false);
            Invoke(nameof(StopCutscene), 3f);
        }
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            // Debug.Log(collision.gameObject);
            // playerscript.moveSpeed = 0;
            if(dialogueHolder != null) {
                dialogueHolder.SetActive(true);
                chatBubble.SetActive(true);
            }
            isCutsceneOn = true;
            // canAnim.SetBool("cutscene1", true);
            // Invoke(nameof(StopCutscene), 3f);
        }
    }

    void StopCutscene() {
        // playerscript.moveSpeed = 5f;
        
        isCutsceneOn = false;
        canAnim.SetBool("cutscene1", false);
        Destroy(gameObject);
    }



    
}
