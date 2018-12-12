// file:	MainPage.xaml.cs
//
// summary:	Implements the main page.xaml class

using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DrawingApp
{
    /// <summary>   An empty page that can be used on its own or navigated to within a Frame. </summary>
    ///
    /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

    public sealed partial class MainPage : Page
    {
        /// <summary>   The model. </summary>
        DrawingModel.Model _model;
        /// <summary>   The presentation model. </summary>
        PresentationModel.PresentationModel _presentationModel;

        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _clear.Click += HandleClearButtonClick;
            _line.Click += HandleLineButtonClick;
            _diamond.Click += HandleDiamondButtonClick;
            _model._modelChanged += HandleModelChanged;
        }

        /// <summary>   Handles the diamond button click. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Routed event information. </param>

        private void HandleDiamondButtonClick(object sender, RoutedEventArgs e)
        {
            _model.ChangeToDiamond();
        }

        /// <summary>   Handles the line button click. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Routed event information. </param>

        private void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            _model.ChangeToLine();
        }

        /// <summary>   Handles the model changed. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>

        private void HandleModelChanged()
        {
            _presentationModel.Draw();
        }

        /// <summary>   Handles the clear button click. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Routed event information. </param>

        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
        }

        /// <summary>   Handles the canvas moved. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Pointer routed event information. </param>

        private void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        /// <summary>   Handles the canvas released. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Pointer routed event information. </param>

        private void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        /// <summary>   Handles the canvas pressed. </summary>
        ///
        /// <remarks>   Chen-Tai,Peng, 12/12/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Pointer routed event information. </param>

        private void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }
    }
}
