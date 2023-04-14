using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Turrets
{
    public class TurretController : MonoBehaviour
    {
        public bool isInTurret;
        public int lookRadius;
        private Transform _transform;

        private void Update()
        {
            if (isInTurret)
            {
                var turrets = new List<Collider2D>();
                Physics2D.OverlapCircle(transform.position, lookRadius, new ContactFilter2D().NoFilter(), turrets);

                foreach (Collider2D turret in turrets.Where((c) => c.gameObject.CompareTag("Turret ")))
                {
                    //turret.GameObject().ConvertTo<NormalTurret>().OnUpdate();
                }
            }
        }
    }
}