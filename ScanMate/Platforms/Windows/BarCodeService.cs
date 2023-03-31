namespace ScanMate.Services;

public partial class BarCodeService
{
    public SerialPort mySerialPort;

    public partial void ConfigureScanner()
    {
        this.SerialBuffer = new();
        this.mySerialPort = new();

        string ComPort = "";

        using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'"))
        {
            var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());

            var portList = SerialPort.GetPortNames().Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();

            foreach (string s in portList)
            {
                if (s.Contains("GMAS"))
                {
                    string[] data = s.Split(" - ");
                    ComPort = data[0];
                }
            }
        }
        if (ComPort == "")
        {
            ComPort = "COM5";
        }

        mySerialPort.PortName = ComPort;
        mySerialPort.BaudRate = 9600;
        mySerialPort.Parity = Parity.None;
        mySerialPort.DataBits = 8;
        mySerialPort.StopBits = StopBits.One;

        mySerialPort.ReadTimeout = 1000;
        mySerialPort.WriteTimeout = 1000;

        mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataHandler);

        try
        {
            mySerialPort.Open();
        }
        catch (Exception ex)
        {
            Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
    }

    private void DataHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string data = "";

        data = sp.ReadTo("\r");

        SerialBuffer.Enqueue(data);
    }
}


