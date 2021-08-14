using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderSystem : SceneObject<FolderSystem>
{
    #region 변수

    [SerializeField] Transform a;
    //[SerializeField] Transform b;
    //[SerializeField] Transform c;
    //[SerializeField] Transform d;

    #endregion

    #region 속성

    public Transform A => a;
    //public Transform B => b;
    //public Transform C => c;
    //public Transform D => d;

    #endregion
}
