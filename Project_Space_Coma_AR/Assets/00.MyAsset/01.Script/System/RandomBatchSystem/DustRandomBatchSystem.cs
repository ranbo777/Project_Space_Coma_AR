using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustRandomBatchSystem : ObjectRandomBatchController
{
    #region 변수

    public static DustRandomBatchSystem Instance;
    
    [SerializeField] GameObject dust;

    [SerializeField] int dustMaxCount = 100;

    [SerializeField] float minDustScale, maxDustScale;
    float scaleTemp = 0;

    Gradient gradient;
    [SerializeField] Color[] gradientColor;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    #endregion

    #region 유니티 생명주기

    private void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        SetGradientColor();

        StartCoroutine(GenerateObject(minGenerateCooltime, maxGenerateCooltime, dustMaxCount));
    }

    #endregion

    #region 구현부

    void SetGradientColor()
    {
        gradient = new Gradient();
        colorKey = new GradientColorKey[gradientColor.Length];
        alphaKey = new GradientAlphaKey[gradientColor.Length];

        for (int i = 0; i < gradientColor.Length; i++)
        {
            colorKey[i].color = gradientColor[i];
            alphaKey[i].alpha = gradientColor[i].a;
            colorKey[i].time = alphaKey[i].time = ((float)i / (gradientColor.Length - 1));
        }

        gradient.SetKeys(colorKey, alphaKey);
    }

    protected override void SettingObject()
    {
        GameObject generateObject = JHS.PoolManager.Instance.PopObject(dust);

        generateObject.transform.position = ObjectRandomPosition();
        generateObject.transform.localScale = ObjectRandomScale();
        generateObject.GetComponent<Renderer>().material.color = DustRandomColor();
    }

    protected override Vector3 ObjectRandomScale()
    {
        scaleTemp = Random.Range(minDustScale, maxDustScale);
        return Vector3.one * scaleTemp;
    }

    protected override Color DustRandomColor()
    {
        // scaleTemp에 비례해서 색이 변화하게 작성
        Color tempColor;
        tempColor = gradient.Evaluate(scaleTemp / maxDustScale);
        //print(tempColor);
        //print($"{scaleTemp / maxDustScale}");
        return tempColor;
    }

    #endregion
}
