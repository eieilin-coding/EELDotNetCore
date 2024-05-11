Console.WriteLine("Hello, World!");
string jsonstr = await File.ReadAllTextAsync("PickAPile.json");
Console.WriteLine(jsonstr);
Console.ReadLine();


