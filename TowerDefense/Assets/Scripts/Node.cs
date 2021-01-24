using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerDefense.Scripts
{
    public class Node : MonoBehaviour
    {
        private Renderer render;
        private Color defaultNodeColor;
        private Vector3 nodeHeightOffset;

        private GameObject tower;

        BuildManager buildManager;

        private void Awake()
        {
            nodeHeightOffset = new Vector3(0, gameObject.transform.position.y, 0);
        }
        // Start is called before the first frame update
        void Start()
        {
            render = GetComponent<Renderer>();
            defaultNodeColor = render.material.color;
            buildManager = BuildManager.buildManagerInstance;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnMouseEnter()
        {
            if (EventSystem.current.IsPointerOverGameObject())  //TODO: This isn't working as intended
                return;
            if (buildManager.GetTowerToBuild() == null)
                return;
            render.material.color = Color.green;
        }

        private void OnMouseExit()
        {
            render.material.color = defaultNodeColor;
        }

        private void OnMouseDown()
        {
            if (buildManager.GetTowerToBuild() == null)
                return;
            if (tower != null)
            {
                Debug.Log("Can't Build there, already occupied"); //TODO: Display on screen
                return;
            }

            GameObject towerToBuild = buildManager.GetTowerToBuild();
            tower = Instantiate(towerToBuild, transform.position + nodeHeightOffset, transform.rotation);
        }
    }
}