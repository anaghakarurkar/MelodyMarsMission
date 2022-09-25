using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsMission
{
    public class ChangeFocus
    {

        private readonly Dictionary<Focus, Focus> _leftFocus;
        private readonly Dictionary<Focus, Focus> _rightFocus;
        public ChangeFocus()
        {
            //
            _leftFocus = new()
            {
                { Focus.E, Focus.N },
                { Focus.W, Focus.S },
                { Focus.N, Focus.W },
                { Focus.S, Focus.E }
            };

            _rightFocus = new()
            {
                {Focus.E, Focus.S },
                {Focus.W, Focus.N},
                {Focus.N, Focus.E},
                {Focus.S, Focus.W}
            };

        }

        public Focus GetDirection(Focus direction, char rightOrLeft)
        {
            switch (Char.ToUpper(rightOrLeft))
            {
                case 'R':
                    return _rightFocus[direction];

                case 'L':
                    return _leftFocus[direction];
                default:
                    return _leftFocus[direction]; ;
            }
        }

        
        
    }
}