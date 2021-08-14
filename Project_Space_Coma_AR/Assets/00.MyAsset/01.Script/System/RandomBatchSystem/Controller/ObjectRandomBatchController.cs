using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectRandomBatchController : MonoBehaviour
{
    #region 변수

    protected WaitForSecondsRealtime realtime;
    [SerializeField] protected float minGenerateCooltime, maxGenerateCooltime;

    protected int generateCount = 0;

    #endregion

    #region 구현부

    /// <summary> 오브젝트 생성의 루틴을 관리하는 함수 </summary>
    /// <param name="minGenerateCooltime"> 최소 생성 쿨타임 </param>
    /// <param name="maxGenerateCooltime"> 최대 생성 쿨타임 </param>
    /// <param name="maxCount"> Scene 배치에 대한 최대 제한 갯수 </param>
    /// <returns> </returns>
    protected virtual IEnumerator GenerateObject(float minGenerateCooltime, float maxGenerateCooltime, int maxCount)
    {
        while (true)
        {
            yield return new WaitUntil(() => generateCount < maxCount);
            realtime = new WaitForSecondsRealtime(Random.Range(minGenerateCooltime, maxGenerateCooltime));
            generateCount++;
            yield return realtime;

            SettingObject();
        }
    }

    protected abstract void SettingObject();

    protected virtual Vector3 ObjectRandomPosition()
    {
        Vector3 tempVec = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        return tempVec * Random.Range(0, BackgroundSystem.Instance.BackgroundRadius - 1);
    }

    protected abstract Vector3 ObjectRandomScale();

    protected abstract Color DustRandomColor();

    #endregion
}
