using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get { return this.m_MaxValue; }
            set { this.m_MaxValue = value; }
        }

        public float MinValue
        {
            get { return this.m_MinValue; }
            set { this.m_MinValue = value; }
        }

        public ValueOutOfRangeException(float i_MaxVlue, float i_MinValue)
        {
            m_MaxValue = i_MaxVlue;
            m_MinValue = i_MinValue;
        }

        public override string Message => 
            string.Format(
                "Bad Input! a Valid Input Range is ({0} - {1}) {2}", 
            m_MinValue,
            m_MaxValue,
            Environment.NewLine);
    }
}
