using JHS;
using UnityEngine;

public class ControllerSystem : SceneObject<ControllerSystem>
{
    #region 변수

    [SerializeField] JoystickController m_joystickController;

    #endregion

    #region 공개 속성

    public Vector2 InputDirection => m_joystickController.InputDirection;

    #endregion
}
