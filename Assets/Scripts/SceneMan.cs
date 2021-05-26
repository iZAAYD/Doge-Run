using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public void SceneChange(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
