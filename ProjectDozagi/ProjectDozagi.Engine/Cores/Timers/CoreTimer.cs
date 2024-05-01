using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectDozagi.Engine.Cores.Timers
{
    public class CoreTimer
    {
        public bool IsGoodToGo { get; set; }

        protected int _milliseconds;
        protected TimeSpan _timer;

        public CoreTimer(int second)
        {
            IsGoodToGo = false;
            _milliseconds = second;
        }

        public CoreTimer(int second, bool isStarted)
        {
            _milliseconds = second;
            IsGoodToGo = isStarted;
        }

        public int Milliseconds
        {
            get { return _milliseconds; }
            set { _milliseconds = value; }
        }

        public int Timer
        {
            get { return (int)_timer.TotalMilliseconds; }
        }

        public void Update()
        {
            _timer += Global.GameTime.ElapsedGameTime;
        }

        public void Update(float speed)
        {
            _timer += TimeSpan.FromTicks((long)(Global.GameTime.ElapsedGameTime.Ticks * speed));
        }

        public virtual void Add(int milliseconds)
        {
            _timer += TimeSpan.FromMilliseconds(milliseconds);
        }

        public void Reset()
        {
            _timer = _timer.Subtract(new TimeSpan(0, 0, Milliseconds / 60000, Milliseconds / 1000, Milliseconds % 1000));

            if (_timer.TotalMilliseconds < 0)
            {
                _timer = TimeSpan.Zero;
            }

            IsGoodToGo = false;
        }

        public void Reset(int newTime)
        {
            _timer = TimeSpan.Zero;
            Milliseconds = newTime;
            IsGoodToGo = false;
        }

        public void ToZero()
        {
            _timer = TimeSpan.Zero;
            IsGoodToGo = false;
        }

        public virtual XElement ReturnXml()
        {
            XElement xml = new XElement("Timer",
                new XElement("mSec", Milliseconds),
                new XElement("timer", Timer));

            return xml;
        }

        public void Set(TimeSpan time)
        {
            _timer = time;
        }

        public virtual void Set(int milliseconds)
        {
            _timer = TimeSpan.FromMilliseconds(milliseconds);
        }

        public bool IsDone()
        {
            if (_timer.TotalMilliseconds >= Milliseconds || IsGoodToGo)
            {
                return true;
            }

            return false;
        }
    }
}
