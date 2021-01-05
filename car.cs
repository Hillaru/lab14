using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lab_14.CONSTANTS;

namespace lab_14
{
    public static class CONSTANTS
    {
        public const int DEFAULT_MASS = 1;
        public const int DEFAULT_SPEED = 1;
        public const double DEFAULT_CONSUMPTION = 0.01;
    }

    public abstract class vechile
    {
        protected int _speed, _mass;
        protected double _consumption;

        public double consumption //суммарное потребление выносливости/топлива транспортным средством
        {
            get { return _consumption; }
            set
            {
                if (value > 0)
                    _consumption = value;
                else
                    _consumption = DEFAULT_CONSUMPTION;
            }
        }

        public int speed
        {
            get { return _speed; }
            set
            {
                if (value > 0)
                    _speed = value;
                else
                    _speed = DEFAULT_SPEED;
            }
        }

        public int mass
        {
            get { return _mass; }
            set
            {
                if (value > 0)
                    _mass = value;
                else
                    _mass = DEFAULT_MASS;
            }
        }

        public vechile(int _mass, int _speed)
        {
            mass = _mass;
            speed = _speed;
        }

        public vechile() { }

        public double move(double distance)
        {
            if (distance <= 0)
                return 0;

            double actual_distance = speed / (mass * consumption);

            return Math.Min(actual_distance, distance);
        }
    }

    class CarComparer : IComparer<car>
    {
        public int Compare(car c1, car c2)
        {
            return c1.CompareTo(c2);
        }
    }

    public class car : vechile , IComparable, ICloneable
    {
        public car(int _mass = DEFAULT_MASS, double _fuel_cons = DEFAULT_CONSUMPTION, int _speed = DEFAULT_SPEED) : base(_mass, _speed)
        {
            consumption = _fuel_cons;
        }

        public car() { }

        public int CompareTo (object o)
        {
            car car = o as car;
            if (car != null)
                return speed.CompareTo(car.speed);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public object Clone()
        {
            return new car(mass, consumption, speed);
        }
    }
}
