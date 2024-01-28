/* Hardware Warehouse Management System API */
namespace API;

public delegate void QueueEventHandler<T, U>(T sender, U eventArgs);

public class CustomQueue<T> where T : IEntityPrimaryProperties, IEntityAdditionalProperties
{
    // The custom queue generic class is bounded to IEntityPrimaryProperties and IEntityAdditionalProperties which means that items have the interface property
    private Queue<T>? _queue = null;

    public event QueueEventHandler<CustomQueue<T>, QueueEventArgs> CustomQueueEvent;

    public CustomQueue()
    {
        _queue = new Queue<T>();
    }

    public int QueueLength
    {
        get { return _queue.Count; }
    }

    public void AddItem(T item)
    {
        _queue.Enqueue(item);
        QueueEventArgs queueEventArgs = new QueueEventArgs
        {
            Message =
                $"Date time: {DateTime.Now.ToString(Constants.DateTimeFormat)}," +
                $" Id: {item.Id}," +
                $" Name: {item.Name}," +
                $" Type: {item.Type}, " +
                $"Quantity {item.Quantity}," +
                $" Unit value: {item.UnitValue}" +
                "has been added to the queue"
        };
        
        OnQueueChanged(queueEventArgs);
    }


    public T GetItem()
    {
        T item = _queue.Dequeue();
        QueueEventArgs queueEventArgs = new QueueEventArgs
        {
            Message =
                $"Date time: {DateTime.Now.ToString(Constants.DateTimeFormat)}," +
                $" Id: {item.Id}," +
                $" Name: {item.Name}," +
                $" Type: {item.Type}, " +
                $"Quantity {item.Quantity}," +
                $" Unit value: {item.UnitValue}" + 
                "has been processed (placed in its designated location and no longer in the queue)"
        };
        
        OnQueueChanged(queueEventArgs);
        return item;
    }

    protected virtual void OnQueueChanged(QueueEventArgs eventArgs)
    {
        CustomQueueEvent(this, eventArgs);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _queue.GetEnumerator();
    }
}

public class QueueEventArgs : EventArgs
{
    public string Message { get; set; }
}