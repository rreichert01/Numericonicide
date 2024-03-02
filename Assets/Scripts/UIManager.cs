using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI BulletCountText;
    public TextMeshProUGUI PlayerHealthText;
    public TextMeshProUGUI DialogueBoxText; 
    public TextMeshProUGUI text; 
    
    public void UpdateBulletCountUI(int count) {
        if(count == 0){
           BulletCountText.text = "Reload!"; 
        }
        else{
            BulletCountText.text = "Ammo: " + count.ToString();
        }
    }
    public void UpdateHealthUI(int health) {
        PlayerHealthText.text = "Health: " + health.ToString(); 
    }

    public void UpdateTimer(float countdown)
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime; 
        }
        text.text = countdown.ToString(); 

    }

    // [SerializeField] List<string> lines; 

    // public void showDialogue(Dialogue Dialogue)
    // {
    //     dialogueBox.setActive(true);
    //     dialogueText.text = dialogue.Lines[0];  

    // }

    // public void UpdateDialogue(List<string> lines)
    // {
    //     get { return lines; };
    // }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
