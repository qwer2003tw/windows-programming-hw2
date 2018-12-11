// file:	PresentationModel\PresentationModel.cs
//
// summary:	Implements the presentation model class

using DrawingModel;
using System.Windows.Forms;

namespace DrawingForm.PresentationModel
{
    /// <summary>   A data Model for the presentation. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public class PresentationModel
    {
        /// <summary>   The model. </summary>
        readonly Model _model;

        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="model">    The model. </param>
        /// <param name="canvas">   The canvas. </param>

        public PresentationModel(Model model, Control canvas)
        {
            this._model = model;
        }

        /// <summary>   Draws the given graphics. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="graphics"> The graphics. </param>

        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdapter(graphics));
        }
    }
}
