using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text score;
    public static List<int> scoreType = new List<int>(new int[] {0,0,0,0});

    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
    }

    public static List<int> ClearList()
    {
       List<int> scoreType = new List<int>(new int[] { 0, 0, 0, 0 });
       return scoreType;
    }
}
