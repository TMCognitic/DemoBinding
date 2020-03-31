using DemoBinding.Mediator;
using DemoBinding.Mediator.Messages;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DemoBinding.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ToDoViewModel> _items;

        public ObservableCollection<ToDoViewModel> Items
        {
            get
            {
                return _items ??= LoadItems();
            }
        }

        public MainViewModel()
        {
            Messenger<DeleteToDoMessage>.Instance.Register(OnDeleteToDo);
        }

        private void OnDeleteToDo(DeleteToDoMessage message)
        {
            Items.Remove(message.ViewModel);
        }

        private ObservableCollection<ToDoViewModel> LoadItems()
        {
            Repository repos = Repository.Instance;
            return new ObservableCollection<ToDoViewModel>(repos.Get().Select(td => new ToDoViewModel(td)));
        }
    }
}
