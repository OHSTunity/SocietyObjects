using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concepts.Ring1
{
    public interface ISomethingTemplate
    {
        bool IsEqualTo(Something what);
        Something NewInstance(decimal quantity);
    }
}
