using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene(2);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }



}
