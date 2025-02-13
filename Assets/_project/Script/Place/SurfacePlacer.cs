
using UnityEngine;

public class SurfacePlacer : MonoBehaviour, ISurfacePlace
{
  

    public bool TryPlaceItem(Vector3 transformHand
        ,float maxDistance
        ,out Vector3 position
        ,out Quaternion rotation)
    {

        if(Physics.Raycast(transformHand,Vector3.down,out RaycastHit hit,maxDistance))
        {
            if (hit.collider.GetComponent<Place>() != null) 
            {
                position = hit.point + hit.normal;
                rotation = Quaternion.FromToRotation(Vector3.up,hit.normal);
                return true;
            }
        }

        position=Vector3.zero;
        rotation=Quaternion.identity;
        return false;
    }
}
