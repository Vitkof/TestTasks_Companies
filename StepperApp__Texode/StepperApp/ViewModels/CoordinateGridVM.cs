using StepperApp.Infrastructure.Commands;
using StepperApp.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace StepperApp.ViewModels
{
    public class CoordinateGridVM : Notifier, ICoordinateGridVM
    {
        private readonly ICoordinateGridModel _model;
        private readonly ICommand _renderCmd;

        //ctor
        internal CoordinateGridVM(ICoordinateGridModel model)
        {
            _model = model;
            _renderCmd = new RenderCmd(this);
            Data.Width = 530;
            Data.Height = 390;
        }


        public ICommand RenderCmd => _renderCmd;
        public CoordinateGridModel Data { get; } = new CoordinateGridModel();

        #region CoordinateGrid : Grid
        public Grid CoordinateGrid
        {
            get => _model.CoordinateGrid;
            set
            {
                _model.CoordinateGrid = value;
                OnPropertyChanged("CoordinateGrid");
            }
        }
        #endregion

        
        public void Rendering(CoordinateGridModel parameter)
        {
            _model.GetCoordinateGrid(
                parameter.Width,
                parameter.Height,
                parameter.FullName);
        }
    }
}
