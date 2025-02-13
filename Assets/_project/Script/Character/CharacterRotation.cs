using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    [SerializeField] private float _speedRotation=1f;
    [SerializeField] private RectTransform joysticBackground;
    [SerializeField] private Camera cameraMain;
  
    private Touch _touch;
    private Vector2 _touchPosition;
    private Quaternion _rotationY;
    private float joystickSize;


    private void Start()
    {
        joystickSize=Mathf.Min(joysticBackground.rect.width, joysticBackground.rect.height);
    }
    private void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        if (Input.touchCount > 0)
        {

            _touch = Input.GetTouch(0);
            _touchPosition = _touch.position;
            
            var joysticWorlSpace=RectTransformUtility.WorldToScreenPoint(cameraMain,joysticBackground.position);
            var distanceToJoystik = Vector2.Distance(_touchPosition, joysticWorlSpace);

            if( distanceToJoystik<=joystickSize)
                return;
          
            if (_touch.phase == TouchPhase.Moved)
            {
                _rotationY = Quaternion.Euler(0f, -_touch.deltaPosition.x * _speedRotation, 0f);
                transform.rotation = _rotationY * transform.rotation;

            }
        }
    }

}
