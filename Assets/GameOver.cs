using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {

    public Text wavesText;

	// Use this for initialization
	void OnEnable()
    {
        wavesText.text = StatsManager.Waves.ToString();
    }
    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu ()
    {
        Debug.Log("TODO: Menu!");
    }
}
