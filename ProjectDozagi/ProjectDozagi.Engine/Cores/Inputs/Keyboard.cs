namespace ProjectDozagi.Engine.Cores.Inputs
{
    public class Key
    {
        public int State { get; set; }

        public string Current { get; set; }

        public string Print { get; set; }

        public string Display { get; set; }

        public Key(string current, int state)
        {
            State = state;
            Current = current;
            MakePrint(current);
        }

        public virtual void Update()
        {
            State = 2;
        }

        public void MakePrint(string key)
        {
            Display = Current;

            string temp = "";

            if (Current == "A" ||
                Current == "B" ||
                Current == "C" ||
                Current == "D" ||
                Current == "E" ||
                Current == "F" ||
                Current == "G" ||
                Current == "H" ||
                Current == "I" ||
                Current == "J" ||
                Current == "K" ||
                Current == "L" ||
                Current == "M" ||
                Current == "N" ||
                Current == "O" ||
                Current == "P" ||
                Current == "Q" ||
                Current == "R" ||
                Current == "S" ||
                Current == "T" ||
                Current == "U" ||
                Current == "V" ||
                Current == "W" ||
                Current == "X" ||
                Current == "Y" ||
                Current == "Z" ||
                Current == "Left" ||
                Current == "Up" ||
                Current == "Right" ||
                Current == "Down"
                )
            {
                temp = Current;
            }

            if (Current == "Space")
            {
                temp = " ";
            }

            if (Current == "OemCloseBrackets")
            {
                temp = "]";

                Display = temp;
            }

            if (Current == "OemOpenBrackets")
            {
                temp = "[";

                Display = temp;
            }

            if (Current == "OemMinus")
            {
                temp = "-";

                Display = temp;
            }

            if (Current == "OemPeriod" || Current == "Decimal")
            {
                temp = ".";
            }

            if (Current == "D1" ||
                Current == "D2" ||
                Current == "D3" ||
                Current == "D4" ||
                Current == "D5" ||
                Current == "D6" ||
                Current == "D7" ||
                Current == "D8" ||
                Current == "D9" ||
                Current == "D0")
            {
                temp = Current.Substring(1);
            }
            else if (Current == "NumPad1" ||
                Current == "NumPad2" ||
                Current == "NumPad3" ||
                Current == "NumPad4" ||
                Current == "NumPad5" ||
                Current == "NumPad6" ||
                Current == "NumPad7" ||
                Current == "NumPad8" ||
                Current == "NumPad9" ||
                Current == "NumPad0")
            {
                temp = Current.Substring(6);
            }

            Print = temp;
        }
    }
}
