using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleInstructions : MonoBehaviour
{
    public void Start() 
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    public void toggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
