
using UnityEngine;

public class Player : MonoBehaviour
{

    public  Rigidbody playerRB;
    public float bounceForce = 6;

    //private AudioManager audioManager;

    private void  start()
    {
     //   audioManager = FindObjectOfType<AudioManager>();
    }

//public AudioSource bounceAudio;

private void OnCollisionEnter(Collision collision)
{
  //  bounceAudio.Play();
  FindObjectOfType<AudioManager>().Play("bounce");
playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
//Debug.Log(collision.transform.GetComponent<MeshRenderer>().material.name);
string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

if (materialName == "Safe (Instance)")
{
    //The ball hits the safe area
} else if (materialName == "Unsafe (Instance)")
{
    // The ball hit unsafe area
   // Debug.Log("Game Over");
   GameManager.gameOver = true;
FindObjectOfType<AudioManager>().Play("game over");

} else if (materialName == "LastRing (Instance)" && !GameManager.levelCompleted)
{
    //Debug.Log("Level Completed");
    GameManager.levelCompleted = true;
     FindObjectOfType<AudioManager>().Play("Win level");

}
}

}
