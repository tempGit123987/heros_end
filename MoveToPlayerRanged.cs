using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayerRanged : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    private NavMeshAgent agent;

    private Vector3 oldForce;
    private Rigidbody rb;

    private GameObject playerLoc;
    public float attackRange;
    private float currentDistance;
    private bool inRange = false;

    private GameObject enemyFireball;
    private Transform spawnPoint;
    private float nextTimeToFire = 0f; 
    public float speed = 100.0f;
    public float fireRate = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        playerLoc = GameObject.Find("Player");
        player = playerLoc.transform;

        spawnPoint = transform.Find("Ranged Enemy Attack Spawner");

        enemyFireball = GameObject.FindGameObjectWithTag("Enemy Fireball");
    }
    void FixedUpdate()
    {
        if(agent.enabled == true && inRange == false)
        {
            agent.isStopped = false;
            agent.destination = player.position;
        }
        else
        {
            agent.isStopped = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Vector3.Distance(player.transform.position, transform.position);
        if(currentDistance > attackRange)
        {
            inRange = false;
        }
        else
        {
            inRange = true;
            transform.LookAt(player);
            RangedAttack();
        }
    }

    void RangedAttack()
    {
        if(Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            GameObject instFireball = Instantiate(enemyFireball, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Rigidbody instFireballRB = instFireball.GetComponent<Rigidbody>();
            instFireballRB.AddForce(spawnPoint.transform.forward * speed);

            Destroy(instFireball, 3.0f);
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
