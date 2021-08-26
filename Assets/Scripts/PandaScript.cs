using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaScript : MonoBehaviour
{
    // Public variables that specifies the features of the  panda
    public float speed; // The movement speed
    public float health; // The amount of health
    public Vector3 initialDestination;
    [Tooltip("How much in seconds the enemy is stunned")]
    [Range(1f, 10f)]
    public float timeStunnedLimit;
    public int cakeEatenPerBite;
    // Private variable to store the Animator for handling animations
    private Animator Animator;
    // Hash representation of the Triggers of the Animator controller of the panda
    private int AnimDieTriggerHash = Animator.StringToHash("DieTrigger");
    private int AnimHitTriggerHash = Animator.StringToHash("HitTrigger");
    private int AnimEatTriggerHash = Animator.StringToHash("EatTrigger");
    private float timeStunned = 0.0f;
    private bool isStunned = false;

    private float animationSpeedAux;
    private Rigidbody2D rb2D;
    //private static variable to store the game manager
    private static GameManagerScript gameManager;
    // private counter for the waypoints
    private Waypoint currentWaypoint;
    //Private constant under which a waypoint is considered reached
    private const float changeDist = 0.001f;

    void Awake()
    {
        if (!(GetComponent<Rigidbody2D>()))
        {
            Debug.LogWarning("Your gameObject " + gameObject.name + " doesn't have a rigidbody component.");
            AddRigidbody2dKinematicComponent();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //If the reference to the Game Manager is missing, the script gets it
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManagerScript>();
        }
        // Get the first waypoint from the GameManager
        currentWaypoint = gameManager.firstWaypoint;


        Animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        foreach (var item in Animator.parameters)
        {
            Debug.Log(item.name);
        }
    }

    void FixedUpdate()
    {
        // We deal with physics in FixedUpdate because physics executes a lot of times in a frame

        //if the Panda has reached the cake, then it will eat it, by triggering the right animation,
        //and remove this script, since the State Machine Behaviour will take care of removing the Panda
        if (currentWaypoint == null)
        {
            Animator.SetTrigger(AnimEatTriggerHash);
            gameManager.BiteTheCake(cakeEatenPerBite);
            Destroy(this);
            return;
        }

        //Calculate the distance between the Panda and the waypoint that the Panda is moving towards
        // float dist = Vector2.Distance(transform.position, currentWaypoint.GetPosition());

        //If the waypoint is considered reached because below the threshold of the constant changeDist
        //the counter of waypoints is increased, otherwise the Panda moves towards the waypoint
        // if (dist <= changeDist)
        // {
        //     currentWaypoint = currentWaypoint.GetNextWaypoint();
        // }
        // else
        // {

        // New code: now the current point is managed by trigger colliders in panda and waypoint tag
        MoveTowards(currentWaypoint.GetPosition());
        // }
    }

    // function that detects projectiles
    void OnTriggerEnter2D(Collider2D other)
    {
        // check if the other collider is a projectile 
        if (other.tag == "Projectile")
        {
            // Apply damage to this panda with the hit function
            Hit(other.GetComponent<ProjectileScript>().damage,
                other.GetComponent<ProjectileScript>().probabilityToStun
            );
        }

        if (other.tag == "Waypoint")
        {
            currentWaypoint = currentWaypoint.GetNextWaypoint();
        }
    }

    void AddRigidbody2dKinematicComponent()
    {
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    //Function that based on the speed of the Panda makes it moving towards the destination point, specified as Vector3
    private void MoveTowards(Vector3 destination)
    {
        if (isStunned)
        {
            stopMotion();
            return;
        }
        if (health <= 0)
        {
            return;
        }
        //Create a step and then move in towards destination of one step
        float step = speed * Time.fixedDeltaTime;
        rb2D.MovePosition(Vector3.MoveTowards(transform.position, destination, step));

    }

    private void stopMotion()
    {
        timeStunned += Time.deltaTime;
        Animator.speed = 0.5f;
        if (timeStunned > timeStunnedLimit)
        {
            timeStunned = 0;
            isStunned = false;
            Animator.speed = animationSpeedAux;
        }
    }

    //Function that takes as input the damage that Panda received when hit by a sprinkle.
    //After have detracted the damage to the amount of health of the Panda checks if the Panda
    //is still alive, and so play the Hit animation, or if the health goes below zero the Die animation
    private void Hit(float damage, float probValue) // switch to private, its on public only for test porpuses Ui buton damage
    {
        //Subtract the damage to the health of the Panda
        health -= damage;
        //Then it triggers the Die or the Hit animations based if the Panda is still alive
        if (health > 0)
        {
            isStunned = probStun(probValue);
            animationSpeedAux = Animator.speed;
        }
        else
        {
            Animator.SetTrigger("DieTrigger");
            gameManager.OneMorePandaInHeaven();
        }
    }

    // function that triggers the eat animation 
    private void Eat()
    {
        Animator.SetTrigger(AnimEatTriggerHash);
    }

    private bool probStun(float value)
    {
        float rand = Random.Range(0f, 1f);
        return rand <= (value / 100);
    }
}
