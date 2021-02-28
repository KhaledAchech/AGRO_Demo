using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewPlayer : MonoBehaviour
{
    public void PlayGame()
  {
     SceneManager.LoadScene("Prototype"); 
  }

   public void Cancel()
  {
     SceneManager.LoadScene("Menu 3D"); 
  }
}
