using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool isEnded = false;

	// Update is called once per frame
	void Update () {
        if (isEnded)
            return;

		if (StatsManager.Lives <= 0)
        {
            endGame();
        }
	}
    void endGame()
    {
        isEnded = true;
        Debug.Log("GameOver");
    }
}
