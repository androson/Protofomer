using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    private void OnEnable()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // resumes the game if button pressed
    

    public void LoadLevel1()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Abbas");
    }
    /*
    public void LoadLevel2()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Mohit");
    }
    public void LoadLevel3()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Abbas2");
    }*/

    public void QuitGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }

}
