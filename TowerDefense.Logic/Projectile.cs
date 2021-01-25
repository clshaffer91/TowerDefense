using UnityEngine;

namespace TowerDefense.Logic
{
    public class Projectile : MonoBehaviour
    {
        private Transform targetEnemy;
        public GameObject particleImpactEffect;

        private float projectileSpeed = 70f;

        public void setTargetEnemy(Transform enemy)
        {
            targetEnemy = enemy;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (targetEnemy is null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 direction = targetEnemy.position - transform.position;
            float distancePerFrame = projectileSpeed * Time.deltaTime; // there's a way to set this as a private property on the class
            if (direction.magnitude <= distancePerFrame)
            {
                HitTarget();
                return;
            }


            transform.Translate(direction.normalized * distancePerFrame, Space.World);
        }

        private void HitTarget()
        {
            GameObject particleEffect = Instantiate(particleImpactEffect, transform.position, transform.rotation);
            Destroy(particleEffect, 2f);
            Destroy(targetEnemy.gameObject);
            Destroy(gameObject);
        }
    }
}