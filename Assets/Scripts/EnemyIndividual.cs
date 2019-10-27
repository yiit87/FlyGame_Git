using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIndividual : MonoBehaviour
{
    public float MySpeed;
    public float MyHealth;

    private GameObject Player;

    public GameObject BulletPrefab;

    public float Bulletspeed = 5000;

    public int Damage = 10;
    public float Range = 20f;

    public GameObject Location1;
    public GameObject Location2;

    private Ray ray;
    private RaycastHit hit;

    public ParticleSystem MuzzleFlash1;
    public ParticleSystem MuzzleFlash2;

    private GameObject Bullet1;
    private GameObject Bullet2;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.LookAt(Player.transform, transform.up );
        transform.position += transform.forward * MySpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, Player.transform.position) <= 100)
        {
            
            ShootPlayer();

            //open fire
            if (Physics.Raycast(Location1.transform.position, Location1.transform.forward, out hit, Range))
            {

                PlayerFire player = hit.transform.GetComponent<PlayerFire>();

                if (player != null)
                {
                    player.TakeDamage(Damage);
                }

                Debug.Log("Player Hit!");
            }
        }
    }

    private void ShootPlayer()
    {
        MuzzleFlash1.Play();
        MuzzleFlash2.Play();
        Bullet1 = Instantiate(BulletPrefab, Location1.transform.position, transform.rotation);

        Bullet1.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, Bulletspeed));

        Bullet2 = Instantiate(BulletPrefab, Location2.transform.position, transform.rotation);

        Bullet2.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, Bulletspeed));

      
        Destroy(Bullet1, 1);
        Destroy(Bullet2, 1);
    }
    public virtual void TakeDamage(float amount)
    {
        MyHealth -= amount;

        if (MyHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }


}
