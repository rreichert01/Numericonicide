using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem {

    public class DialogueBaseClass : MonoBehaviour
    { 
        public bool finished { get; private set; }
        protected IEnumerator WriteText(string input, Text textHolder, float lineDelay) {
            yield return new WaitForSeconds(1.0f);
            for (int i=0; i<input.Length; i++) {
                textHolder.text += input[i];
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(lineDelay);
            finished = true;
        }
    }
}
