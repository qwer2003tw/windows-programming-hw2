// file:	PresentationModel\PresentationModel.cs
//
// summary:	Implements the presentation model class

using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DrawingApp.PresentationModel
{
    /// <summary>   A data Model for the presentation. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    class PresentationModel
    {
        /// <summary>   The model. </summary>
        Model _model;
        /// <summary>   The igraphics. </summary>
        IGraphics _graphics;

        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="model">    The model. </param>
        /// <param name="canvas">   The canvas. </param>

        public PresentationModel(Model model, Canvas canvas)
        {
            _graphics = new WindowsStoreGraphicsAdaptor(canvas);
            this._model = model;
        }

        /// <summary>   Draws this object. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_graphics);
        }
    }
}
