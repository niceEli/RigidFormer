using UnityEngine;
using UnityEngine.SceneManagement;

public class RigidbodyMovement : MonoBehaviour
{
	public Rigidbody2D rigidbodys; // The Rigidbody component that you want to move
	public float speed = 0.1f; // The speed at which the Rigidbody should move
	public float jumpForce = 10f; // The force with which the Rigidbody should jump
	public LayerMask groundLayers; // The layers that should be considered as ground for the purpose of jumping
	public float maxforce;
	public float friction;

	private bool isGrounded; // Whether the Rigidbody is currently grounded

	void FixedUpdate ()
	{
		// Check if the Rigidbody is grounded
		isGrounded = Physics2D.OverlapCircle(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), 0.45f, groundLayers);

		// Get input from the horizontal axis (left and right arrow keys or A and D keys)
		float horizontalInput = Input.GetAxis("Horizontal");

		// Calculate the direction in which the Rigidbody should move
		Vector2 movementDirection = new Vector2(horizontalInput, 0);

		// Normalize the movement direction to ensure that the Rigidbody moves at a constant speed
		//movementDirection = movementDirection.normalized;

		// Calculate the velocity of the Rigidbody based on the movement direction and speed
		Vector2 velocity = movementDirection * speed;

		// Set the Rigidbody's velocity
		//rigidbodys.velocity += new Vector2(velocity.x, 0);

		if (isGrounded)
		{
			rigidbodys.velocity += new Vector2(velocity.x, 0);
			//rigidbodys.velocity = new Vector2(rigidbodys.velocity.x * friction, rigidbodys.velocity.y);
			rigidbodys.velocity = new Vector2(Mathf.Clamp(rigidbodys.velocity.x, -maxforce, maxforce), rigidbodys.velocity.y);
		}
		else
		{
			//rigidbodys.velocity = new Vector2(Mathf.Clamp(rigidbodys.velocity.x, -maxforce*2, maxforce*2), rigidbodys.velocity.y);
		}

	}
	private void Update ()
	{

		// If the space bar is pressed and the Rigidbody is grounded, add a force to make it jump
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
		{
			if (isGrounded)
			{
				rigidbodys.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			}
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}