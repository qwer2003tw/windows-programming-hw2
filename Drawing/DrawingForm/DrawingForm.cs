// file:	DrawingForm.cs
//
// summary:	Implements the drawing Windows Form

using DrawingModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingForm
{
    /// <summary>   Form for viewing the drawing. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public partial class DrawingForm : Form
    {
        /// <summary>   The model. </summary>
        Model _model;
        /// <summary>   The presentation model. </summary>
        PresentationModel.PresentationModel _presentationModel;
        /// <summary>   The canvas. </summary>
        Panel _canvas = new DoubleBufferedPanel();

        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public DrawingForm()
        {
            InitializeComponent();
            //
            // prepare canvas
            //
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);

            //
            // prepare presentation model and model
            //
            _model = new Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
        }

        /// <summary>   Handles the model changed. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        private void HandleModelChanged()
        {
            Invalidate(true);
        }

        /// <summary>   Handles the clear button click. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>

        private void HandleClearButtonClick(object sender, EventArgs e)
        {
            _model.Clear();
        }

        /// <summary>   Handles the line button click. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>

        private void HandleLineButtonClick(object sender, EventArgs e)
        {
            _model.ChangeToLine();
        }

        /// <summary>   Handles the diamond button click. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>

        private void HandleDiamondButtonClick(object sender, EventArgs e)
        {
            _model.ChangeToDiamond();
        }

        /// <summary>   Handles the canvas paint. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Paint event information. </param>

        private void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        /// <summary>   Handles the canvas moved. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>

        private void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _model.PointerMoved(e.X, e.Y);
        }

        /// <summary>   Handles the canvas released. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>

        private void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _model.PointerReleased(e.X, e.Y);
        }

        /// <summary>   Handles the canvas pressed. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>

        private void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _model.PointerPressed(e.X, e.Y);
        }

    }
}
