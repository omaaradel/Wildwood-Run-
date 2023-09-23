using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelchoice : MonoBehaviour
{
    public void backtomain()
    {
        SceneManager.LoadScene(0);
    }
    public void levelone()
    {
        SceneManager.LoadScene(2);
    }
    public void leveltwo()
    {
        SceneManager.LoadScene(3);
    }
    public void levelthree()
    {
        SceneManager.LoadScene(4);
    }
    public void levelfour()
    {
        SceneManager.LoadScene(5);
    }
   
}
