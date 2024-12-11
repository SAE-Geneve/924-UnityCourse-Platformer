using System;
using UnityEngine;

public class ContactDetector : MonoBehaviour
{

    private bool _contactDetected = false;
    // Compacted property : getter only
    public bool ContactDetected => _contactDetected;
    
    // Full coded property : get + set
    // public bool ContactDetect
    // {
    //     get
    //     {
    //         return _contactDetected;
    //     }
    //     set
    //     {
    //         _contactDetected = value;
    //     }
    // }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Contacts")) _contactDetected = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Contacts")) _contactDetected = false;
    }

}
