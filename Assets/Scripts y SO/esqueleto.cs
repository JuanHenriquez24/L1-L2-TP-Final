using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class esqueleto : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(player.position);
    }
}
