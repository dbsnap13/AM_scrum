using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace TextPoint
{
    public class ClickableObject
    {
        Dictionary<string, TextPointer> TxtPtrDictionary = new Dictionary<string, TextPointer>();

        public TextPointer GetPtr(string str)
        {
            var t = TxtPtrDictionary.Single(x => x.Key == str);
            return t.Value;
        }

        public void AddToDic(string str, TextPointer txtPtr)
        {
            if (!(TxtPtrDictionary.ContainsKey(str)))
                TxtPtrDictionary.Add(str, txtPtr);
        }

        public void RemoveFromDic(string txtPtr)
        {
            if (TxtPtrDictionary.ContainsKey(txtPtr))
            {
                TxtPtrDictionary.Remove(txtPtr);
            }
        }
    }

}
