using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] private float movementSpeed = 12f;

    // Update is called once per frame
    private void Update()
    {
        // Get user's input
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Up&Down");
        var z = Input.GetAxis("Vertical");

        // Create Vector by using user's input
        var movementDirection = transform.right * x + transform.up * y + transform.forward * z;

        // Move object
        controller.Move(movementDirection * (movementSpeed * Time.deltaTime));
    }
}
