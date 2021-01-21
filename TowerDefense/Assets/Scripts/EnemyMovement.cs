using UnityEngine;

namespace TowerDefense.Scripts
{
    public class EnemyMovement : MonoBehaviour
    {
        private float speed = 10.0f;
        private Transform target;
        private int waypointIndex;

        // Start is called before the first frame update
        void Start()
        {
            target = Waypoints.waypoints[0];
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            //.2 margin of error, cause reasons
            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWaypoint();
            }
        }

        public void GetNextWaypoint()
        {
            if (waypointIndex == Waypoints.waypoints.Length - 1)
            {
                Destroy(gameObject);
            }
            waypointIndex++;
            target = Waypoints.waypoints[waypointIndex];
        }
    }
}