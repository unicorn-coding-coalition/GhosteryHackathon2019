using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text displayText;
    public Text passwordText;
    private Queue<string> passwords = new Queue<string>(new string[] {"123456","qwerty","111111","monkey","abc123","iloveyou","dragon"});
    public InputAction[] inputActions;
    public string p;
    //public GameObject ammunition;
    List<char> sym = new List<char>(new char[]
   { '%', '$', '#', '`', '!', '$', '^', '&', '*', '(', ')', '~', '<', '>', '?', '/', '.'});
    List<string> actionLog = new List<string>();
    //List<string> passwords = new List<string>();
    //public Textmesh ammunition;

    void Start()
    {
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("", actionLog.ToArray());
        displayText.text = logAsText;
        //return actionLog;

        //Debug.Log(logAsText);
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd);

        if (actionLog.Count > 0)
        {
            scoreUpdater(actionLog);
        }
        LoadingAmmo(stringToAdd);
    }

    public void scoreUpdater(List<string> scoreString)
    {
        Score.scoreValue = 0;
        if (scoreString.Count > 1)
        {
            
            foreach (string s in scoreString)
            {
                Debug.Log(s);
                char c = char.Parse(s);
               
                if (char.IsLower(c))
                    //Score.scoreValue++;
                    Score.scoreType[0] = 1;
                if (char.IsUpper(c))
                    //  Score.scoreValue++;
                    Score.scoreType[1] = 1;
                if (char.IsDigit(c))
                    //Score.scoreValue++;
                    Score.scoreType[2] = 1;

                foreach (char special in sym)
                {
                    if (special == c)
                        //Score.scoreValue++;
                        Score.scoreType[3] = 1;
                }
            }
        }

        foreach (int score in Score.scoreType)
        {
            Score.scoreValue += score;
        }

        //Debug.Log(Score.scoreValue);
        if (Score.scoreValue > 3 & scoreString.Count > 7)
        {
            Debug.Log("Valid! Password");
           // Score.ClearList();
            actionLog.Clear();
            if (passwords.Count > 0)
            {
                p = passwords.Dequeue();
                Debug.Log(p);
                passwordText.text = null;
                passwordText.text = p;
                Score.scoreType = Score.ClearList();
            }
            else
            {
                passwordText.text = null;
                passwordText.text = "You win!!";
                SceneManager.LoadScene(sceneName: "Base");
            }
        }

        //cue next password drop!
        
        Score.scoreValue = 0;
         }


    public void LoadingAmmo(string input)
    {

        Debug.Log("In loading ammo");
        //return input;
        //eventmanager.


        //Text a;
        //a = Instantiate(ammunition, transform.position, transform.rotation);
        //a.text = input;

        //Debug.Log(input);

        /* foreach (Transform ammo in ammunition.transform)
         {
             if (input == ammo.name)
             {
                 //create new game object 
                 Debug.Log(ammo.name);
             }

         }*/
    }



}


