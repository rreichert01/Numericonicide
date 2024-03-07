using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private TextMeshProUGUI textHolder;
        [SerializeField] private string input;
        [SerializeField] private float lineDelay;

        private void Awake()
        {
            textHolder = GetComponent<TextMeshProUGUI>();
            Debug.Log(textHolder);
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, lineDelay));
        }

    }
}