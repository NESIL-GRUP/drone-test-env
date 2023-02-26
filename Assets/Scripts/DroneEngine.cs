using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace maxkonrad
{
    [RequireComponent(typeof(BoxCollider))]
    public class DroneEngine : MonoBehaviour, IEngine
    {
        #region Variables
        [Header("Engine")]
        [SerializeField] private float maxPower = 4f;
        [Header("Propeller")]
        [SerializeField] private float propSpeed = 500f;
        [SerializeField] private Transform propeller;
        #endregion

        #region InterfaceMethods
        public void InitEngine()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEngine(Rigidbody rb, DroneInputs input)
        {
            Vector3 upVec = transform.up;
            upVec.x = 0f;
            upVec.z = 0f;
            float diff = 1 - upVec.magnitude;
            float finalDiff = Physics.gravity.magnitude * diff;
            
            Vector3 engineForce = Vector3.zero;
            engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude + finalDiff) + (maxPower * input.Throttle)) / 4f;
            rb.AddForce(engineForce, ForceMode.Force);
            RotatePropeller();
        }

        private void RotatePropeller()
        {
            if (!propeller) return;
            propeller.Rotate(Vector3.forward, propSpeed);
        }
    }
        #endregion
}
