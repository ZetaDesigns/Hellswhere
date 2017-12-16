using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text CountdownText;
    private float countdown = 2f;
    private int waveIndex = 0;
    private float[] TimeBetweenWaves = new float[] {0f, 5f, 7f, 10f, 12f, 15f};
    void Update ()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            if (waveIndex <= 5)
            {
                countdown = TimeBetweenWaves[waveIndex];
            } else
            {
                countdown = 15f;
            }
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        CountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(0.2f, 1f));
        }
        StatsManager.Waves++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
