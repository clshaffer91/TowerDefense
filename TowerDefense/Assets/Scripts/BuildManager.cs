using System;
using UnityEngine;

namespace TowerDefense.Scripts
{
    public class BuildManager : MonoBehaviour  //might need Builder as a separate class
    {
        public static BuildManager buildManagerInstance;  //implement a better singleton pattern - figure out DI

        private GameObject towerToBuild;

        private GameObject defaultTower;

        private void Awake()
        {
            if (buildManagerInstance != null)
            {
                Debug.Log("2 Build Managers...how'd ya do that?");
                throw new InvalidOperationException();
            }
            buildManagerInstance = this;

            defaultTower = (GameObject)Resources.Load("PreFabs/Turret", typeof(GameObject));
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public GameObject GetTowerToBuild()
        {
            SetTowerToBuild(defaultTower); //TODO: more complicated logic
            return towerToBuild;
        }

        public void SetTowerToBuild(GameObject tower)
        {
            towerToBuild = tower;
        }
    }
}