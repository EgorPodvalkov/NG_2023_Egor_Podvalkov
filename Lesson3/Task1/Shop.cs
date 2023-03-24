using System.Diagnostics;
using Task1.Abstractions;
using Task1.Classes;

namespace Task1;

public class Shop
{
    private List<Detail> _tempDetails = new List<Detail>();

    public decimal UserBudget { get; private set; }
    public Computer Bucket { get; } = new Computer();
    public List<Detail> Details { get; } = new List<Detail>()
    {
        // Motherboards in shop
        new Motherboard(4_799, "Asus", "China", "Motherboard Asus TUF Gaming B550M-Plus")
        {
            SocketType = "AM4",
            RamSlots = 4
        },
        new Motherboard(2_599, "Asus", "China", "Motherboard Asus Prime H510M-K")
        {
            SocketType = "1200",
            RamSlots = 2,
        },
        new Motherboard(26_999, "Asus", "China", "Motherboard Asus ROG Maximus Z790 Hero")
        {
            SocketType = "1700",
            RamSlots = 4
        },
        new Motherboard(8_299, "MSI", "China (Taiwan)", "Motherboard MSI Pro Z690-A Wi-Fi DDR5")
        {
            SocketType = "1700",
            RamSlots = 4
        },
        new Motherboard(2_649, "Gigabyte", "China (Taiwan)", "Motherboard Gigabyte B450M S2H")
        {
            SocketType = "AM4",
            RamSlots = 2,
        },
        new Motherboard(30_918, "MSI", "China (Taiwan)", "Motherboard MEG Z690 ACE Socket 1700")
        {
            SocketType = "1700",
            RamSlots = 4,
        },

        // CPUs in shop
        new Cpu(3_899, "AMD", "China", "CPU AMD Ryzen 5 5500 3.6GHz/16MB")
        {
            SocketType = "AM4",
            Cores = 6,
            Frequency = "3.6GHz",
        },
        new Cpu(2_699, "AMD", "China", "CPU AMD Ryzen 3 4100 3.8GHz/4MB")
        {
            SocketType = "AM4",
            Cores = 4,
            Frequency = "3.8GHz",
        },
        new Cpu(7_999, "AMD", "China", "CPU AMD Ryzen 7 5700G 3.8GHz/16MB")
        {
            SocketType = "AM4",
            Cores = 8,
            Frequency = "3.8GHz",
        },
        new Cpu(5_099, "Intel", "China", "CPU Intel Core i5-11400F 2.6GHz/12MB")
        {
            SocketType = "1200",
            Cores = 6,
            Frequency = "2.6GHz",
        },
        new Cpu(30_821, "Intel", "China", "CPU INTEL Core™ i9 12900F")
        {
            SocketType = "1700",
            Cores = 16,
            Frequency = "2.4GHz",
        },
        new Cpu(30_821, "Intel", "China", "CPU INTEL Core™ i9 12900F")
        {
            SocketType = "1700",
            Cores = 16,
            Frequency = "2.4GHz",
        },

        // GPUs in shop
        new Gpu(16_099, "Asus", "China", "GPU Asus PCI-Ex GeForce RTX 3060 Dual OC V2 LHR 12GB GDDR6")
        {
            MemorySize = "12GB",
            Frequency = "15GHz",
        },
        new Gpu(113_999, "ASUS", "China", "GPU ASUS PCI-Ex GeForce RTX 4090 ROG Strix OC Edition 24GB GDDR6X")
        {
            MemorySize = "24GB",
            Frequency = "21GHz",
        },
        new Gpu(2_089, "Gigabyte", "China", "GPU Gigabyte PCI-Ex GeForce GT 710 2048MB DDR3")
        {
            MemorySize = "2GB",
            Frequency = "1.8GHz",
        },
        new Gpu(11_309, "Gigabyte", "China", "GPU Gigabyte PCI-Ex GeForce GT 710 2048MB DDR3")
        {
            MemorySize = "2GB",
            Frequency = "1.8GHz",
        },
        new Gpu(17_409, "MSI", "China", "GPU MSI PCI-Ex GeForce RTX 3060 Gaming X 12G 12GB GDDR6")
        {
            MemorySize = "12GB",
            Frequency = "15GHz",
        },

        // RAMs in shop
        new Ram(979, "Kingston", "USA", "RAM Kingston Fury DDR4-3200 8192MB PC4-25600 Beast Black")
        {
            Type = "DDR4 SDRAM",
            Size = "8GB",
        },
        new Ram(1_714, "Kingston", "USA", "RAM Kingston Fury SODIMM DDR4-3200 16384MB PC4-25600 Impact Black")
        {
            Type = "SODIMM DDR4",
            Size = "16GB",
        },
        new Ram(1_729, "Kingston", "USA", "RAM Kingston Fury DDR4-3200 16384MB PC4-25600 Beast Black")
        {
            Type = "DDR4 SDRAM",
            Size = "16GB",
        },
        new Ram(5_291, "Kingston", "USA", "RAM Kingston Fury SODIMM DDR5-4800 32768MB PC5-38400 Impact Black")
        {
            Type = "SODIMM DDR5",
            Size = "32GB",
        },
        new Ram(888, "Goodram", "USA", "RAM Goodram DDR3-1600 8192MB PC3-12800")
        {
            Type = "DDR3 SDRAM",
            Size = "8GB",
        },

        // Drives in the shop
        new Drive(1_119, "Toshiba", "Japan", "HDD Drive Toshiba P300 500GB 7200rpm 64MB HDWD105UZSVA 3.5 SATA III")
        {
            Type = "HDD",
            Size = "500GB",
            InterfaceType = "SATAIII"
        },
        new Drive(2_529, "Western Digital", "USA", "HDD Drive Western Digital Blue 2TB 7200rpm 256MB WD20EZBX 3.5 SATA III")
        {
            Type = "HDD",
            Size = "2TB",
            InterfaceType = "SATAIII"
        },
        new Drive(18_489, "Seagate", "USA", "HDD Drive Seagate Exos X20 HDD 20TB 7200rpm 256MB ST20000NM007D 3.5\" SATA III")
        {
            Type = "HDD",
            Size = "20TB",
            InterfaceType = "SATAIII"
        },
        new Drive(1_229, "Kingston ", "USA", "SSD Drive Kingston SSDNow A400 480GB 2.5\" SATAIII 3D V-NAND")
        {
            Type = "SSD",
            Size = "480GB",
            InterfaceType = "SATAIII",
            Speed = "500MB/s",
            Lifetime = 1_000_000
        },
        new Drive(2_569, "Kingston ", "USA", "SSD Drive Kingston SSDNow A400 960GB 2.5\" SATAIII 3D V-NAND")
        {
            Type = "SSD",
            Size = "960GB",
            InterfaceType = "SATAIII",
            Speed = "500MB/s",
            Lifetime = 1_000_000
        },
        new Drive(8_999, "Kingston ", "USA", "SSD Drive Kingston FURY Renegade SSD 2TB M.2 2280 NVMe PCIe Gen 4.0 x4 3D TLC NAND")
        {
            Type = "SSD",
            Size = "2TB",
            InterfaceType = "PCI Express 4.0 x4",
            Speed = "7GB/s",
            Lifetime = 1_800_000
        },
    };

