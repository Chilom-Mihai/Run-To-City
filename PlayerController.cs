using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimator;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound; 
    public float jumpForce = 650.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();//assign the animator variable  to an animator component
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        //Jump player
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) 
            //when the player is on the ground and the space bar is pressed we will apply that force to make him jump 
            //and if the game is not over
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Jump faster
            isOnGround = false; // when the player jump isOnGround is false
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound,1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       


        if(collision.gameObject.CompareTag("Ground"))//we check if the object that we collide with is tagged as Ground
        {
            isOnGround = true; // is true when the player colides with the ground
            dirtParticle.Play();
        }    
        else if (collision.gameObject.CompareTag("Obstacle"))// if is an obstacle 
        {
            Debug.Log("Game Over");// to see when our game is over
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();//it will play the particle
            dirtParticle.Stop();//we stop the particle
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
