using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NDCode{ 
public class NDUtilsClass
{
    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    public static Vector2 Get2DVectorFromAngleMultiplyWithRange(float Range, float angle)
    {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector2(Range * Mathf.Cos(angleRad), Range * Mathf.Sin(angleRad));
    }
    public static Vector2 Vec3toVec2(Vector3 pos)
    {
            return new Vector2(pos.x, pos.y);
    }
        public static Vector3 Vec2toVec3(Vector3 pos)
        {
            return new Vector3(pos.x, pos.y,0);
        }
        public static float GetAngleFromVectorFloat(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            if (n < 0) n += 360;
            return n;
        }
        public static float GetAngleFromVector(Vector3 dir)
        {
            float n = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            return n;
        }
        public static float GetAngleBetween2Vector(Vector3 point1, Vector3 point2)
        {
            return Vector3.Angle(point1, point2);
        }
        public static Vector3 GetDirection(Vector3 point1,Vector3 point2)
        {
            return point2 - point1;
        }
    public static float GetFloatAngleFromVectorBaseOnHorizontalAxis(Vector3 dir)
    {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x);// * Mathf.Rad2Deg; 
            return n; //Unity use Radiant to calculate.
    }
    public static float GetHorizontal2DDistance(Vector2 oldPos,Vector2 newPos)
    {
        return Vector2.Distance(new Vector2(oldPos.x,0),new Vector2(newPos.x,0));
    }
    public static float GetVertical2DDistance(Vector2 oldPos, Vector2 newPos)
    {
            return Vector2.Distance(new Vector2(0, oldPos.y), new Vector2(0, newPos.y));
    }

    

        public static IEnumerator ChangeFloatInPeriod(float A, float B, float time)
        {
            var C = A;
            A = B;
            yield return new WaitForSeconds(time);
            A = C;
        }
        public static IEnumerator ChangeIntegerInPeriod(int A, int B, float time)
        {
            var C = A;
            A = B;
            yield return new WaitForSeconds(time);
            A = C;
        }
        public static float GetVelocityFromVectorVelocity2D(Vector2 vtVelocity)
        {
            return Mathf.Sqrt(Mathf.Pow(vtVelocity.x, 2) + Mathf.Pow(vtVelocity.y, 2));
        }
        public static float GetVelocityFromVectorVelocity3D(Vector3 vtVelocity)
        {
            return Mathf.Sqrt(Mathf.Pow(vtVelocity.x, 2) + Mathf.Pow(vtVelocity.y, 2) + Mathf.Pow(vtVelocity.z,2));
        }
    }
    
    public class PhysicEquation
    {
        public class ProjectileMotion
        {
            public static float GetMaximumHeight(float velocity, float angle , float GravityScale,float initialHeight)
            {
                return initialHeight + ( ( Mathf.Pow(velocity, 2) * Mathf.Sin(angle) ) / (2 * GravityScale) );
                //Equation of MaximumHeight
            }
            public static void CaculateProjectileMovementGizmo()
            {

            }
        }
    }
}