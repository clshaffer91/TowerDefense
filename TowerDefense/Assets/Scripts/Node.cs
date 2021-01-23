using UnityEngine;

namespace TowerDefense.Scripts
{
    public class Node : MonoBehaviour
    {
        private Renderer render;
        private Color defaultNodeColor;
        private Vector3 nodeHeightOffset;

        private GameObject tower;

        private void Awake()
        {
            nodeHeightOffset = new Vector3(0, gameObject.transform.position.y, 0);
        }
        // Start is called before the first frame update
        void Start()
        {
            render = GetComponent<Renderer>();
            defaultNodeColor = render.material.color;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnMouseEnter()
        {
            render.material.color = Color.green;
        }

        private void OnMouseExit()
        {
            render.material.color = defaultNodeColor;
        }

        private void OnMouseDown()
        {
            if (tower != null)
            {
                Debug.Log("Can't Build there"); //TODO: Display on screen
                return;
            }

            GameObject towerToBuild = Shop.shopInstance.GetTowerToBuild();
            tower = Instantiate(towerToBuild, transform.position + nodeHeightOffset, transform.rotation);
        }
    }
}