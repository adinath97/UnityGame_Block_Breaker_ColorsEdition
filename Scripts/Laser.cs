using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defRayDistance = 300f;
    public LineRenderer myLineRenderer;
    public Transform laserFirePoint;
    Transform myTransform;

    void Awake()
    {
        myTransform = this.GetComponent<Transform>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        myLineRenderer.useWorldSpace = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    void ShootLaser() {
        if(Physics2D.Raycast(myTransform.position,this.transform.right)) {
            //Ray hit = Physics.Raycast(myTransform.position,this.transform.right);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, this.transform.right);
            Draw2DRay(laserFirePoint.position,hit.point);
        }
        else {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defRayDistance);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos) {
        myLineRenderer.SetPosition(0, startPos);
        myLineRenderer.SetPosition(1, endPos);
        //myLineRenderer.SetPosition(1, transform.forward * defRayDistance + new Vector3(0,transform.position.y,0));
    }
}
