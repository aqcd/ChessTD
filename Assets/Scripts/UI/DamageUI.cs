using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour {
    public static DamageUI instance;
    
    public GameObject damagePanel;
    private Image image;

    private float maxTargetAlpha = 0.25f;
    private float minTargetAlpha = 0.0f;
    private float fadeOutRate = 10.0f;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        image = damagePanel.GetComponent<Image>();
    }

    public void damageTaken() {
        fadeIn();
    }
     
    void Update() {
        Color curColor = image.color;
        if (curColor.a - minTargetAlpha > 0.0001f) {
            curColor.a = Mathf.Lerp(curColor.a, minTargetAlpha, fadeOutRate * Time.deltaTime);
            image.color = curColor;
        }
    }
 
     private void fadeIn() {
         Color curColor = image.color;
         curColor.a = maxTargetAlpha;
         image.color = curColor;
     }
}