using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plyer : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody rb;   
    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f;

    public int maxHealth = 10;
    int currentHealth;

    public int CollectedCoins;

    private Camera mainCamera;
    // Start is called before the first frame update

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void Start()
    {
        currentHealth = maxHealth;

        gameManager.UpdateHealthText(currentHealth, maxHealth);

        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        movment();
        jump();
    }
    public void movment()
    {

        float horizentalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 moveDirection = cameraForward.normalized * verticalInput + cameraRight.normalized * horizentalInput;


        if (moveDirection != Vector3.zero)
        {

            transform.forward = moveDirection;

            transform.position += moveDirection * moveSpeed * Time.deltaTime;

        }
    }

    public void jump()
    {

        if (Input.GetButtonDown("Jump")) 
        {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            Vector3 damageDirection = other.transform.position - transform.position;

            damageDirection.Normalize();

            rb.AddForce(-damageDirection* 2f, ForceMode.Impulse);
            currentHealth -= 1;

            if (currentHealth <= 0)
            {
                gameManager.Restart();
            }

            gameManager.UpdateHealthText(currentHealth, maxHealth);

            
        }

        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CollectedCoins += 1;

            gameManager.UpdateCoinText(CollectedCoins);

            Destroy(other.gameObject);
        }
    }

    
}
