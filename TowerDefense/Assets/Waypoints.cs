using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //can we make this not static
    //I'm stubborn and want to make this an IEnumerable but don't see how yet
    public static Transform[] waypoints;

    public void Awake()
    {
        waypoints = new Transform[transform.childCount];

        for(int i = 0; i <= transform.childCount; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
