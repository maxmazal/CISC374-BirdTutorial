using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidBody;
    public float flapStrength = 1;
    public LogicScript logic;
    public bool birdIsAlive;
    public BoxCollider2D boundaries;
    public AudioSource jumpSound;

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
            logic.gameOver();
        }
    }
}


