// See https://aka.ms/new-console-template for more information
Console.WriteLine("\t ----- Bienvenido(Numeros primos)");
int n = 2;

while(n <= 100)
{
    bool esPrimo = true;
    for (int i = 2; i < n; i++)
	{
		if (n % i == 0)
		{
			esPrimo = false;
			break;
		}		
	}
	if (esPrimo) 
	{
        Console.WriteLine(n);
    }
	n++;
}

Console.WriteLine("Presione cualquier tecla para salir.");
Console.ReadKey();
