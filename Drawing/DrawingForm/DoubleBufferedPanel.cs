// file:	DoubleBufferedPanel.cs
//
// summary:	Implements the double buffered panel class

using System.Windows.Forms;

namespace DrawingForm
{
    /// <summary>   Panel for editing the double buffered. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    class DoubleBufferedPanel : Panel
    {
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public DoubleBufferedPanel()
        {
            DoubleBuffered = true;
        }
    }
}
