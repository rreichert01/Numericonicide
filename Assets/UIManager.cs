using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI BulletCountText;
    public TextMeshProUGUI PlayerHealthText;
    public void UpdateBulletCountUI(int count) {
        if(count == 0){
           BulletCountText.text = "Reload with 'r'"; 
        }
        else{
            BulletCountText.text = "Ammo: " + count.ToString();
        }
    }
    public void UpdateHealthUI(int health) {
        PlayerHealthText.text = "Health" + health.ToString(); 
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
