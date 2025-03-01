using UnityEngine;

public class BirdScript : MonoBehaviour
{
  
    public Rigidbody2D myRigidBody;
    public float flapStrength = 1;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public BoxCollider2D boundaries;
    public AudioSource jumpSound;
    public GameObject explosionPrefab; 

    void Start()
    {   
        gameObject.name = "Bob Birdington";
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();

        jumpSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapStrength;


            if (jumpSound != null)
            {
                jumpSound.Play();
            }

        }


        
        
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerGameOver();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == boundaries && birdIsAlive)
        {
            TriggerGameOver();
        }
    }

     private void TriggerGameOver()
    {
        if (birdIsAlive)
        {
            birdIsAlive = false;
            gameObject.SetActive(false); // Hide the bird

            // Spawn explosion at the bird's position
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            logic.gameOver();
        }
    }
}


