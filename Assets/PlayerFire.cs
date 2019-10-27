using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Bulletspeed = 5000;

    public GameObject Location1;

    private Ray ray;
    private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject obj = Instantiate(BulletPrefab, Location1.transform.position, transform.rotation);
            obj.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, Bulletspeed));
        }

        if (Physics.Raycast(transform.position, transform.forward,out hit, 100))
        {
            Debug.Log("Hit!");
        }
    }
}
