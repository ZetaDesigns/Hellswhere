using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;

    public float timeBetweenWaves = 20f;
    private float countdown = 2f;

    void Update ()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }
    void SpawnWave ()
    {
        Debug.Log("Wave Incomming!");
    }
}
