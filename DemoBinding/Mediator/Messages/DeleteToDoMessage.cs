using DemoBinding.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoBinding.Mediator.Messages
{
    public class DeleteToDoMessage
    {
        public ToDoViewModel ViewModel { get; private set; }

        public DeleteToDoMessage(ToDoViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }
    }
}
