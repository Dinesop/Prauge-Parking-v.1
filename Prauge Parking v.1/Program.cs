string[] parkingGarage = new string[100];



menyVal(menyDisplay());

void menyVal(int valdMenyPunkt)
{
    switch (valdMenyPunkt)
    {
        case 1:
            Console.WriteLine("Lägg till fordon");
            break;

        case 2:
            Console.WriteLine("Flytta fordon");
            break;

        case 3:
            Console.WriteLine("Hämta ut fordon");
            break;

        case 4:
            Console.WriteLine("Sök efter fordon");
            break;
    }
}

int menyDisplay()
{
    /// Menyn bygger på att vilkors operatorn ? : -> b ? x : y innebär att om b är sant händer x annars händer y. 
    /// Om jag trycker på nedåt tangent och valdMenyPunkt är mindre än 3, kör vi valdMenyPunkt + 1 vilket flyttar pilmarkären nedåt 
    /// eftersom att vi ovan states that om vald menypunkt är == 1, 2 eller 3 så har de en pil framför sig.
    int valdMenyPunkt = 1;

    while (true)
    {
        Console.Clear();
        Console.WriteLine("Använd piltangenterna (Upp/Ned) och tryck sedan på Enter:\n\n");
        Console.WriteLine(valdMenyPunkt == 1 ? "> Lägg till fordon" : "  Lägg till fordon");
        Console.WriteLine(valdMenyPunkt == 2 ? "> Flytta fordon" : "  Flytta fordon");
        Console.WriteLine(valdMenyPunkt == 3 ? "> Hämta fordon" : "  Hämta fordon");
        Console.WriteLine(valdMenyPunkt == 4 ? "> Sök efter fordon" : "  Sök efter fordon");

        var knapp = Console.ReadKey(false);
        if (knapp.Key == ConsoleKey.DownArrow && valdMenyPunkt < 4) valdMenyPunkt++;


        else if (knapp.Key == ConsoleKey.UpArrow && valdMenyPunkt > 1) valdMenyPunkt--;
        else if (knapp.Key == ConsoleKey.Enter) break;
    }

    return (valdMenyPunkt);

}

void läggaTillFordon()
{
    Console.WriteLine("Ange fordonstyp följt av registrering nummret på formen BIL#ABC123 alt. MC#ABC123:");
    string input = Console.ReadLine(); // Här hade jag velat ha någon form av spärr för om man inte matar in ett korrekt format.

    string[] fordon = input.Split('#');

    if (fordon[0] == "BIL")
    {
        // Bil stuff
    }
    else if (fordon[0] == "MC")
    {
        // Mc stuff
    }
    else
        Console.WriteLine("Ogiltligt fordon.");
}

