using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject impactPrefab;
    [SerializeField] private List<GameObject> trails;
    private Rigidbody _rigidbody;
    private bool _collision;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Get rigidbody
        _rigidbody = GetComponent<Rigidbody>();

        _collision = false;
    }
    
    private void FixedUpdate()
    {
        if (speed != 0 && _rigidbody != null)
        {
            // Move game object
            _rigidbody.position += transform.forward * (speed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // Only allow one collision at a time
        if (_collision) return;
        
        _collision = true;
        
        // Stop meteor's movement
        speed = 0;
        
        // Declare variables
        var contactPoint = other.contacts[0];
        var rotation = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
        var position = contactPoint.point;
            
        if (impactPrefab != null)
        {
            // Instantiate impact prefab
            Instantiate(impactPrefab, position, rotation);
        }
        
        // Check if there's any trails assigned
        if (trails.Count > 0)
        {
            foreach (var t in trails)
            {
                // Don't destroy trails
                t.transform.parent = null;
                
                // Get trail's particle system
                var particleSystem = t.GetComponent<ParticleSystem>();

                if (particleSystem != null)
                {
                    // Stop particle system
                    particleSystem.Stop();
                    
                    // Destroy particle system's game object after a delay
                    Destroy(particleSystem.gameObject, particleSystem.main.duration + particleSystem.main.startLifetime.constantMax);
                }
            }
        }
        
        // Destroy meteor
        Destroy(gameObject);
    }
}
