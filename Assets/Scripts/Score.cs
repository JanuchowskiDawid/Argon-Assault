using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score=0;
    TMP_Text scoretext;
    // Start is called before the first frame update

    public void IcreaseScore(int amount)
    {
        score += amount;
        scoretext.text = score.ToString();
    }

    void Start()
    {
        scoretext = GetComponent<TMP_Text>();
        scoretext.text = "START";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
