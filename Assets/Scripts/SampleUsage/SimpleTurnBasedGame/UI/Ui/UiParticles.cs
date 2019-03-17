using System.Collections;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiParticles : UiListener
    {
        protected ParticleSystem[] Particles { get; set; }

        protected virtual void Awake()
        {
            Particles = GetComponentsInChildren<ParticleSystem>();
        }

        protected virtual IEnumerator Play(float delay = 0)
        {
            yield return new WaitForSeconds(delay);

            foreach (var particleSys in Particles)
                if (particleSys != null)
                    particleSys.Play();
        }
    }
}