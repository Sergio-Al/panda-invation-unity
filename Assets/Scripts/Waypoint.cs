using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteAlways]
public class Waypoint : MonoBehaviour
{
    //Private variable to store the next waypoint in the chain
    //It is serializable, so it can be set in the Inspector
    [SerializeField]
    private Waypoint nextWaypoint;
    // private bool isAlreadyInit = false; // for generate references Not working
    //Function to retrieve the position of the waypoint
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    //Function to retrieve the next waypoint in the chain
    public Waypoint GetNextWaypoint()
    {
        return nextWaypoint;
    }

    void OnDrawGizmosSelected()
    {
        if (GetNextWaypoint() != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(GetPosition(), GetNextWaypoint().GetPosition());
        }
    }

    // void Awake()
    // {
    //     GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    //     for (int i = 0; i < waypoints.Length; i++)
    //     {
    //         if (i > 0)
    //         {
    //             waypoints[i].GetComponent<Waypoint>().nextWaypoint = waypoints[i - 1].GetComponent<Waypoint>();
    //         }
    //         else
    //         {
    //             waypoints[i].GetComponent<Waypoint>().nextWaypoint = null;
    //         }
    //     }
    // }

    //     void Awake()
    //     {

    // #if UNITY_EDITOR
    //         InitVariables();
    // #endif
    //         Debug.Log(gameObject.name.Split('_')[1]);
    //     }

    //     void InitVariables()
    //     {
    //         if (isAlreadyInit)
    //         {
    //             return;
    //         }
    //         GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    //         gameObject.name = "Waypoint_" + waypoints.Length;

    //         foreach (var waypoint in waypoints)
    //         {
    //             if (int.Parse(waypoint.name.Split('_')[1]) == int.Parse(gameObject.name.Split('_')[1]) - 1)
    //             {
    //                 waypoint.GetComponent<Waypoint>().nextWaypoint = this;
    //             }
    //         }
    //         isAlreadyInit = true;
    //     }

    // void Awake()
    // {
    //     GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    //     if (waypoints.Length == 1)
    //     {
    //         return;
    //     }
    //     foreach (var waypoint in waypoints)
    //     {
    //         Waypoint waypointRef = waypoint.GetComponent<Waypoint>();
    //         GameObject refToSelf = gameObject;
    //         if (waypointRef.nextWaypoint == null && waypoint != gameObject)
    //         {
    //             waypointRef.nextWaypoint = this;
    //             break;
    //         }

    //     }
    // }
}
