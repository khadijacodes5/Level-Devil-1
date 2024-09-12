
using UnityEngine;

public class Player_respawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; //sound we'll play when picking up a new checkpoint
    private Transform currentCheckpoint; //storing last checkpoint here
    private Health playerHealth;
    private UIManager uiManager;


    private void Awake()
    {
       playerHealth = GetComponent<Health>();
       uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        //check if checkpoint available
        if (currentCheckpoint == null)
        {
            //show game over screen
            uiManager.GameOver();

            return; //Don't execute rest of this function

        }
        playerHealth.Respawn();// Restore player health and reset animation
        transform.position = currentCheckpoint.position; //move player to check poiint position
        

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
