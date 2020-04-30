using System;

namespace HumanProject
{
    public class Boxer : Sportsman
    {
        public double LeftHandStrength
        {
            get
            {
                return _leftHandStrength;
            }
            private set
            {
                if (value > 1e9) _leftHandStrength = 1e9;
                else if (value < 0) _leftHandStrength = 0;
                else _leftHandStrength = value;
            }
        }
        double _leftHandStrength;

        public double RightHandStrength
        {
            get
            {
                return _rightHandStrength;
            }
            private set
            {
                if (value > 1e9) _rightHandStrength = 1e9;
                else if (value < 0) _rightHandStrength = 0;
                else _rightHandStrength = value;
            }
        }
        double _rightHandStrength;

        public Boxer() : base() {
            LeftHandStrength = 500;
            RightHandStrength = 500;
        }

        public Boxer(string fullName, string identifier) : base(fullName, identifier) {
            LeftHandStrength = 500;
            RightHandStrength = 500;
        }

        public Boxer(string fullName, string identifier,
            double leftHandStrength, double rightHandStrength) : base(fullName, identifier)
        {
            LeftHandStrength = leftHandStrength;
            RightHandStrength = rightHandStrength;
        }

        public Boxer(string fullName, string identifier, double weight, double height,
            double leftHandStrength, double rightHandStrength) : base(fullName, identifier, weight, height)
        {
            LeftHandStrength = leftHandStrength;
            RightHandStrength = rightHandStrength;
        }

        public override string ToString()
        {
            return string.Format("{0}, id={1}, weight={2}, height={3}, left hand strength={4}, right hand strength={5}",
                FullName, Identifier, Weight, Height, LeftHandStrength, RightHandStrength);
        }

        public override void Train(int minutes)
        {
            Random random = new Random();
            LeftHandStrength += 0.01 * minutes * random.Next(1, 11);
            RightHandStrength += 0.01 * minutes * random.Next(1, 11);
            base.Train(minutes);
        }
    }
}
