using System;
using System.Collections;
using UnityEngine;

namespace TowerDefense.Scripts
{
    //TODO: Instantiate this on some kind of GameLoad().  
    //This class is becoming starting to blend with a GameManager - should break up responsibilities
    public class WaveSpawner : MonoBehaviour
    {
        [Header("Prefabs")]
        private Transform enemyPrefab;
        private Transform spawnPoint;

        //load these from a data source
        [Header("Spawning Properties")]
        private float waveStaggerTime = 5f;    //TODO: what if it takes longer to spawn a wave than the waveStaggerTime? -> non-issue
        private float enemyStaggerTime = .3f;
        private float initialCountdown = 2f;
        private float waveCountdown = 10f;

        private SpawningAlgorithm algorithm = SpawningAlgorithm.LinearWaveNumber;
        private int waveNumber = 1;

        private enum SpawningAlgorithm
        {
            LinearWaveNumber,
            Exponential
        }

        private void Awake() //TODO: This still doesn't quite render the number in a good spot on the UI
        {
            enemyPrefab = (Transform)Resources.Load("PreFabs/Enemy", typeof(Transform));
            spawnPoint = (Transform)Resources.Load("PreFabs/Start", typeof(Transform));
            Instantiate(spawnPoint);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (initialCountdown <= 0f)
            {
                RoundStart();
                if (waveCountdown <= 0f)
                {
                    StartCoroutine(SpawnWave());
                    waveCountdown = waveStaggerTime;
                    waveNumber++;
                }
            }
            waveCountdown -= Time.deltaTime;
            initialCountdown -= Time.deltaTime;
            GameCanvas.gameCanvasInstance.SetWaveCountdownTimer(waveCountdown);
        }

        private void RoundStart()
        {
            //TODO: Understand logging
            //Debug.Log("Wave Incoming!"); This log is really noisey until we implement an actual round system
        }

        private IEnumerator SpawnWave()
        {
            Debug.Log("Spawning wave with algorithm: " + algorithm.ToString());  //TODO: Implement different Spawning algos

            switch (algorithm)
            {
                case SpawningAlgorithm.LinearWaveNumber:
                    {
                        for (int i = 0; i <= waveNumber; i++)
                        {
                            SpawnEnemy();
                            yield return new WaitForSeconds(enemyStaggerTime);
                        }
                        break;
                    }
                case SpawningAlgorithm.Exponential:
                    throw new NotImplementedException();
                default:
                    throw new InvalidOperationException();
            }
        }

        private void SpawnEnemy()
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}