    public Shop() 
    {
        SetBudget();
    }
    
    public void SetBudget()
    {
        try {
            Console.Write("Enter budget($): ");
            UserBudget =  decimal.Parse(Console.ReadLine());
            GenerateDetailsList(UserBudget - Bucket.GetFullPrice());
        }
        catch {
            Console.Clear();
            Console.Write("Bad number :(! ");
            SetBudget();
        }
    }

    public void GenerateDetailsList(decimal max = 999_999, decimal min = 0)
    {
        _tempDetails = new List<Detail>
            (from d in Details orderby d.Price where d.Price > min && d.Price < max select d);
    }

    public void Menu(int index = 0)
    {
        // Bad index
        if(index < 0 || index >= _tempDetails.Count) {
            index = 0;
        }

        // Clear
        Console.Clear();

        // Shop Name
        Console.WriteLine("\tComputer Collector");

        int pad = 25;
        // Budget
        Console.Write("M to change budget".PadRight(pad));
        Console.WriteLine($"Your budget: {UserBudget}$");

        // Bucket
        decimal bucketPrice = Bucket.GetFullPrice();
        Console.Write("B to go to bucket".PadRight(pad));
        Console.WriteLine($"Your bucket({bucketPrice}$ in bucket, {UserBudget - bucketPrice}$ left)");

        // Search, Up\Down, Enter
        Console.WriteLine("F to search".PadRight(pad)
            + "▲/▼ to go up/down".PadRight(pad)
            + "Enter to add to bucket");

        // Price Diapason, Prev/Next Page, Quit
        Console.WriteLine("D to set diapason".PadRight(pad)
            + "◄/► to go prev/next page".PadRight(pad)
            + "Esc to quit");

        Console.WriteLine("\n" + "".PadRight(Console.WindowWidth, '_'));
        
        // Pages
        int onPage = 5;
        int page = index / onPage;
        
        if(_tempDetails.Count > 0) {
            Console.WriteLine($"Page {page + 1} from {(_tempDetails.Count - 1) / onPage + 1}\n");

            // Details
            for (int i = 0; i < onPage && i < _tempDetails.Count - (page * onPage); i++)
            {
                Detail detail = _tempDetails[(page * onPage) + i];
                if (i == index % onPage) {
                    Console.WriteLine($"> {detail.GetFullInfo(4)}\n");
                }
                else { 
                    Console.WriteLine($"{detail.GetFullInfo()}\n");
                }
            }
        }
        else {
            // No Details
            Console.WriteLine(" No hardwares :(\nTry to change budget or diapason, delete expensive hardware from bucket, or use search.");
        }

        // Checking User Response
        bool invalidResponse;
        do
        {
            invalidResponse = false;
            // Getting Key
            var key = Console.ReadKey();

            // Go Upper in Menu
            if (key.Key == ConsoleKey.UpArrow) {
                if (index == 0) {
                    invalidResponse = true;
                }
                else {
                    Menu(index - 1);
                }
            }
            // Go Downer in Menu
            else if (key.Key == ConsoleKey.DownArrow) {
                if (index == _tempDetails.Count - 1) {
                    invalidResponse = true;
                }
                else { 
                    Menu(index + 1);
                }
            }
            // Go to Next Page
            else if (key.Key == ConsoleKey.RightArrow) {
                if (page == (_tempDetails.Count - 1) / onPage) {
                    invalidResponse = true;
                }
                else if (index + onPage >= _tempDetails.Count) {
                    Menu(_tempDetails.Count - 1);
                }
                else {
                    Menu(index + onPage);
                }
            }
            // Go to Prev Page
            else if (key.Key == ConsoleKey.LeftArrow) {
                if (page == 0) {
                    invalidResponse = true;
                }
                else {
                    Menu(index - onPage);
                }
            }
            // Add to Bucket
            else if (key.Key == ConsoleKey.Enter) {
                AddToBucket(index);
                Menu(index);
            }
            // Go to Budget
            else if (key.Key == ConsoleKey.M) {
                Console.Clear();
                SetBudget();
                Menu();
            }
            // Go to Bucket
            else if (key.Key == ConsoleKey.B) {
                //go to Bucket function
            }
            // Go to Search
            else if (key.Key == ConsoleKey.F) {
                SearchMenu();
            }
            // Go to Diapason
            else if (key.Key == ConsoleKey.D) {
                SetDiapasonMenu();
                Menu();
            }
            // Escape from Shop
            else if (key.Key == ConsoleKey.Escape) {
                break;
            }
            // No Sence Response
            else {
                Console.Write("\b \b");
                invalidResponse = true;
            }
        } while (invalidResponse);
    }

