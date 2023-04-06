using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonHandler : MonoBehaviour
{
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    // public void Quit(){
    //     Application.Quit(); //this does not work in the editor
    // }
}
