using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    private void Awake()
    {
        // Get floor layer
        floorMask = LayerMask.GetMask("Floor");

        // Get animator component
        anim = GetComponent<Animator>();

        // Get rigidbody component
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get horizontal input (-1,0,1)
        float h = Input.GetAxisRaw("Horizontal");

        // Get vertical input (-1,0,1)
        float v = Input.GetAxisRaw("Vertical");
        
        Move(h, v);
        Turning();
        Animating(h, v);
    }

    public void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        // Ray based on mouse pos in screen
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Ray cast on floorhit
        RaycastHit floorHit;

        // Raycast
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Get vector player and floorhit
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            // Get rotation look to hit pos
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Player Rotation
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    public void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
