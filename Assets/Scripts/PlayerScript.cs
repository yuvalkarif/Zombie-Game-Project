using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour// A movement script which uses the physics engine (early concept)
{
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    public Vector2 speed = new Vector2(50, 50);
    Rigidbody2D rb;

    // 2 - Store the movement
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // 4 - Movement per direction
        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

    }

    void FixedUpdate()
    {
        // 5 - Move the game object
       rb.velocity = movement;
    }
}