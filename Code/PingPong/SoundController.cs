using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RcketPlayer1" || collision.gameObject.name == "RcketPlayer2")
        {
            this.racketSound.Play();
        }
        else
        {
            this.wallSound.Play();
        }
    }
}
