using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutscene : MonoBehaviour
{
    public Animator canAnim;
    public static bool isCutsceneOn;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Debug.Log("TRIGGERED!!!");
            isCutsceneOn = true;
            canAnim.SetBool("cutscene1", true);
            Invoke(nameof(StopCutscene), 3f);
        }
    }

    void StopCutscene() {
        isCutsceneOn = false;
        canAnim.SetBool("cutscene1", false);
        Time.timeScale = 1f;
    }
}
