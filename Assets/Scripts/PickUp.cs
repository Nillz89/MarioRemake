using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    
     
    public AudioClip noSound;
    public AudioClip pickUpSound;
    public GameObject graphic;
    AudioSource src;


    public void Start()
    {
        src = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            if (collision.attachedRigidbody.GetComponent<Player>())
            {
                Player player = collision.attachedRigidbody.GetComponent<Player>();
                if (!player.IsMaxHeart())
                {
                    player.AddHeart();
                    graphic.SetActive(false);
                    GetComponent<Collider2D>().enabled = false;
                    if(src && pickUpSound)
                    {
                        src.PlayOneShot(pickUpSound);
                    }
                }
                else if(src && noSound)
                {
                    src.PlayOneShot(noSound);
                }
            }
        }
    }



}
