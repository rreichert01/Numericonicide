using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem {
    public class DialogueHolder : MonoBehaviour
    {
        // private void Awake () {
        //     StartCoroutine(dialogueSequence());
        // }

        public static bool isDialogueDone = false;
        public bool hasStarted = false;

        private void Awake() {
            StartCoroutine(dialogueSequence());
        }

        // private void Update() {
        //     if (startCutscene.isCutsceneOn && !hasStarted) {
        //         hasStarted = true;
        //         StartCoroutine(dialogueSequence());
        //     }
        // }

        private IEnumerator dialogueSequence() {
            for (int i=0; i<transform.childCount; i++) {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            gameObject.SetActive(false);
            isDialogueDone = true;
        }

        private void Deactivate() {
            for (int i=0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }
}
