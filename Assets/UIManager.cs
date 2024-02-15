using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI BulletCountText;
    public void UpdateBulletCountUI(int count) {
        if(count == 0){
           BulletCountText.text = "Reload with 'r'"; 
        }
        else{
            BulletCountText.text = "Ammo: " + count.ToString();
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
