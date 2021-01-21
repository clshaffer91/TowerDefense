using UnityEngine;

namespace TowerDefense.Scripts
{
    public class Waypoints : MonoBehaviour
    {
        //can we make this not static
        //I'm stubborn and want to make this an IEnumerable but don't see how yet
        public static Transform[] waypoints;

        public void Awake()
        {
            waypoints = new Transform[transform.childCount];

            for (int i = 0; i <= transform.childCount; i++)
            {
                waypoints[i] = transform.GetChild(i);
            }
        }
    }
}