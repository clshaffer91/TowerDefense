using System;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Scripts
{
    public class GameCanvas : MonoBehaviour
    {
        public static GameCanvas gameCanvasInstance;  //implement a better singleton pattern - figure out DI
        public static GameObject canvasGameObject;

        [Header("PreFabs")]
        private Text waveCountdownText; //TODO: still not perfectly aligned, this is set in the prefab

        private void Awake()
        {
            if (gameCanvasInstance != null)
            {
                Debug.Log("2 Build Managers...how'd ya do that?");
                throw new InvalidOperationException();
            }
            gameCanvasInstance = this;

            canvasGameObject = new GameObject();
            canvasGameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            canvasGameObject.name = "Canvas";
            canvasGameObject.gameObject.transform.parent = Camera.main.transform;

            var waveCountdownPrefab = (Text)Resources.Load("PreFabs/WaveCountdown", typeof(Text));
            if (waveCountdownPrefab != null)
            {
                waveCountdownText = Instantiate(waveCountdownPrefab);
                waveCountdownText.gameObject.transform.parent = canvasGameObject.transform;
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public GameObject GetCanvasGameObject()
        {
            return canvasGameObject;
        }

        public void SetWaveCountdownTimer(float waveCountdown)
        {
            waveCountdownText.text = Mathf.Floor(waveCountdown).ToString();
        }
    }
}