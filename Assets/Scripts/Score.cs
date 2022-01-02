using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score=0;

    // Start is called before the first frame update

    public void IcreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score is: " + score);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
