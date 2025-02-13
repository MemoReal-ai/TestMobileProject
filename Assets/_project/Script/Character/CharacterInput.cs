
using UnityEngine;
public class CharacterInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Transform transformCamera;

    private IControllebl _controllebl;
    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _nextPosition;

    private void Start()
    {
        _controllebl = GetComponent<IControllebl>();
       
        if (_controllebl == null)
            throw new System.Exception("Nothing IControllebl");
    }
    private void Update()
    {
        
        HarvestInput();
        _controllebl.Move(_nextPosition);
      
    }
    private void HarvestInput()
    {
        _horizontalInput = joystick.Horizontal;
        _verticalInput =joystick.Vertical;
        _nextPosition=new Vector3(_horizontalInput, 0, _verticalInput);
        RemakeWorldInputToLocal();
    }

    private void RemakeWorldInputToLocal()
    {
        _nextPosition=transformCamera.TransformDirection(_nextPosition);
        _nextPosition.y = 0;
        _nextPosition=_nextPosition.normalized;
    }
}
