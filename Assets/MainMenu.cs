using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public string leveltoLoad = "Lvl1";

    public void Play ()
    {
        SceneManager.LoadScene(leveltoLoad);
    }
    public void Quit ()
    {
        Application.Quit();
    }
}