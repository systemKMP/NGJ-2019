using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Image image;
    public Transform target;
    public float offset;
    private Camera cam;
    private Vector3 startScale;
    private float startDifference;
    // public float sizeMultiplier;
    // public float maxSize, minSize;
    // Start is called before the first frame update
    void Start()
    {
        // startScale = transform.localScale;
        cam = Camera.main;
        // startDifference = ScaleDifference();
        image = GetComponent<Image>();
    }
    void Update(){
        transform.LookAt(cam.transform.position);
        // UpdatePosition();
    }

    float ScaleDifference(){
        Vector2 newPos = cam.WorldToScreenPoint(target.position);
        Vector2 headPos = cam.WorldToScreenPoint(target.position + Vector3.up * 2f);
        float screenDiff = (newPos - headPos).magnitude;
        return screenDiff;
    }
    void UpdatePosition(){
        Vector2 newPos = cam.WorldToScreenPoint(target.position);
        // float screenDiff = ScaleDifference();
        // float newScaleDiff = screenDiff / startDifference * (sizeMultiplier/100); 
        // print("old:" + newScaleDiff);
        // newScaleDiff = Mathf.Clamp(newScaleDiff, minSize, maxSize);
        // print("new: " + newScaleDiff);
        // transform.localScale = startScale * newScaleDiff;
        transform.position = newPos + Vector2.up * offset; 
    }
    public void SetValue(float value){
        image = GetComponentInChildren<Image>();
        print(value);
        image.fillAmount = value;
    }
}
