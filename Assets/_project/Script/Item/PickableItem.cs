using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickableItem : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody Rigidbody=>rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

   
}
