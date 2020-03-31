using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Repository
    {
        private static Repository _instance;

        public static Repository Instance
        {
            get
            {
                return _instance ??= new Repository();
            }
        }

        private Dictionary<int, ToDo> _items;        

        private Repository()
        {
            _items = new Dictionary<int, ToDo>();
            foreach (ToDo td in Load())
            {
                _items.Add(td.Id, td);
            }
        }

        private IEnumerable<ToDo> Load()
        {
            yield return new ToDo() { Id = 1, Title = "Create MainViewModel" };
            yield return new ToDo() { Id = 2, Title = "Instance MainViewModel in App.xaml" };
            yield return new ToDo() { Id = 3, Title = "Declare DataContext" };
            yield return new ToDo() { Id = 4, Title = "Declare ItemsSource" };
            yield return new ToDo() { Id = 5, Title = "Set Columns" };
        }

        public IEnumerable<ToDo> Get()
        {
            return _items.Values;
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }
    }
}
