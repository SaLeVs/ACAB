using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GrabObjects : MonoBehaviour
{


    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;

    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;


    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Caixa");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Input.GetMouseButtonDown(1) && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);


            }
            else if (Input.GetMouseButtonDown(1))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }

        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}
