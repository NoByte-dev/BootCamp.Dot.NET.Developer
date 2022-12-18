using DesafioPOO.Models;

Console.WriteLine("Smarthphone Nokia");
Smartphone nokia = new Nokia(numero: "123456", modelo: "Modelo 1", imei: "111", memoria: 64);
Console.WriteLine($"Número atual do Nokia {nokia.Numero}");
nokia.ReceberLigacao();
nokia.Ligar();
nokia.InstalarAplicativo("Whatsapp");

Console.WriteLine("\n");

Console.WriteLine("Smarthphone iPhone");
Smartphone iphone = new Iphone(numero: "654321", modelo: "Modelo 2", imei: "222", memoria: 32);
Console.WriteLine($"Número atual do iPhone {iphone.Numero}");
iphone.Ligar();
iphone.ReceberLigacao();
iphone.InstalarAplicativo("Telegram");