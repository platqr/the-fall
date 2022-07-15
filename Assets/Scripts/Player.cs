using UnityEngine;

public class Player : MonoBehaviour
{
  private Rigidbody rb;
  private float time = 0;

  [SerializeField] private float speed = 10f;

  [SerializeField] private float gravity = 20f;
	[SerializeField] private float initJumpForce = 60f;
  private float jumpForce;
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

		Reset();
  }

  private void FixedUpdate() {
    Gravity();
    Movement();
    Jump();
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

  private void HandleJump()
  {
    if (Input.GetKeyDown(KeyCode.K) && isGrounded() && !makePoint() || makePoint())
    {
      isJumping = true;
    }
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

	private void Reset() {
		if (Input.GetKeyDown(KeyCode.R))
		{
			rb.position = new Vector3(0,0,-4f);
			isJumping=false;
		}
	}

  private bool isGrounded()
  {
    return Physics.BoxCast(transform.position, new Vector3(2f,2f,.75f) * .2f, Vector3.forward, Quaternion.identity, .5f, floorLayerMask);
  }

	private bool makePoint()
  {
    return Physics.BoxCast(transform.position, new Vector3(2f,2f,.75f) * .2f, Vector3.forward, Quaternion.identity, .5f, pointLayerMask);
  }
  
}
