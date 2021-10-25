using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public Animator animator;
    private Rigidbody rigidbody;
    public LayerMask layerMask;
    public bool grounded;

	public GameObject firstPersonCamera;
	public GameObject thirdPersonCamera;
	private bool firstPerson = false;

    public float mouseSensitivity = 100f;
    public Transform playerBody;

	private float velocityX;
	private float velocityZ;

	private bool isChating = false;

    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody>(); 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {

    }

    private void FixedUpdate() {
	    Move();
	    MouseLook();
    }
    
    private void Move()
    {
	    float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();
        
        this.transform.position += movement * 0.04f;
    }
    
    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void setCursor(bool c)
    {
	    if (c)
	    {
		    Cursor.lockState = CursorLockMode.Confined;
	    }
	    else
	    {
		    Cursor.lockState = CursorLockMode.Locked;
	    }
	    Cursor.visible = c;
    }
}