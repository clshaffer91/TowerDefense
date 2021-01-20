using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Should have a base/interface for Tower.  Turret is not base, Tower is
public class Turret : MonoBehaviour
{
    private Transform targetEnemy;
    public float range = 15f;

    //how to set this in code
    public Transform turretBarrel;
    private float turnSpeed = 10f;

    private float startTime = 0f;
    private float updateTargetRate = 0.5f;

    private string enemyTag = "Enemy";

    private float fireRate = 1f;
    private float fireCooldown = 0f;

    public GameObject projectilePrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", startTime, updateTargetRate);
    }
    
    //this targets by range, can have multiple target finding
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach(GameObject enemy in enemies)
        {
            float distanceFromTowerToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceFromTowerToEnemy < shortestDistance)
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
    // Update is called once per frame
    void Update()
    {
        if (targetEnemy is null)
            return;

        Vector3 direction = targetEnemy.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 eulerRotation = Quaternion.Lerp(turretBarrel.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        turretBarrel.rotation = Quaternion.Euler(turretBarrel.rotation.eulerAngles.x, eulerRotation.y, turretBarrel.rotation.eulerAngles.z);
        
        if(fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }
        fireCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        Projectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation).GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.setTargetEnemy(targetEnemy);
        }
    }
    
    //should be a debug/when you place a Tower
    //there's probably better color options in full RGB/hex
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
