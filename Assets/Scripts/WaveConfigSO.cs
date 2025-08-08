using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    // Position of our path
    [SerializeField] Transform _pathPrefabs;
    // How fast our enemy is moving
    [SerializeField] float _moveSpeed = 5.0f;

    public Transform GetStartingPoint()
    {
        return _pathPrefabs.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform child in _pathPrefabs)
        { 
            waypoints.Add(child);
        }

        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }
}
