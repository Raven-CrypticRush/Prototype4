using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public GameObject cannonBall;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            shoot(5);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(SteadyShot(6, 0.5f));
        }
    }

    public void shoot(int numberOfBalls)
    {
        for(int i = 0; i < numberOfBalls; i++)
        {
            Instantiate(cannonBall, transform.position, transform.rotation);
        }
    }

    IEnumerator SteadyShot (int numberOfBalls, float delay)
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            Instantiate(cannonBall, transform.position, transform.rotation);
            yield return new WaitForSeconds(delay);
        }
    }

}
