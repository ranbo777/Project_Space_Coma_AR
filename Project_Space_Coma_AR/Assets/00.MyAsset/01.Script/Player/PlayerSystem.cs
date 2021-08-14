using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : SceneObject<PlayerSystem>
{
    #region 변수

    [SerializeField] GameObject _player;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    Collider _collider;

    #endregion

    #region 속성

    public GameObject Player => _player;
    public Animator Animator => _animator = _animator ? _animator : Player.GetComponent<Animator>();
    public SpriteRenderer SpriteRenderer => _spriteRenderer = _spriteRenderer ? _spriteRenderer : Player.GetComponent<SpriteRenderer>();
    public Collider Collider => _collider = _collider ? _collider : Player.GetComponent<Collider>();

    #endregion
}
