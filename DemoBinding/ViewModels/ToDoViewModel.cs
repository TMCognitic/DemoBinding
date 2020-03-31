using DemoBinding.Commands;
using DemoBinding.Mediator;
using DemoBinding.Mediator.Messages;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DemoBinding.ViewModels
{
    public class ToDoViewModel : ViewModelBase
    {
        private ToDo _entity;
        private string _title;
        private ICommand _deleteCommand;
        private ICommand _updateCommand;

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged(nameof(Title));
                }
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??= new RelayCommand(Delete);
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand ??= new RelayCommand(Update, CanUpdate);
            }
        }

        private bool CanUpdate()
        {
            return Title != _entity.Title;
        }

        private void Update()
        {
            //connect to Api
            //si Ok ...
            _entity.Title = Title;
            //Si Ko
            //Affiche Message
            //Title = _entity.Title;
        }

        private void Delete()
        {
            Repository repos = Repository.Instance;
            repos.Delete(_entity.Id);
            Messenger<DeleteToDoMessage>.Instance.Send(new DeleteToDoMessage(this));
        }

        public ToDoViewModel(ToDo entity)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            Title = entity.Title;            
        }
    }
}
