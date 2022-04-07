using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void GoStart() {
        SceneManager.LoadScene(0);
    }
    public void GoNext() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit() {
        Application.Quit();
    }
}
