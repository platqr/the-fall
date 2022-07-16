using UnityEngine;

public class Player : MonoBehaviour
{
  private Rigidbody rb;
  private float time = 0;

  private float speed = 10f;
	private float jumpForce;
  [SerializeField] private float gravity = 20f;
	[SerializeField] private float initJumpForce = 60f;
	[SerializeField] private float maxJumpHeight = 6f;

  [SerializeField] private LayerMask floorLayerMask;
	[SerializeField] private LayerMask pointLayerMask;

  private bool isJumping = false;

  private void Awake()
  {
    rb = transform.GetComponent<Rigidbody>();
  }

  private void Update()
  {
    time += Time.deltaTime;
    HandleJump();
  }

  private void FixedUpdate() {
    Gravity();
    Movement();
    Jump();
  }

	private void HandleJump()
  {
    if (Input.GetKeyDown(KeyCode.K) && isGrounded() && !onPointer() || onPointer())
    {
      isJumping = true;
    }
  }

  private void  Gravity()
  {  
    if (!isGrounded())
    {
      rb.position += Vector3.forward * gravity * Time.deltaTime;
    }
		else
		{
			rb.position = new Vector3(transform.position.x,transform.position.y,0);
		}
  }

  private void Movement()
  {
    float xInput = Input.GetAxisRaw("Horizontal");
    float yInput = Input.GetAxisRaw("Vertical");
    rb.position += new Vector3(xInput, yInput, 0).normalized * speed * Time.deltaTime;
  }

  private void Jump()
  {
		jumpForce = -((-rb.position.z - maxJumpHeight)/(maxJumpHeight/initJumpForce));

    if (isJumping)
    {
      rb.position += Vector3.back * jumpForce * Time.deltaTime;
			if (jumpForce <= gravity+1)
			{
				isJumping = false;
			}
    }
  }

  private bool isGrounded()
  {
    return Physics.BoxCast(transform.position, new Vector3(2f,2f,.75f) * .2f, Vector3.forward, Quaternion.identity, 1f, floorLayerMask);
  }

	public bool onPointer()
  {
    return Physics.BoxCast(transform.position, new Vector3(2f,2f,.75f) * .2f, Vector3.forward, Quaternion.identity, .5f, pointLayerMask);
  }

	public void Reset() {
		rb.position = new Vector3(0,0,-4f);
    isJumping=false;
	}
}
