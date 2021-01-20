using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //how to set these that's not thru unity
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text waveCountdownText;

    //readonly?
    private float waveStaggerTime = 5f;    //TODO: what if it takes longer to spawn a wave than the waveStaggerTime?
    private float enemyStaggerTime = .3f;
    private float initialCountdown = 2f;
    private float waveCountdown = 3f;

    private int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(initialCountdown <= 0f)
        {
            RoundStart();
            if(waveCountdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                waveCountdown = waveStaggerTime;
            }
        }
        initialCountdown -= Time.deltaTime;
        waveCountdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Floor(waveCountdown).ToString();
    }

    private void RoundStart()
    {
        //TODO: Understand logging
        Debug.Log("Wave Incoming!");
    }

    private IEnumerator SpawnWave()
    {
        Debug.Log("Spawning wave with algo x");

        //abstract algo away - interface it
        for (int i = 0; i <= waveNumber; i++)
        {
            SpawnEnemy();
            waveNumber++;
            yield return new WaitForSeconds(enemyStaggerTime);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
