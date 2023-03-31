global using ScanMate.View;
global using ScanMate.ViewModel;
global using ScanMate.Model;
global using ScanMate.Services;

global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

global using System.Text.Json;
global using System.Collections.ObjectModel;
global using System.IO.Ports;
global using System.Management;

internal class Globals
{
    public static List<Skins> StaticListSkins = new List<Skins>();
    public static Queue<string> SerialBuffer = new Queue<string>();
}
