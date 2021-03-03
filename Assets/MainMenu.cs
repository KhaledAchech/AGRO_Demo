using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
  public Animator transition;
  public float transitionTime = 1f;

  public void PlayGame()
  {
    StartCoroutine(PlayTransition());
    SceneManager.LoadScene("Prototype"); 
  }

   public void NewGame()
  {
    SceneManager.LoadScene("Layout Groups"); 
  }

  public void QuitGame()
  {
    Application.Quit();
  }

  IEnumerator PlayTransition()
  {
    transition.SetTrigger("Start");

    yield return new WaitForSeconds(transitionTime);

  }
}
