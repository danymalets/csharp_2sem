﻿using System;
namespace HumanProject
{
    public class Judoka : Sportsman, IFighter<Judoka>, IComparable<Judoka>
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
                else _leftHandStrength = Math.Round(value, 4);
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
                else _rightHandStrength = Math.Round(value, 4);
            }
        }
        double _rightHandStrength;

        public double LeftFootStrength
        {
            get
            {
                return _leftFootStrength;
            }
            private set
            {
                if (value > 1e9) _leftFootStrength = 1e9;
                else if (value < 0) _leftFootStrength = 0;
                else _leftFootStrength = Math.Round(value, 4);
            }
        }
        double _leftFootStrength;

        public double RightFootStrength
        {
            get
            {
                return _rightFootStrength;
            }
            private set
            {
                if (value > 1e9) _rightFootStrength = 1e9;
                else if (value < 0) _rightFootStrength = 0;
                else _rightFootStrength = Math.Round(value, 4);
            }
        }
        double _rightFootStrength;

        public Judoka() : base()
        {
            LeftHandStrength = 250;
            RightHandStrength = 250;
            LeftHandStrength = 250;
            RightHandStrength = 250;
        }

        public Judoka(string fullName, string identifier) : base(fullName, identifier)
        {
            LeftHandStrength = 250;
            RightHandStrength = 250;
            LeftHandStrength = 250;
            RightHandStrength = 250;
        }

        public Judoka(string fullName, string identifier,
            double leftHandStrength, double rightHandStrength,
            double leftFootStrength, double rightFootStrength)
            : base(fullName, identifier)
        {
            LeftHandStrength = leftHandStrength;
            RightHandStrength = rightHandStrength;
            LeftFootStrength = leftFootStrength;
            RightFootStrength = rightFootStrength;
        }

        public Judoka(string fullName, string identifier,
            double weight, double height,
            double leftHandStrength, double rightHandStrength,
            double leftFootStrength, double rightFootStrength)
            : base(fullName, identifier, weight, height)
        {
            LeftHandStrength = leftHandStrength;
            RightHandStrength = rightHandStrength;
            LeftFootStrength = leftFootStrength;
            RightFootStrength = rightFootStrength;
        }

        public override string ToString()
        {
            return string.Format("{0}, id={1}, left hand strehgth={2}, right hand strength={3}, " +
                "left foot strehgth={4}, right foot strength={5}",
                FullName, Identifier, LeftFootStrength, RightFootStrength);
        }

        public override void Train(int minutes)
        {
            Random random = new Random();
            LeftHandStrength += 0.005 * minutes * random.Next(1, 11);
            RightHandStrength += 0.005 * minutes * random.Next(1, 11);
            LeftFootStrength += 0.005 * minutes * random.Next(1, 11);
            RightFootStrength += 0.005 * minutes * random.Next(1, 11);
            base.Train(minutes);
        }

        public double GetTotalStrength()
        {
            return LeftHandStrength + RightHandStrength + LeftFootStrength + RightFootStrength;
        }

        public bool FightWith(Judoka opponent)
        {
            Random random = new Random();
            int myChance = (int)(GetTotalStrength() * 100);
            int opponentsChance = (int)(opponent.GetTotalStrength() * 100);
            return random.Next(myChance + opponentsChance) < myChance;
        }

        public int CompareTo(Judoka other)
        {
            return GetTotalStrength().CompareTo(other.GetTotalStrength());
        }
    }
}
