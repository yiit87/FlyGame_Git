using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Bulletspeed = 5000;
    public float Damage = 10f;
    public float Range = 100f;
    public GameObject Location1;
    public GameObject Location2;

    private Ray ray;
    private RaycastHit hit;

    public ParticleSystem MuzzleFlash1;
    public ParticleSystem MuzzleFlash2;

    private GameObject Bullet1;
    private GameObject Bullet2;

    private int Health = 100;
    public AudioSource GunFire;

    private void Start()
    {
        MuzzleFlash1.Stop();
        MuzzleFlash2.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (GunFire.isPlaying == false)
        {
            GunFire.Play();
        }
        MuzzleFlash1.Play();
        MuzzleFlash2.Play();

        Bullet1 = Instantiate(BulletPrefab, Location1.transform.position, transform.rotation);

        Bullet1.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, Bulletspeed));

        Bullet2 = Instantiate(BulletPrefab, Location2.transform.position, transform.rotation);

        Bullet2.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, Bulletspeed));

        if (Physics.Raycast(Location1.transform.position, Location1.transform.forward, out hit, Range))
        {
            EnemyIndividual enemy = hit.transform.GetComponent<EnemyIndividual>();

            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }

            Debug.Log("Hit!");
        }
        Destroy(Bullet1, 1);
        Destroy(Bullet2, 1);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
