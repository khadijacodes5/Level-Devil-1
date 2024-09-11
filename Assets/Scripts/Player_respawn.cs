
using UnityEngine;

public class Player_respawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; //sound we'll play when picking up a new checkpoint
    private Transform currentCheckpoint; //storing last checkpoint here
    private Health playerHealth;


    private void Awake()
    {
       playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position; //move player to check poiint position
        playerHealth.Respawn();// Restore player health and reset animation

        //move camera to checkpoint room
        
    }

    //Activate Checkpoints

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
        
    }

}
