using UnityEngine;

public interface ISurfacePlace 
{
    bool TryPlaceItem(Vector3 transformHand,float maxDistance,out Vector3 position, out Quaternion rotation);
}
