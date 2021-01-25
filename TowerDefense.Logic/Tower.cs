using UnityEngine;

namespace TowerDefense.Logic
{
    public abstract class Tower : MonoBehaviour
    {
        [Header("TargetEnemy")]
        protected Transform targetEnemy;
        private string enemyTag = "Enemy";

        [Header("TowerProperties")]
        public string towerTypecode;
        public string towerName;
        public string prefabPath;
        protected float range;
        protected float startTime;
        protected float updateTargetRate;

        [Header("Projectiles")]
        protected float fireRate;
        protected float fireCooldown;
        public GameObject projectilePrefab;
        public Transform firePoint;

        // Start is called before the first frame update
        protected virtual void Start()
        {
            InvokeRepeating("UpdateTarget", startTime, updateTargetRate);
        }

        // Update is called once per frame
        protected virtual void Update()
        {

        }

        //this targets by range, can have multiple target finding
        private void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceFromTowerToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceFromTowerToEnemy < shortestDistance)
                {
                    shortestDistance = distanceFromTowerToEnemy;
                    nearestEnemy = enemy;
                }
            }

            //Unity can't handle not... :(
            if (!(nearestEnemy is null) && shortestDistance <= range)
            {
                targetEnemy = nearestEnemy.transform;
            }
            else
                targetEnemy = null;
        }

        protected virtual void Shoot()
        {
            Projectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation).GetComponent<Projectile>();

            if (projectile != null)
            {
                projectile.setTargetEnemy(targetEnemy);
            }
        }

        //should be a debug/when you place a Tower
        //there's probably better color options in full RGB/hex
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}