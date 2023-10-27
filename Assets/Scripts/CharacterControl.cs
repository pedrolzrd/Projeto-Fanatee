using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{
    PlayerInput playerInput;

    private Controls controls;

    public GameObject number;


    private float v, h;

    public int id;

    public bool colected = false;
    public bool colectedByPlayer2 = false;
    public bool powerUpColected = false;
    public bool powerUpColectedByPlayer2 = false;

    public bool isAdding;

    [SerializeField]
    public GameObject powerUpEffect;

    [SerializeField] public float initialSpeed;
    [HideInInspector] public float m_moveSpeed;
    
    [SerializeField] private float m_jumpForce = 4;

    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;



    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    private bool m_jumpInput = false;

    private bool m_isGrounded;

    private List<Collider> m_collisions = new List<Collider>();


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        controls = new Controls();
        controls.Player1Actions.SomaStart.performed += x => AddingPressed();
        controls.Player1Actions.SomaFinished.performed += x => AddingReleased();

        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
        id = Random.Range(1, 5);

        m_moveSpeed = initialSpeed;
    }

    private void OnEnable()
    {
        controls.Enable(); 
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        if (!m_jumpInput && playerInput.actions["Jump"].triggered)
        {
            m_jumpInput = true;
        }


        
        if (playerInput.actions["DropNumber"].triggered && colected == true)
        {
            number = GameObject.FindGameObjectWithTag("CollectedP1");
            Destroy(number);
            colected = false;
        }

        if (playerInput.actions["DropNumber"].triggered && colectedByPlayer2 == true)
        {
            number = GameObject.FindGameObjectWithTag("CollectedP2");
            Destroy(number);
            colectedByPlayer2 = false;
        }
    }

    private void AddingPressed()
    {
        isAdding = true;
    }

    private void AddingReleased()
    {
        isAdding = false;
    }

    private void FixedUpdate()
    {
        m_animator.SetBool("Grounded", m_isGrounded);


        DirectUpdate();


        m_wasGrounded = m_isGrounded;
        m_jumpInput = false;
    }

    private void DirectUpdate()
    {

        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();

        v = input.y;
        h = input.x;

        Transform camera = Camera.main.transform;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            v *= m_walkScale;
            h *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;

            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }
        JumpingAndLanding();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }
   
    //Metodo que controle o pulo e o pouso.
    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && m_jumpInput)
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }

    
}
