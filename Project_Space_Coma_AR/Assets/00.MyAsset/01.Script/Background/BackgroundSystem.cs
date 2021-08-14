using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSystem : SceneObject<BackgroundSystem>
{
    [SerializeField] private GameObject background;

    [SerializeField] private float backgroundRadius = 50;

    private void Start() => SetBackgroundScale(backgroundRadius);

    private void SetBackgroundScale(float r)
    {
        float diameter = r * 2;
        background.transform.localScale = new Vector3(diameter, diameter, diameter);
    }

    public float GetBackgroundRadius() => backgroundRadius;
    public float BackgroundRadius => backgroundRadius;

    public Vector3 GetBackgroundScale() => background.transform.localScale;
    public Vector3 BackgroundScale => background.transform.localScale;
}
