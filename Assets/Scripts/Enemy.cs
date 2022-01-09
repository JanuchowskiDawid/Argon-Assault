using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    GameObject parentGameObject;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 3;
    Score score;

    GameObject hitVFX;
    private void Start()
    {
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        score = FindObjectOfType<Score>();
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    private void OnParticleCollision(GameObject other)
    {
        hitVFX = explosion;
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;
        score.IcreaseScore(scorePerHit);
        if (hitPoints==0)
        {
            vfx = Instantiate(explosion, transform.position, Quaternion.identity);
            vfx.transform.parent = parentGameObject.transform;
            score.IcreaseScore(scorePerHit);
            if (gameObject.GetComponent<MeshRenderer>() !=null)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            if (gameObject.GetComponent<SphereCollider>() != null)
            {
                GetComponent<SphereCollider>().enabled = false;
            }
            Destroy(gameObject, 2f);
        }
    }
}