    public void SetDiapasonMenu()
    {
        decimal min;
        decimal max;
        Console.Clear();

        // getting min
        do
        {
            try
            {
                Console.Write("Enter min price($): ");
                min = decimal.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.Write(" Bad number :(!\n");
            }
        } while (true);
        // getting max
        do
        {
            try {
                Console.Write("Enter max price($): ");
                max = decimal.Parse(Console.ReadLine());
                if(max > min) {
                    break;
                }
                else {
                    Console.Write(" Bad number :(!\n");
                }
            }
            catch {
                Console.Write(" Bad number :(!\n");
            }
        } while (true);
        
        GenerateDetailsList(max, min);
    }

    public void SearchMenu()
    {
        Console.Clear();
        Console.Write("Search: ");
        string str = Console.ReadLine();
        str ??= "";

        _tempDetails = new List<Detail>(from d in Details where d.Name.ToLower().Contains(str.ToLower()) orderby d.Price select d);
        Menu();
    }

    public void AddToBucket(int index)
    {
        var detail = _tempDetails[index];
        string status = "";

        // Price Error
        if (detail.Price > UserBudget - Bucket.GetFullPrice()) {
            status += "\nError:\n  Not enough money in budged. ";
            status += "Try to change budget or delete something from bucket\n";
        }
        // Success
        else if (Bucket.Add(detail)) {
            status += $"\nSuccess:\n  You added '{detail.Name}' to your bucket\n";
            GenerateDetailsList(UserBudget - Bucket.GetFullPrice());
        }
        // Adding Error
        else {
            status += "\nError:\n  " + Bucket.LastError + "\n";
        }

        // Bucket info
        string bucket = "Now in your bucket:\n";
        bucket += "".PadRight(Console.WindowWidth, '-');
        foreach (var d in Bucket.ListOfDetails())
        {
            bucket += "\n" + d.GetFullInfo() + "\n";
        }
        bucket += "".PadRight(Console.WindowWidth, '-');

        // Waiting for Key and 
        Console.Clear();
        Console.WriteLine(bucket + status);
        Console.WriteLine("Press any key");
        Console.ReadKey();
    }
}
