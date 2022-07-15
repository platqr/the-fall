using UnityEngine;

public class Player : MonoBehaviour
{
  private float speed = 10f;
  [SerializeField] private float gravity = 9.8f;
  [SerializeField] private Rigidbody rb;
  [SerializeField] private LayerMask FloorLayerMask;

  [SerializeField] private float initJumpForce = 40f;
  [SerializeField] private float jumpForce;
  [SerializeField] private float jumpDamp = 70f;
  private bool isJumping = false;

  private float time = 0;

  private void Update()
  {
    time += Time.deltaTime;
    Movement();
    Jump();
    Gravity();
  }

  private void  Gravity()
  {  
    if (!isGrounded())
    {
      transform.Translate(Vector3.forward * gravity * Time.deltaTime, Space.World);
      rb.position += Vector3.forward * gravity * Time.deltaTime;
    }
  }

  private void Movement()
  {
    float xInput = Input.GetAxisRaw("Horizontal");
    float yInput = Input.GetAxisRaw("Vertical");
    transform.Translate(new Vector3(xInput, yInput, 0) * speed * Time.deltaTime, Space.World);
  }

  private void Jump()
  {
    if (Input.GetKeyDown(KeyCode.K))
    {
      isJumping = true;
    }
    if (isJumping  && jumpForce > 0)
    {
      jumpForce -= Time.deltaTime * jumpDamp; 
      transform.Translate(Vector3.back * jumpForce * Time.deltaTime, Space.World);
    }
    if (isGrounded())
    {
      jumpForce = initJumpForce;
      isJumping = false;
    }
  }

  private bool isGrounded()
  {
    return Physics.BoxCast(transform.position, new Vector3(2f,2f,.75f) * .2f, Vector3.forward, Quaternion.identity, .5f, FloorLayerMask);
  }
  
}
