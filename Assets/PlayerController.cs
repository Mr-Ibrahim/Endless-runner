using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce=10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip Dying;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    private bool crashed=false;
    nextLevel levelchangescript;

    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();
        playerAnim=GetComponent<Animator>();
        playerAudio=GetComponent<AudioSource>();
        Physics.gravity *=gravityModifier;
        levelchangescript = this.GetComponent<nextLevel>();
        playerAnim.SetFloat("Speed_f", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound,1.0f);
            isOnGround=false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
        }
        
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("ground") && !crashed){
            isOnGround=true;
            dirtParticle.Play();
        }else if(collision.gameObject.CompareTag("obstacle") && !crashed){
            gameOver=true;
            SpawnManager.spawn.Ended();
            crashed=true;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound,1.0f);
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            Debug.Log("Game Over!");
            playerAudio.PlayOneShot(Dying,1.0f);
            Invoke("Gotonext", 3);
            
        }
        
    }
    public void Gotonext()
    {
        levelchangescript.nextScene();
    }
}
