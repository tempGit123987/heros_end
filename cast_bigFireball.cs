using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cast_bigFireball : MonoBehaviour
{
    public GameObject pfBigFireball;
    public Transform spawnPoint;
    public float speed = 100f;
    public float fireRate = 2.0f;
    
    private float nextTimeToFire = 0f;

    private bool canFireBigFireball = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && Time.time >= nextTimeToFire && canFireBigFireball == true)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            fire_bigFireball();
        }
    }

    void fire_bigFireball()
    {
        GameObject instBigFireball = Instantiate(pfBigFireball, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rbInst = instBigFireball.GetComponent<Rigidbody>();
        rbInst.AddForce(transform.forward * speed);

        Destroy(instBigFireball, 3.0f);
    }

    public void ActivateBigFireball()
    {
        canFireBigFireball = true;
    }
}
