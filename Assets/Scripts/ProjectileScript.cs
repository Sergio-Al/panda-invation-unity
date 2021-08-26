using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    
    [Tooltip("Determines the direction of the projectile")]
    public Vector3 direction; // What direction the projectile is heading.

    [Header("General Damage")]
    [Tooltip("Determines how much damage will the enemy receive.")]
    [Range(0f, 10f)]
    public float damage; // How much damage will the enemy receive.
    [Tooltip("How fast the projectile moves.")]
    [Range(1f, 10f)]
    public float speed = 1f; // How fast is the projectile moves.
    [Tooltip("How long the projecile lives before is self-killed")]
    [Range(0f, 10f)]
    public float lifeDuration = 10f; // How long the projectile lives before the self-destructing.
    // [Tooltip("if the projectile must stun the enemy")]
    // public bool shouldStunEnemy; // Disabled for the new prob stun feature
    [Tooltip("Probability of stun the enemy")]
    [Range(0f, 100f)]
    public float probabilityToStun;
    // private variable to store the Rigidbody 2D
    private Rigidbody2D rb2D;


    void Awake()
    {
        if (!(gameObject.GetComponent<Rigidbody2D>()))
        {
            Debug.LogWarning("your rigidbody in: " + gameObject.name + " doesn't exists");
            AddRigidbody2dKinematicComponent();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // Normalize the direction
        direction = direction.normalized;

        // Fix the rotation
        float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        rb2D = GetComponent<Rigidbody2D>();

       

        // Set the timer for self-destruction
        Destroy(gameObject, lifeDuration);
    }

    // Update is called once per frame
    // Update the position of the projectile according to time and speed
    void FixedUpdate()
    {
        // kinematic law for velocity : (Delta)Space =  Velocity * (delta)time
        rb2D.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed); // basically nextPosition =  CurrentPosition + Velocity * (Delta)Time
    }

    void AddRigidbody2dKinematicComponent()
    {
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
}
