using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.tag)
        {
            case "Gun Range":
                Debug.Log("Loading Gun Range Mini Game");
                
                //Add function that Loads the display for the gun mini game
                break;
            case "Mall":
                Debug.Log("Loading Mall Mini Game");
                break;
            case "Firewall":
                Debug.Log("Loading Firewall Mini Game");
                break;
            case "Boss":
                Debug.Log("Loading Boss Level");
                SceneManager.LoadScene(4);
                break;
            default:
                break;

        }

    }
}
