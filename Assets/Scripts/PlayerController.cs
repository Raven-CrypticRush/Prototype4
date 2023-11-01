using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables

    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5.0f;

    [Header("PowerUps")]
    public bool hasPowerUp = false;
    public float powerupStrength = 15.0f;

    [Header("Powerup Indicator")]
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        //gathering components and locations
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //movement control
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        //Powerup indicator follows player

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            //Coroutine start
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        //wait
        yield return new WaitForSeconds(7);

        //powerup wares off
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            //powerup effect
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            //check if collision works
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);

            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

        }
    }

}
