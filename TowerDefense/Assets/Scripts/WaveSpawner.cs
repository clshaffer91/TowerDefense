using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Scripts
{
    public class WaveSpawner : MonoBehaviour
    {
        //how to set these that's not thru unity
        public Transform enemyPrefab;
        public Transform spawnPoint;
        public Text waveCountdownText;

        //readonly?
        private float waveStaggerTime = 5f;    //TODO: what if it takes longer to spawn a wave than the waveStaggerTime? -> non-issue
        private float enemyStaggerTime = .3f;
        private float initialCountdown = 2f;
        private float waveCountdown = 10f;

        private int waveNumber = 1;

        private bool done = false;

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
            waveCountdownText.text = Mathf.Floor(waveCountdown).ToString();
        }

        private void RoundStart()
        {
            //TODO: Understand logging
            Debug.Log("Wave Incoming!");
        }

        private IEnumerator SpawnWave()
        {
            Debug.Log("Spawning wave with algo x");  //TODO: Implement different Spawning algos

            //abstract algo away - interface it
            for (int i = 0; i <= waveNumber; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(enemyStaggerTime);
            }
        }

        private void SpawnEnemy()
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}