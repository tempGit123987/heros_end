using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fb_instantiate : MonoBehaviour
{
    public GameObject pfFireball;
    public Transform spawnPoint;
    public float speed = 100f;
    public float fireRate = 2.0f;
    
    private float nextTimeToFire = 0f;

    private bool canCastFB = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire && canCastFB == true)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Fireball();
        }
    }

    void Fireball()
    {
        GameObject instFireball = Instantiate(pfFireball, spawnPoint.transform.position, spawnPoint.transform.rotation);
        Rigidbody instFireballRB = instFireball.GetComponent<Rigidbody>();
        instFireballRB.AddForce(spawnPoint.transform.forward * speed);

        Destroy(instFireball, 3.0f);
    }

    public void ActivateFB()
    {
        canCastFB = true;
    }
}
