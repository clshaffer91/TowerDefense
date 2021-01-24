using UnityEngine;

namespace TowerDefense.Scripts
{
    public class Shop : MonoBehaviour
    {
        private BuildManager buildManager;
        private GameObject towerSelected;  //load in from TowerRepository
        private GameObject shopPanelPrefab;
        private Transform shopPanel;

        private void Awake()
        {
            shopPanelPrefab = (GameObject)Resources.Load("PreFabs/ShopPanel", typeof(GameObject));
            shopPanel = Instantiate(shopPanelPrefab.gameObject.transform);
            shopPanel.transform.parent = GameCanvas.canvasGameObject.transform;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PurchaseTower()
        {
            buildManager.SetTowerToBuild(towerSelected);
        }
    }
}