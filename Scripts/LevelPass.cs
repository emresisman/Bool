using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BallHandler();

public class LevelPass : MonoBehaviour
{
    public AudioSource audioS;
    public event BallHandler BallReachTheUp;
    public GameObject particle; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball")
        {
            BallReachTheUp?.Invoke();
            BurstParticleEffect(collision.transform.position);
            audioS.Play();
            collision.gameObject.SetActive(false);
        }
    }

    private void BurstParticleEffect(Vector3 pos)
    {
        Instantiate(particle, pos, particle.transform.rotation);
    }
}