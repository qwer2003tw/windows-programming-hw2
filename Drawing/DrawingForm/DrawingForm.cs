// file:	DrawingForm.cs
//
// summary:	Implements the drawing Windows Form

using DrawingForm.PresentationModel;
using DrawingModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingForm
{
    /// <summary>   Form for viewing the drawing. </summary>

    public partial class DrawingForm : Form
    {
        /// <summary>   The model. </summary>
        Model _model;
        /// <summary>   The presentation model. </summary>
        PresentationModel.PresentationModel _presentationModel;
        /// <summary>   The canvas. </summary>
        Panel _canvas = new DoubleBufferedPanel();

        /// <summary>   Default constructor. </summary>

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
            var adapter = new WindowsFormsGraphicsAdapter(_canvas.CreateGraphics());

            _model = new Model(adapter);
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
        }

        /// <summary>   Handles the model changed. </summary>

        private void HandleModelChanged()
        {
            Invalidate(true);
        }

        /// <summary>   Handles the clear button click. </summary>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>

        private void HandleClearButtonClick(object sender, EventArgs e)
        {
            _model.Clear();
        }

        /// <summary>   Handles the line button click. </summary>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>

        private void HandleLineButtonClick(object sender, EventArgs e)
        {
            _model.ChangeToLine();
        }

        /// <summary>   Handles the diamond button click. </summary>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>

        private void HandleDiamondButtonClick(object sender, EventArgs e)
        {
            _model.ChangeToDiamond();
        }

        /// <summary>   Handles the canvas paint. </summary>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Paint event information. </param>

        private void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        /// <summary>   Handles the canvas moved. </summary>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>

        private void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
        }

        /// <summary>   Handles the canvas released. </summary>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>

        private void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _model.ReleasePointer(e.X, e.Y);
            UpdateExecuteButtons();
        }

        /// <summary>   Handles the canvas pressed. </summary>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>

        private void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _model.PressPointer(e.X, e.Y);
        }

        /// <summary>   Handles the ellipse button click. </summary>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>

        private void HandleEllipseButtonClick(object sender, EventArgs e)
        {
            _model.ChangeToEllipse();
        }

        /// <summary>   Updates the execute buttons. </summary>
        private void UpdateExecuteButtons()
        {
            _buttonForward.Enabled = _presentationModel.HaveNextStep;
            _buttonBackward.Enabled = _presentationModel.HavePreviousStep;
        }

        /// <summary>   Handles the button forward click. </summary>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>

        public void HandleButtonForwardClick(object sender, EventArgs e)
        {
            _presentationModel.GoForward();
            UpdateExecuteButtons();
        }

        /// <summary>   Handles the button backward click. </summary>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>

        public void HandleButtonBackwardClick(object sender, EventArgs e)
        {
            _presentationModel.GoBackward();
            UpdateExecuteButtons();
        }
    }
}
