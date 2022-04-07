using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // this is important

public class Guess : MonoBehaviour {

    public int max;
    public int min;

    public TextMeshProUGUI guessText;
    int guess;

    void Start ()
    {
        NextGuess(0);
        // max = max + 1;
	}
	

    public void OnPressHigher() {
            min = guess;
            NextGuess(1);
    }
    public void OnPressLower() {
            max = guess;
            NextGuess(-1);
    }

	void Update ()
    {

    }
    void NextGuess(int range)
    {

        if(max - min <= 1) {
            if(range == 1) {
                guess = max;
                min = max;
            } else if(range == -1) {
                guess = min;
                max = min;
            }
        } else {
            if(range == 1) {
                min = guess + 1;
            } else if (range == -1) {
                max = guess - 1;
            } 
        }
        
        
        guess = Random.Range(min, max);

        guessText.text = guess.ToString();
    }
}
