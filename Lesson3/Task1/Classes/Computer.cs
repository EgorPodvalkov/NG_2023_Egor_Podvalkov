using System;

namespace Task1.Classes;

public class Computer
{
    private int _ramSlots = 0;
    private string? _interfaceType;
    private string? _soketType;

    public List<Ram> RamsList { get; } = new List<Ram>();
    public List<Drive> DrivesList { get; } = new List<Drive>();
    public Cpu? Cpu { get; private set; }
    public Gpu? Gpu { get; private set; }
    public Motherboard? Motherboard { get; private set; }

    public Computer() { }


    public bool Add(Ram ram)
    {
        if (RamsList.Count < _ramSlots) {
            RamsList.Add(ram);
            return true;
        }

        return false;
    }

    public bool Add(Drive drive)
    {

        if (_interfaceType == null) { 
            _interfaceType = drive.InterfaceType;
            DrivesList.Add(drive);
            return true;
        }

        if (_interfaceType == drive.InterfaceType)
        {
            DrivesList.Add(drive);
            return true;
        }

        return false;
    }

    public bool Add(Cpu cpu) 
    {
        if (_soketType == null) {
            _soketType = cpu.SocketType;
            Cpu = cpu;
            return true;
        }

        if (_soketType == cpu.SocketType) { 
            Cpu = cpu;
            return true;
        }

        return false;
    }

    public bool Add(Gpu gpu)
    {
        Gpu = gpu; 
        return true;
    }

    public bool Add(Motherboard motherboard)
    {
        if (_soketType == null)
        {
            _soketType = motherboard.SocketType;
            Motherboard = motherboard;
            return true;
        }

        if (_soketType == motherboard.SocketType)
        {
            Motherboard = motherboard;
            return true;
        }

        return false;
    }


    public bool Delete(string detailList, int index)
    {
        switch (detailList.ToLower()) {
            case ("ram"):
            case ("r"):
                if (index < RamsList.Count)
                {
                    RamsList.RemoveAt(index);
                    return true;
                }

                return false;

            case ("drive"):
            case ("d"):
                if (index < DrivesList.Count)
                {
                    DrivesList.RemoveAt(index);
                    if (DrivesList.Count == 0) {
                        _interfaceType = null;
                    }
                    return true;
                }

                return false;

            default:
                return false;
        }
    }

    public bool Delete(Cpu cpu)
    {
        if (Cpu == cpu)
        {
            Cpu = null;
            if (Motherboard == null) {
                _soketType = null;
            }
            return true;
        }

        return false;
    }

    public bool Delete(Gpu gpu)
    {
        if (Gpu == gpu)
        {
            Gpu = null;
            return true;
        }

        return false;
    }

    public bool Delete(Motherboard motherboard)
    {
        if (Motherboard == motherboard) {
            Motherboard = null;
            _ramSlots = 0;
            if (Cpu == null) {
                _soketType = null;
            }
            return true;
        }

        return false;
    }
}
