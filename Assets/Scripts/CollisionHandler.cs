using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;


    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + "Collided with" + other.gameObject.name);
        StartCrashSequence();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.name + "Trigged with" + other.name);
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GetComponent<ControllerScript>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
