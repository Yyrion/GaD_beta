using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu
{
    // Load Scene
   public void Play() 
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   // Quit Game
   public void Quit()
   {
        Application.Quit();
        Debug.Log("Le joueur a quitté le jeu");
   }
}
