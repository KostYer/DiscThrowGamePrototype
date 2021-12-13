using System;
using Interactions;
using UnityEngine;

namespace GameLogic
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private TriggerSource triggerSource;
        [SerializeField] private ParticleSystem destructionParticles;
        
        public event Action<Target> OnDeath;

        private void Start()
        {
            triggerSource.OnEnter += OnEnter;
        }

        private void OnEnter(Collider other)
        {
            
            Die();
        }

        private void Die()
        {   
            destructionParticles.transform.SetParent(null);
            destructionParticles.transform.localScale = Vector3.one;
            destructionParticles.Play();
            Destroy(destructionParticles.gameObject, 2f);
            OnDeath?.Invoke(this);
        }
        
        
    }
}