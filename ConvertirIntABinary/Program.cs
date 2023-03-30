// See https://aka.ms/new-console-template for more information

Console.WriteLine("\t----- Bienvenido (Convertir Entero a Binario) -----");
Console.Write("Ingrese el numero entero a convertir: ");
int num = int.Parse(Console.ReadLine());
string binary = string.Empty;
int temp = 0;

while (num > 0)
{
    temp = num % 2;
    num /= 2;
    binary = temp.ToString() + binary;
}

Console.WriteLine("El numero en binario es: " + binary);
Console.WriteLine("Presione cualquier tecla para salir.");
Console.ReadKey();


