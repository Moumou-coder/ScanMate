namespace ScanMate.Services;

public partial class BarCodeService
{
    public BarCodeService() { }

    public partial void ConfigureScanner();

    public QueueBuffer SerialBuffer;

    public class QueueBuffer : Queue
    {
        public event EventHandler Changed;

        protected virtual void OnChanged()
        {
            if (Changed != null) Changed(this, EventArgs.Empty);
        }

        public override void Enqueue(object item)
        {
            base.Enqueue(item);
            OnChanged();
        }
    }
}



