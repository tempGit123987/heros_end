using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    private Vector3 oldForce;
    private Rigidbody rb;

    private GameObject playerLoc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        playerLoc = GameObject.Find("Player");
        player = playerLoc.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(agent.enabled == true)
        {
        agent.destination = player.position;
        }
    }

    public void GotHit()
    {
        StartCoroutine(Knockback());
    }

    private IEnumerator Knockback()
    {
        rb.isKinematic = false;
        agent.enabled = false;
        yield return new WaitForSeconds(1.0f);
        rb.isKinematic = true;
        agent.enabled = true;
    }


}
