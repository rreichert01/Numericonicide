using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    public Animator canAnim;
    public static bool isCutsceneOn;
    public Player playerscript;
    
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            // Debug.Log(collision.gameObject);
            // playerscript.moveSpeed = 0;
            isCutsceneOn = true;
            canAnim.SetBool("cutscene1", true);
            Invoke(nameof(StopCutscene), 3f);
        }
    }

    void StopCutscene() {
        // playerscript.moveSpeed = 5f;
        
        isCutsceneOn = false;
        canAnim.SetBool("cutscene1", false);
        Destroy(gameObject);
    }



    
}
