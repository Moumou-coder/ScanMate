global using ScanMate.View;
global using ScanMate.ViewModel;
global using ScanMate.Model;
global using ScanMate.Services;

global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

global using System;
global using System.Text.Json;
global using System.Collections.ObjectModel;
global using System.IO.Ports;
global using System.Management;
global using System.Collections;
global using System.Data;
global using System.Collections.Generic;
global using System.Data.OleDb;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.Xml.Linq;
global using System.Xml;
global using System.Collections.Specialized;

internal class Globals
{
    public static List<Skins> StaticListSkins = new List<Skins>();
    public static List<Champions> StaticListChampions = new List<Champions>();
    public static DataSet UserSet = new();
}
