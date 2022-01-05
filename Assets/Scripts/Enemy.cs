using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 3;
    Score score;
    private void Start()
    {
        score = FindObjectOfType<Score>();

    }
    private void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        score.IcreaseScore(scorePerHit);
        if (hitPoints==0)
        {
            explosion.Play();
            score.IcreaseScore(scorePerHit);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}
