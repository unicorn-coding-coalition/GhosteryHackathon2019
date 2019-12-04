using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TriggerGunRange : MonoBehaviour

{
    public int index = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Application.LoadLevel(loadLevel);
        //SceneManager.GetActiveScene().buildIndex + 
        SceneManager.LoadScene(index);

    }
}
