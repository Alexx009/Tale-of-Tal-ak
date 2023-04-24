using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseTiling : MonoBehaviour
{
     public Material material; // assign the material to modify in the Inspector
    public float minTiling = 0.1f; // the minimum Y tiling value
    public float maxTiling = 4f; // the maximum Y tiling value
    public float flowSpeed = 0.1f; // the speed at which to change the tiling
    public float flowAmplitude = 0.05f; // the amplitude of the flow effect

    private float currentTilingY; // the current Y tiling value
    private float timeOffset; // the time offset for the flow effect

    private void Start()
    {
        currentTilingY = material.mainTextureScale.y; // get the initial Y tiling value
        timeOffset = Random.Range(0f, 100f); // randomly set the time offset for the flow effect
    }

    private void Update()
    {
        float newTilingY = currentTilingY + flowAmplitude * Mathf.Sin(Time.time * flowSpeed + timeOffset);
        if (newTilingY > maxTiling) // if the new tiling value exceeds the maximum value, reset to 0
        {
            newTilingY = 1;
        }
        material.mainTextureScale = new Vector2(material.mainTextureScale.x, newTilingY); // apply the new Y tiling to the material
        currentTilingY = newTilingY;
    }

}
