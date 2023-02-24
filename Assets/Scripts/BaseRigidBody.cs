using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace maxkonrad
{
    [RequireComponent(typeof(Rigidbody))]
    public class BaseRigidBody : MonoBehaviour
    {
        #region Variables
        [Header("BaseRigidBody")]
        [SerializeField] private float weight = 1f;

        public Rigidbody rb;

        protected float startDrag;
        protected float startAngularDrag;
        #endregion

        #region MainMethods
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (rb)
            {
                rb.mass = weight;
                startDrag = rb.drag;
                startAngularDrag = rb.angularDrag;
            }
        }
        private void FixedUpdate()
        {
            if (!rb) return;
            HandlePhysics();
        }
        #endregion

        #region CustomMethods
        protected virtual void HandlePhysics()
        {
            
        }
        #endregion
    }
}
