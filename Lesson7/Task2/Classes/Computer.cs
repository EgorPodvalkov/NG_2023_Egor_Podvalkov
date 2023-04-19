using Task1.Abstractions;

namespace Task1.Classes;

public class Computer
{
    private int _ramSlots = 0;
    private string? _interfaceType;
    private string? _soketType;

    public Motherboard? Motherboard { get; private set; }
    public Cpu? Cpu { get; private set; }
    public Gpu? Gpu { get; private set; }
    public List<Ram> RamsList { get; } = new List<Ram>();
    public List<Drive> DrivesList { get; } = new List<Drive>();

    public string LastError { get; private set; } = "";

    public Computer() { }

    public bool Add(Detail detail)
    {
        if (detail is Ram)
        {
            return Add(detail as Ram);
        }
        else if (detail is Drive)
        {
            return Add(detail as Drive);
        }
        else if (detail is Cpu)
        {
            return Add(detail as Cpu);
        }
        else if (detail is Gpu)
        {
            return Add(detail as Gpu);
        }
        else if (detail is Motherboard)
        {
            return Add(detail as Motherboard);
        }

        LastError = $"We can`t add to busket {detail.GetType()} class :(";
        return false;
    }

    public bool Add(Ram ram)
    {
        if (RamsList.Count < _ramSlots)
        {
            RamsList.Add(ram);
            return true;
        }

        LastError = $"No empty RAM slots in Motherboard. " +
            $"Change or add Motherboard to busket, or delete other RAM from busket";
        return false;
    }

    public bool Add(Drive drive)
    {
        if (_interfaceType == null)
        {
            _interfaceType = drive.InterfaceType;
            DrivesList.Add(drive);
            return true;
        }

        if (_interfaceType == drive.InterfaceType)
        {
            DrivesList.Add(drive);
            return true;
        }

        LastError = $"Interface in this Drive doesn`t match with Interface in your Drives. " +
            $"Select other one or delete Drives in your busket";
        return false;
    }

    public bool Add(Cpu? cpu)
    {
        if (_soketType == null)
        {
            _soketType = cpu.SocketType;
            Cpu = cpu;
            return true;
        }

        if (_soketType == cpu.SocketType)
        {
            Cpu = cpu;
            return true;
        }

        LastError = $"Soket Type in this CPU doesn`t match with your Motherboard`s one " +
            $"({_soketType}). Select other CPU or change Motherboard";
        return false;
    }

    public bool Add(Gpu? gpu)
    {
        Gpu = gpu;
        return true;
    }

    public bool Add(Motherboard? motherboard)
    {
        if (_soketType == null)
        {
            _soketType = motherboard.SocketType;
            _ramSlots = motherboard.RamSlots;
            Motherboard = motherboard;
            return true;
        }

        if (_soketType == motherboard.SocketType)
        {
            _ramSlots = motherboard.RamSlots;
            Motherboard = motherboard;
            return true;
        }

        LastError = $"Soket Type in this Motherboard doesn`t match with your CPU`s one " +
    $"({_soketType}). Select other Motherboard or change CPU";
        return false;
    }

    public bool Delete(Detail detail)
    {
        if (detail is Ram)
        {
            return Delete(detail as Ram);
        }
        else if (detail is Drive)
        {
            return Delete(detail as Drive);
        }
        else if (detail is Cpu)
        {
            return Delete(detail as Cpu);
        }
        else if (detail is Gpu)
        {
            return Delete(detail as Gpu);
        }
        else if (detail is Motherboard)
        {
            return Delete(detail as Motherboard);
        }

        LastError = $"We can`t delete from busket {detail.GetType()} class :(";
        return false;
    }

    public bool Delete(Ram ram)
    {
        if (RamsList.Remove(ram))
            return true;
        else
        {
            LastError = $"'{ram.Name}' isn`t in your PC";
            return false;
        }
    }

    public bool Delete(Drive drive)
    {
        if (DrivesList.Remove(drive))
            return true;
        else
        {
            LastError = $"'{drive.Name}' isn`t in your PC";
            return false;
        }
    }

    public bool Delete(Cpu cpu)
    {
        if (Cpu == cpu)
        {
            Cpu = null;
            if (Motherboard == null)
            {
                _soketType = null;
            }
            return true;
        }

        LastError = $"'{cpu.Name}' isn`t in your PC";
        return false;
    }

    public bool Delete(Gpu gpu)
    {
        if (Gpu == gpu)
        {
            Gpu = null;
            return true;
        }

        LastError = $"'{gpu.Name}' isn`t in your PC";
        return false;
    }

    public bool Delete(Motherboard motherboard)
    {
        if (Motherboard == motherboard)
        {
            Motherboard = null;
            _ramSlots = 0;
            if (Cpu == null)
            {
                _soketType = null;
            }
            return true;
        }
        LastError = $"'{motherboard.Name}' isn`t in your PC";
        return false;
    }

    public decimal GetFullPrice()
    {
        decimal sum = 0;

        // Motherboard
        if (Motherboard != null)
        {
            sum += Motherboard.Price;
        }

        // CPU
        if (Cpu != null)
        {
            sum += Cpu.Price;
        }

        // GPU
        if (Gpu != null)
        {
            sum += Gpu.Price;
        }

        // RAMs
        foreach (var ram in RamsList)
        {
            sum += ram.Price;
        }

        // Drives
        foreach (var drive in DrivesList)
        {
            sum += drive.Price;
        }
        return sum;
    }

    public List<Detail> ListOfDetails()
    {
        var list = new List<Detail>();

        // Motherboard
        if (Motherboard != null)
        {
            list.Add(Motherboard);
        }

        // CPU
        if (Cpu != null)
        {
            list.Add(Cpu);
        }

        // GPU
        if (Gpu != null)
        {
            list.Add(Gpu);
        }

        // RAM
        foreach (var ram in RamsList)
        {
            list.Add(ram);
        }

        // Drive
        foreach (var drive in DrivesList)
        {
            list.Add(drive);
        }

        return list;
    }

    public bool CheckConfiguration()
    {
        var error = "";

        // Motherboard Missing
        if (Motherboard == null)
            error += "Motherboard, ";

        // CPU Missing
        if (Cpu == null)
            error += "CPU, ";

        // GPU Missing
        if (Gpu == null)
            error += "GPU, ";

        // RAM Missing
        if (RamsList.Count == 0)
            error += "at list one RAM, ";

        // Drives Missing
        if (DrivesList.Count == 0)
            error += "at list one Drive, ";

        if (error != "")
        {
            LastError = "Your PC won`t work, because you forgot about: " + error[..^2] + '.';
            return false;
        }

        error = "";

        // RAM slots error
        if (Motherboard.RamSlots < RamsList.Count)
        {
            error += $"\n   Your Motherboard has only {Motherboard.RamSlots} slots," +
                $" you can`t plague {RamsList.Count} RAMs in it.";
        }

        // Soket Type error
        if (Motherboard.SocketType != Cpu.SocketType)
        {
            error += $"\n   Your Motherboard has {Motherboard.SocketType} Soket Type," +
                $" but Cpu has {Cpu.SocketType} Soket Type.";
        }

        // Intrface Type error
        var interfaceTypes = new List<string>((from drive in DrivesList select drive.InterfaceType).Distinct());
        if (interfaceTypes.Count > 1)
        {
            error += $"\n   Your Drives have different Interface Types:";
            foreach (var interfaceType in interfaceTypes)
            {
                error += $"\n      {interfaceType}";
            }
        }

        if (error != "")
        {
            LastError = "Your PC won`t work. You have some errors:" + error;
            return false;
        }

        return true;
    }
}
