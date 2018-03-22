using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Znake.Auxiliary.Helpers
{
    class Helper
    {
        public static Window GetSpecificWindow(string title)
        {
            IEnumerator windowEnumerator = Application.Current.Windows.GetEnumerator();
            while (windowEnumerator.MoveNext())
            {
                if ((windowEnumerator.Current as Window)?.Title == title)
                    return (Window)windowEnumerator.Current;
            }
            return null;
        }
    }
}
