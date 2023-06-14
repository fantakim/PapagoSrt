using System.ComponentModel;

namespace PapagoSrt
{
    public class Task : INotifyPropertyChanged
    {
        public string Filename { get; private set; }
        public TaskStatus Status { get; private set; }

        public Task(string filename)
        {
            Filename = filename;
            Status = TaskStatus.Pending;
        }

        public void SetStatus(TaskStatus status)
        {
            Status = status;
            OnPropertyChanged(nameof(Status));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum TaskStatus
    {
        Pending,
        Success,
        Failure
    }
}
