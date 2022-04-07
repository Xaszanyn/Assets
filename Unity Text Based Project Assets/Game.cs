using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] Text textComponent;

    [SerializeField] State startingState;

    State state;



    void Start()
    {

        state = startingState;

        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    void ManageState() {
        var nextStates = state.getNextStates();

        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            state = nextStates[0];
        } else if(Input.GetKeyDown(KeyCode.RightArrow)) {
            state = nextStates[1];
        } else if(Input.GetKeyDown(KeyCode.UpArrow)) {
            state = nextStates[2];
        }

        // Keycode.Alpha1 + number  (is legal)

        textComponent.text = state.GetStateStory();
    }
}
