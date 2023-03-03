
using System;

namespace SomnusTools
{
    public class Timer
    {
        public float remainingSeconds { get; private set; }

        public Timer(float duration)
		{
            remainingSeconds = duration;
		}

        public event Action OnTimerEnd;

        public void Tick(float deltaTime)
		{
            if (remainingSeconds == 0) { return; }

            remainingSeconds -= deltaTime;

            CheckTimerEnd();
		}

		private void CheckTimerEnd()
		{
            if (remainingSeconds > 0) { return; }

            remainingSeconds = 0f;

            OnTimerEnd?.Invoke();
		}

        public void SetRemainingTime(float amountOfTimeRemaining)
        {
            remainingSeconds = amountOfTimeRemaining;
        }
    }
}

