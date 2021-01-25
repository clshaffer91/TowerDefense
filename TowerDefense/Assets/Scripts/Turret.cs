using TowerDefense.Logic;
using UnityEngine;

namespace TowerDefense.Scripts
{
    public class Turret : Tower
    {
        //how to set this in code
        public Transform turretBarrel;
        private float turnSpeed = 10f;

        //DI in ITowerRepository and load from Data Source
        public Turret()
        {
            range = 15f;
            startTime = 0f;
            updateTargetRate = 0.5f;
            fireRate = 1f;
            fireCooldown = 0f;
        }

        // Update is called once per frame
        // Could pull this into base eventually - right now it's coupled cause not every Tower will have a turretBarrel
        protected override void Update()
        {
            if (targetEnemy is null)
                return;

            Vector3 direction = targetEnemy.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 eulerRotation = Quaternion.Lerp(turretBarrel.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            turretBarrel.rotation = Quaternion.Euler(turretBarrel.rotation.eulerAngles.x, eulerRotation.y, turretBarrel.rotation.eulerAngles.z);
            
            if (fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = 1f / fireRate;
            }
            fireCooldown -= Time.deltaTime;
        }
    }
}