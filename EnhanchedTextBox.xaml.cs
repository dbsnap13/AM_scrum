using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextPoint
{
    /// <summary>
    /// Interaction logic for EnhanchedTextBox.xaml
    /// </summary>
    public partial class EnhanchedTextBox : UserControl
    {
        public bool GetSetBool { get; set; }
        public bool GetSetUnderLine { get; set; }
        public bool GetSetItalic { get; set; }

        public EnhanchedTextBox()
        {
            InitializeComponent();
        }

        private void txtBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        public void AdjustBool()
        {
            if (!GetSetBool)
            {
                txtBox.FontWeight = FontWeights.Normal;
            }
            else
                txtBox.FontWeight = FontWeights.Bold;
        }

        public void AdjustUnderLine()
        {
            if (!GetSetUnderLine)
            {
                txtBox.TextDecorations = null;
            }
            else
                txtBox.TextDecorations = TextDecorations.Underline;
        }

        public void AdjustItalic()
        {
            if (!GetSetItalic)
            {
                txtBox.FontStyle = FontStyles.Italic;
            }
            else
                txtBox.FontStyle = FontStyles.Normal;
        }
    }
}
