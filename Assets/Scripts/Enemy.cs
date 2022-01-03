using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] int scorePerHit = 15;
    Score score;
    private void Start()
    {
        score = FindObjectOfType<Score>();
    }
    private void OnParticleCollision(GameObject other)
    {
        explosion.Play();
        score.IcreaseScore(scorePerHit);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        Destroy(gameObject, 2f);
    }
}
