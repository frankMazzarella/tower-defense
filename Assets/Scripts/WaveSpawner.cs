using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public float timeBetweenEnemies = 0.2f;
    public Text waveCountdownLabel;
    private float waveCountdown = 2f;
    private int waveCounter = 0;

    private void Update()
    {
        if (waveCountdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            waveCountdown = timeBetweenWaves;
        }
        waveCountdown -= Time.deltaTime;
        waveCountdownLabel.text = "Next Wave: " + Mathf.Floor(waveCountdown + 1).ToString();
    }

    private IEnumerator SpawnWave()
    {
        waveCounter++;
        for (int i = 0; i < waveCounter; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
