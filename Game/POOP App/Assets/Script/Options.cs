using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}