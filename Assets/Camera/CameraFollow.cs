using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float smoothing;

    public Vector2 MaxPosition;
    public Vector2 MinPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameController.CanShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    private void LateUpdate()
    {
        if (Target != null)
            if (transform.position != Target.position)
            {
                Vector3 TargetPos = Target.position;
                TargetPos.x = Mathf.Clamp(TargetPos.x, MinPosition.x, MaxPosition.x);
                TargetPos.y = Mathf.Clamp(TargetPos.y, MinPosition.y, MaxPosition.y);
                transform.position = Vector3.Lerp(transform.position, TargetPos, smoothing);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCamPosLimit(Vector2 MaxPos, Vector2 MinPos)
    {
        MaxPosition = MaxPos;
        MinPosition = MinPos;
    }
}
