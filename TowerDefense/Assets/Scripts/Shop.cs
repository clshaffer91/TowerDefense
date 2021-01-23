using System;
using UnityEngine;

namespace TowerDefense.Scripts
{
    public class Shop : MonoBehaviour  //might need Builder as a separate class
    {
        public static Shop shopInstance;  //implement a better singleton pattern - figure out DI

        private GameObject towerToBuild;

        private GameObject defaultTower;

        private void Awake()
        {
            if (shopInstance != null)
            {
                Debug.Log("2 Shops...how'd ya do that?");
                throw new InvalidOperationException();
            }
            shopInstance = this;

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
            towerToBuild = defaultTower; //TODO: more complicated logic
            return towerToBuild;
        }
    }
}