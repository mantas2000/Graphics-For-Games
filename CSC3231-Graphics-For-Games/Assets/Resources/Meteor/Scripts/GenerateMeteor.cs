using UnityEngine;

public class GenerateMeteor : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    
    // Start is called before the first frame update
    private void Start()
    {
        // Get start and end point positions
        var startPosition = startPoint.position;
        var endPosition = endPoint.position;
        
        // Instantiate meteor in the scene
        var objMeteor = Instantiate(meteor, startPosition, Quaternion.identity);
        
        // Rotate meteor
        RotateObject(objMeteor, endPosition);
    }

    private void RotateObject(GameObject obj, Vector3 destination)
    {
        // Get object's direction
        var direction = destination - obj.transform.position;
        
        // Get object's rotation
        var rotation = Quaternion.LookRotation(direction);
        
        // Rotate the object
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}
