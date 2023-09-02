using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.UnityAdvanced.Mat2.Handlers
{
    public class AimHandler : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Transform muzzelPointTransform;
        [SerializeField] private float maxDistance;

        [SerializeField] private ParticleSystem muzzelPointStart;
        [SerializeField] private ParticleSystem muzzelPointEnd;

        private void Awake()
        {
            lineRenderer.enabled = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) Activate();
            else if (Input.GetMouseButtonUp(0)) Deactivate();
        }

        private void FixedUpdate()
        {
            Ray ray = new Ray(muzzelPointTransform.position, muzzelPointTransform.forward);
            bool cast = Physics.Raycast(ray, out RaycastHit hit, maxDistance);

            Vector3 hitPosition = cast ? hit.point : muzzelPointTransform.position + muzzelPointTransform.forward * maxDistance;

            lineRenderer.SetPosition(0, muzzelPointTransform.position);
            lineRenderer.SetPosition(1, hitPosition);

            muzzelPointEnd.transform.position = hitPosition;
        }

        private void Activate()
        {
            lineRenderer.enabled = true;
            
            muzzelPointStart.Play();
            muzzelPointEnd.Play();
        }

        private void Deactivate()
        {
            lineRenderer.enabled = false;
            lineRenderer.SetPosition(0, muzzelPointTransform.position);
            lineRenderer.SetPosition(1, muzzelPointTransform.position);

            muzzelPointStart.Stop();
            muzzelPointEnd.Stop();
        }
    }
}
