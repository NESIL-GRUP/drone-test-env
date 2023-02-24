using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

namespace maxkonrad
{
    [RequireComponent(typeof(BoxCollider))]
    public class DroneController : BaseRigidBody
    {
        #region Variables
        [Header("Control Properties")]
        [SerializeField] private float minMaxPitch = 30f;
        [SerializeField] private float minMaxRoll = 30f;
        [SerializeField] private float yawPower = 0.5f;
        [SerializeField] private float lerpSpeed = 2f;

        private DroneInputs droneInputs;
        private List<IEngine> engines = new List<IEngine>();

        private float yaw;
        
        private float finalPitch;
        private float finalRoll;
        private float finalYaw;

        BoxCollider boxCollider;
        #endregion

        #region MainMethods

        void Start()
        {
            droneInputs = GetComponent<DroneInputs>();
            engines = GetComponentsInChildren<IEngine>().ToList();
            boxCollider = GetComponent<BoxCollider>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "green")
            {
                print("Success!!!");
                
            }
            if (collision.gameObject.tag == "red") 
            {
                print("Fail!!!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        #endregion

        #region CustomMethods
        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleControls();
        }

        protected virtual void HandleEngines()
        {
            //rb.AddForce(Vector3.up * (rb.mass * Physics.gravity.magnitude));
            foreach (IEngine engine in engines)
            {
                engine.UpdateEngine(rb, droneInputs);
            }
        }

        protected virtual void HandleControls()
        {
            float pitch = droneInputs.Cyclic.y * minMaxPitch;
            float roll = droneInputs.Cyclic.x * minMaxRoll;
            yaw += droneInputs.Pedals * yawPower;
            
            finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
            finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
            finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);
            
            Quaternion rot = Quaternion.Euler(finalPitch, finalYaw, finalRoll);

            rb.MoveRotation(rot);

        }
        #endregion
    }

}
