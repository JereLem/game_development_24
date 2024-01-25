using System.Collections;
using UnityEngine;

namespace EventSystem
{
    public class TickSystem : MonoBehaviour
    {
        // Tick variables 
        private float timer;
        private float timerMax;
        [SerializeField] private int currentTick = 0;

        [SerializeField] private int tickSpeed;

        public int GetCurrentTick() { return currentTick; }
        public int GetTickSpeed() { return tickSpeed; }

        private void Start()
        {
            StartCoroutine(Tick());
        }

        private IEnumerator Tick()
        {
            float tickInterval = 1f / tickSpeed;

            while (true)
            {
                currentTick++;
                GameEvents._current.OnTick(currentTick);
                
                float elapsed = 0f;
                while (elapsed < tickInterval)
                {
                    elapsed += Time.deltaTime;
                    yield return null;
                }
            }
        }
    }
}