using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    [SerializeField] private float _speedRotation=1f;

    private Touch _touch;
    private Vector2 _touchPosition;
    private Quaternion _rotationY;
    private void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        if(Input.touchCount==0) return;
        
        _touch=Input.GetTouch(0);

        if(_touch.phase==TouchPhase.Moved)
        {
            _rotationY = Quaternion.Euler(0f,-_touch.deltaPosition.x*_speedRotation,0f);
            transform.rotation = _rotationY*transform.rotation;

        }
    }

}
