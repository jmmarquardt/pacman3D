using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    
    public void StartGame() 
    {
        // Start the game when the play button is clicked
        SceneManager.LoadScene("Play");
    }
}
