using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool isOver;

    public GameObject gameOverUI;
	// Update is called once per frame
    void Start ()
    {
        isOver = false;
    }
 	void Update () {
        if (isOver)
            return;

		if (StatsManager.Lives <= 0)
        {
            endGame();
        }
	}
    void endGame()
    {
        isOver = true;
        gameOverUI.SetActive(true);
    }
}
