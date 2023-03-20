using Task1.Classes;

var comp = new Computer();
comp.Add(new Drive(100, "dad", "UK", "mega SSD")
{
    Type = "SSD",
    InterfaceType = "ddr"
});
Console.WriteLine(comp.DrivesList[0].Country + "\n" + comp.DrivesList[0].Type);