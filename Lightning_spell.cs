using UnityEngine;

public class Lightning_spell : MonoBehaviour
{

    public Camera fpsCam;

    public float damage = 10f;
    public float range = 100f;

    public float fireRate = 2.0f;

    private float nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            ShootLightening();
        }
    }

    void ShootLightening()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            enemy_health enemy = hit.transform.GetComponent<enemy_health>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    public void IncreaseDamage(float damageMult)
    {
        damage = damage * damageMult;
    }
}