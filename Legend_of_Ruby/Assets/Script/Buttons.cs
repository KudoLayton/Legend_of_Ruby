using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

    public string nextStage;
    public void NextStage() {
        Application.LoadLevel(nextStage);
    }

    public void Replay() {
        Application.LoadLevel(Application.loadedLevel);
    }
}
