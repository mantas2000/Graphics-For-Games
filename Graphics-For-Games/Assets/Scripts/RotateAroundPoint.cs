using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private bool rotateY;
    [SerializeField] private bool rotateZ;
    public GameObject pivotObject;

    // Update is called once per frame
    private void Update()
    {
        // Move around selected game object
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, rotateY ? 1 : 0, rotateZ ? 1 : 0), rotationSpeed * Time.deltaTime);
    }
}
