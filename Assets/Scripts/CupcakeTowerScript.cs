using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeTowerScript : MonoBehaviour
{
    [Header("Tower Damage")]
    [Tooltip("Distance that the cupcake can shoot.")]
    [Range(0f, 10f)]
    public float rangeRadius; // Maximum distance that the Cupcake tower can shoot.

    [Tooltip("Time before the cupcake is able to shoot again.")]
    [Range(0f, 10f)]
    public float reloadTime; // Time before the cupcake tower is able to shoot again.

    [Tooltip("Type of projectile fired from the projectile tower.")]
    public GameObject projectilePrefab; //  Projectile type that is fired from the projectile tower.
    [Header("Tower Level")]
    [Tooltip("Different sprites as levels of the cupcake tower")]
    public Sprite[] upgradeSprites; // Different sprites for the different levels of cupcake tower

    [Tooltip("Determines if the tower is upgradable")]
    // Boolean to check if the tower is upgradable.
    public bool isUpgradable = true;
    // Private upgrade level variable
    private int upgradeLevel; // Level of the cupcake tower.
    public int UpgradeLevel => upgradeLevel; // to get (read only) our private variable upgradeLevel
    // How much this tower cost when it is bought
    public int initialCost;
    // How much this tower costs when it is upgraded
    public int upgradingCost;
    // How much this tower is valuable if solf
    public int sellingValue;
    private Sprite currentSprite; // To store our spriteRenderer as sprite (our sprite levels of the tower)
    [Tooltip("Time elapsed from the last time that the cupcake tower has shot.")]
    [Range(0f, 10f)]
    private float elapsedTime; // Time elapsed from the last time the Cupcake tower has shot.

    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime >= reloadTime)
        {
            // Reset elapsed time
            elapsedTime = 0;
            // Find all the gameObjects with a collider within the range of the cupcake tower.
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rangeRadius);
            // Check if there is at least one gameObject found.
            if (hitColliders.Length != 0)
            {
                // Loop over all the gameobjects to identify the closest to the cupcake tower.
                float min = int.MaxValue;
                int index = -1;

                for (int i = 0; i < hitColliders.Length; i++)
                {
                    if (hitColliders[i].tag == "Enemy")
                    {
                        float distance = Vector2.Distance(hitColliders[i].transform.position, transform.position);
                        if (distance < min)
                        {
                            index = i;
                            min = distance;
                        }
                    }
                }

                if (index == -1)
                    return;

                // Get the direction of the target
                Transform target = hitColliders[index].transform;
                Vector2 direction = (target.position - transform.position).normalized;

                Debug.LogWarning("creating projectile");
                // Create the projectile
                GameObject projectile = GameObject.Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
                projectile.GetComponent<ProjectileScript>().direction = direction;
            }
        }
        elapsedTime += Time.deltaTime;
    }

    public void Upgrade()
    {
        // Check if the tower is upgradable
        if (!isUpgradable)
        {
            return;
        }

        // Increase the level of the tower
        upgradeLevel++;

        // Check if the tower has reached its last level.
        if (upgradeLevel == upgradeSprites.Length - 1)
        {
            isUpgradable = false;
        }

        // Increase the stats of the tower
        rangeRadius += 1f;
        reloadTime -= 0.5f;

        // Change the graphics of the tower
        GetComponent<SpriteRenderer>().sprite = upgradeSprites[upgradeLevel];
        Debug.LogWarning("upgrade Level: " + upgradeLevel);

        // Increase the value of the tower
        sellingValue += 5;

        // Increasing the upgrading cost
        upgradingCost += 10;
    }

    // function called when the player clicks on the cupcake tower
    void OnMouseDown()
    {
        // Assign this tower as the archive tower for trading operations
        TradeCupcakeTower.SetActiveTower(this);
    }
}
