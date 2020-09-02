using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    
    public int ButtonId;
   

    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
     
    }

    public void OnDown()
    {
        //pop sound
        //Effects
        manager.ButtonPress(ButtonId);
    }
}
