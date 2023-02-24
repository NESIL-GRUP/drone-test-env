using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace maxkonrad
{
    public class CamChase : MonoBehaviour
    {
        #region Variables
        [SerializeField] private Transform target;
        [SerializeField] private float lerpSpeed = 10f;
        private Vector3 distance;
        private Vector3 targetPos;
        private Vector3 newPos;
        #endregion

        #region MainMethods
        private void Start()
        {
            distance = transform.position - target.position;
        }
        private void FixedUpdate()
        {
            if (!target) return;

            RotateCam();
            ChaseTargetPos();
        }
        #endregion

        #region CustomMethods
        private void ChaseTargetPos()
        {
            targetPos = target.position;
            transform.position = Vector3.Lerp(transform.position, target.transform.position + target.transform.forward * distance.z + new Vector3(0, distance.y, 0), Time.deltaTime * lerpSpeed);
        }

        private void RotateCam()
        {
            transform.LookAt(target.transform.Find("Horizon").transform);
            //transform.RotateAround(target.transform.position, target.transform.up, target.transform.rotation.y * lerpSpeed * Time.deltaTime);
        }
        #endregion
    }
}