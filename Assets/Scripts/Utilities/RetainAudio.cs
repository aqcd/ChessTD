using UnityEngine;

public class RetainAudio : MonoBehaviour {
    void Awake() {
        RetainAudio[] audios = FindObjectsOfType<RetainAudio>();
        int numOfSessions = audios.Length;

        if (numOfSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
}