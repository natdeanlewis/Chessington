using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using Chessington.GameEngine;
using Chessington.UI.Caliburn.Micro;
using Chessington.UI.Factories;
using Chessington.UI.Notifications;
using Chessington.UI.Properties;

namespace Chessington.UI.ViewModels
{
    public class SquareViewModel : INotifyPropertyChanged,
        IHandle<PiecesMoved>,
        IHandle<PieceSelected>,
        IHandle<ValidMovesUpdated>,
        IHandle<SelectionCleared>
    {
        private BitmapImage image;

        private bool selected;
        private bool validMovementTarget;

        public SquareViewModel(Square square)
        {
            this.Location = square;
            ChessingtonServices.EventAggregator.Subscribe(this);
        }

        public Square Location { get; }

        public SquareViewModel Self => this;

        public bool Selected
        {
            get => selected;
            set
            {
                if (value.Equals(selected)) return;
                selected = value;
                OnPropertyChanged();
                OnPropertyChanged("Self");
            }
        }

        public bool ValidMovementTarget
        {
            get => validMovementTarget;
            set
            {
                if (value.Equals(validMovementTarget)) return;
                validMovementTarget = value;
                OnPropertyChanged();
                OnPropertyChanged("Self");
            }
        }

        public BitmapImage Image
        {
            get => image;
            set
            {
                if (Equals(value, image)) return;
                image = value;
                OnPropertyChanged();
                OnPropertyChanged("Self");
            }
        }

        public void Handle(PieceSelected notification)
        {
            Selected = notification.Square.Equals(Location);
        }

        public void Handle(PiecesMoved notification)
        {
            var currentPiece = notification.Board.GetPiece(Location);

            if (currentPiece == null)
            {
                Image = null;
                return;
            }

            Image = PieceImageFactory.GetImage(currentPiece);
        }

        public void Handle(SelectionCleared message)
        {
            Selected = false;
            ValidMovementTarget = false;
        }

        public void Handle(ValidMovesUpdated message)
        {
            ValidMovementTarget = message.Moves.Contains(Location);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}