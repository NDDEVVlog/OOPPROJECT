using UnityEditor;
using UnityEngine;
using NDCode;
[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{   

    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.up, 360, fov.radius);
        float anglePlus = 0;
        if (fov.xDirection == 1)
            anglePlus = 0;
        else
            anglePlus = 180 ;
        float FOVangle = fov.angle + anglePlus;
        Vector2 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.z, -FOVangle/ 2);
        Vector2 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.z, FOVangle / 2);
        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position,NDUtilsClass.Vec3toVec2( fov.transform.position )+ viewAngle01 * fov.radius);
        Handles.DrawLine(fov.transform.position, NDUtilsClass.Vec3toVec2(fov.transform.position) + viewAngle02 * fov.radius);
        if (fov.canSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position,fov.playerRef.transform.position);
        }

    }
    private Vector2 DirectionFromAngle(float eulerY,float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector2(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad) );
    }
}
