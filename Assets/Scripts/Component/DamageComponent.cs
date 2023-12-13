using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Damage{
    public static class DamageComponent
    {

        public delegate void ApplyDamage(DamageInfo damageInfo) ;
        public static  ApplyDamage applyDamage;

        public static event EventHandler<float> TakenDamage;
        

       

        public static void ApplyPointDamage(Damage.PointDamageInfor pointDamageInfor)
        {
            pointDamageInfor.damageInfo.DamagedTarget.GetComponent<HealthComponent>().TakeDamage(pointDamageInfor.damageInfo.BaseDamage,pointDamageInfor.damageInfo.DamageCauser);

        }

        public static void ApplyRadialDamage(RadialDamageInfor radialDamage,GameObject IgnoredGameObject)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(radialDamage.origin, radialDamage.DamageRadius, radialDamage.notIgnoredObject);
            foreach(Collider2D obj in colliders)
            {
                if(obj.gameObject != IgnoredGameObject)
                {
                   // obj.gameObject.GetComponent<Damage.HealthComponent>()?.TakeDamage(radialDamage.DamageValue);
                }
            }
        }

        public static void ApplyRadialDamage(RadialDamageInfor radialDamage, GameObject IgnoredGameObject, out List<GameObject> affectedObject)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(radialDamage.origin, radialDamage.DamageRadius, radialDamage.notIgnoredObject);
            List<GameObject> gameObjects = new List<GameObject>();
            foreach (Collider2D obj in colliders)
            {
                if (obj.gameObject != IgnoredGameObject)
                {   
                    //obj.gameObject.GetComponent<Damage.HealthComponent>()?.TakeDamage(radialDamage.DamageValue);
                    gameObjects.Add(obj.gameObject);
                }
            }
            affectedObject = gameObjects;
        }
    }
    public struct PointDamageInfor
    {
        public DamageInfo damageInfo;
        public Vector3 HitFromDirector;
        public PointDamageInfor(DamageInfo damageInfo, Vector3 HitFromDirector)
        {
            this.damageInfo = damageInfo;
            this.HitFromDirector = HitFromDirector;
        }
    }

    public struct RadialDamageInfor
    {
        public GameObject DamageCauser;
        public float DamageValue;
        public Vector3 origin;
        public float DamageRadius;
        public LayerMask notIgnoredObject;
        public RadialDamageInfor(GameObject DamageCauser,float Damage, Vector3 origin,float DamageRadius,LayerMask notIgnoredObject)
        {
            this.DamageCauser = DamageCauser;
            this.DamageValue = Damage;
            this.origin = origin;
            this.DamageRadius = DamageRadius;
            this.notIgnoredObject = notIgnoredObject;

        }

    }
    public struct DamageInfo
    {
        public GameObject DamageCauser;
        public GameObject DamagedTarget;
        public float BaseDamage;
        public DamageInfo(GameObject DamageCauser, GameObject DamageTarget, float Damage)
        {
            this.BaseDamage = Damage;
            this.DamageCauser = DamageCauser;
            this.DamagedTarget = DamageTarget;
        }

    }
    
}

