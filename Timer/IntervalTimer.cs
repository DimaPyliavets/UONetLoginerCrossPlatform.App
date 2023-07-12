using System.Timers;

namespace UONetLoginerCrossPlatform.Timer
{
    public class IntervalTimer
    {
        private System.Timers.Timer timer;
        private TimeSpan duration;
        private Action callback;

        public IntervalTimer(TimeSpan duration, Action callback)
        {
            this.duration = duration;
            this.callback = callback;
        }

        public void Start()
        {
            timer = new System.Timers.Timer(duration.TotalMilliseconds);
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            callback?.Invoke();
            timer.Stop();
        }
    }
}
