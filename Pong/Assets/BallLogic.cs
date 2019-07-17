using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    float DeviantionAgle = 60f;
    public float Speed = 5;

    Rigidbody2D RB;

    float OGPitch;

    Vector3 HeldDirection = new Vector3(0,0,0);

    float HoldDuration = 1.5f;

    float HoldTimer;

    // Start is called before the first frame update
    void Start()
    {
        OGPitch = gameObject.GetComponent<AudioSource>().pitch;
        RB = gameObject.GetComponent<Rigidbody2D>();
        HoldTimer = HoldDuration;
        HeldDirection = new Vector3(Random.Range(-1f, 1), Random.Range(-1f, 1), 0).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<GoalLogic>())
        {
            float right = (transform.position.x >= 0 ? 1 : -1);

            collision.gameObject.GetComponent<GoalLogic>().Goal();

            transform.position = new Vector3(0, transform.position.y, transform.position.z);

            HeldDirection = new Vector3(right, Random.Range(-1, 1), 0).normalized;
            HoldTimer = HoldDuration;
            RB.velocity = Vector3.zero;
        }
        else if(collision.gameObject.name == "Paddle")
        {
            var normal = collision.contacts[0].normal;
            float randDeviationAngle = Random.Range(-DeviantionAgle, DeviantionAgle);
            normal = Quaternion.Euler(0, 0, randDeviationAngle) * normal;

            RB.velocity = normal * Speed;

            // Play paddle sound
            gameObject.GetComponent<AudioSource>().pitch = OGPitch * 0.7f;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            // play bounce sound
            gameObject.GetComponent<AudioSource>().pitch = OGPitch * 0.5f;
            gameObject.GetComponent<AudioSource>().Play();
            print("Hit: " + collision.collider.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HoldTimer > 0)
        {
            HoldTimer -= Time.deltaTime;

            if(HoldTimer <= 0)
            {
                RB.velocity = Speed * HeldDirection;
            }
        }
    }
}
