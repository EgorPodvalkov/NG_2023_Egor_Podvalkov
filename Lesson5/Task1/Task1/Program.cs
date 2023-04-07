using Task1;


var app = new App("D:\\NewGen\\NG_2023_Egor_Podvalkov\\Lesson5\\Фото");
var current = new FileInfo("D:\\NewGen\\NG_2023_Egor_Podvalkov\\Lesson5\\Фото\\Армин.png");

/*Console.WriteLine(current.Length);
Console.WriteLine(current.CreationTime.ToString("dd.MM.yy, HH:mm"));
Console.WriteLine(current.Name);*/

app.ShowFolder();
