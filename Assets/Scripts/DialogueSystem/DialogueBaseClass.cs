using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem {
    public class DialogueSystem : MonoBehaviour
    {
            private IEnumerator WriteText(string input, Text textHolder) {
                for (int i=0; i<input.Length; i++) {
                    textHolder.text += input[i];
                    yield return new WaitForSeconds(0.1f);
                }
            }
    }
}
