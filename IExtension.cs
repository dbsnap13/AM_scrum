using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPoint
{
    /// <summary>
    /// DO WE NEED THIS?
    /// </summary>
    public interface IExtension
    {
        void Initialize(ITextPoint hostApplication);
        string GetTitle();
        void Execute();
    }
}
