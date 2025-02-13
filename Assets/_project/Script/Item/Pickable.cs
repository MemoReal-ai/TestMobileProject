using UnityEngine;
using UnityEngine.UI;

public class Pickable : MonoBehaviour
{
    [SerializeField] private float interactDistance=1f;
    [SerializeField] private Transform hand;
    [SerializeField] private Button dropButton;
    [SerializeField] private Camera playerCamer;
    [SerializeField] private float throwStrainght=5f;
    [SerializeField] private SurfacePlacer surfacePlacer;

    private PickableItem _handItem=null;
  
    private void Start()
    {
        dropButton.onClick.AddListener(DropItem);
        dropButton.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        dropButton.onClick.RemoveListener(DropItem);
    }
    private void Update()
    {
        ReadTouch();
    }

    private void ReadTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            TryPickUp(); 

    }

    private void TryPickUp()
    { 
        if(_handItem != null)
            return;

        var touchPosition=Input.GetTouch(0).position;
        var ray=playerCamer.ScreenPointToRay(touchPosition);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.TryGetComponent<PickableItem>(out PickableItem item))
            {
                PickUP(item);
            }
        }
    }

    private void PickUP(PickableItem item)
    {
        var rb = item.GetComponent<Rigidbody>();
        
        if (rb == null)
        {
            Debug.Log("Nothing RigidBody");
            return;
        }
        
        _handItem = item;
        rb.isKinematic = true;
        _handItem.transform.SetParent(hand);
        _handItem.transform.localPosition = Vector3.zero;
        _handItem.transform.localRotation = Quaternion.identity;

        dropButton.gameObject.SetActive(true);
    }

    private void DropItem()
    {
        if (_handItem == null)
            return;

        var rb=_handItem.GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.Log("Nothing RigidBody");
            return;
        }
        rb.isKinematic = false;
        rb.useGravity = true;
       
        if (surfacePlacer.TryPlaceItem(hand.transform.position,interactDistance,out Vector3 position,out Quaternion rotation))
        {
          
            _handItem.transform.SetParent(null);
            _handItem.transform.position= position;
            _handItem.transform.rotation= rotation*_handItem.transform.rotation;

        }
        else
        {  
            rb.AddForce(playerCamer.transform.forward * throwStrainght, ForceMode.Impulse);
            _handItem.transform.SetParent(null);
           
        }



        _handItem = null;
        dropButton.gameObject.SetActive(false);
    }

}

