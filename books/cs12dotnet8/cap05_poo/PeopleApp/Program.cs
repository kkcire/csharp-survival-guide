using Packt.Shared;

ConfigureConsole();

Person bob = new();

bob.Name = "Bob Smith";
bob.Born = new DateTimeOffset
(
    year: 1965, month: 12, day: 22,
    hour: 16, minute: 28, second: 0,
    offset: TimeSpan.Zero
);

bob.BucketList = WondersOfTheAncientWorld.MausoleumAtHalicarnassus
    | WondersOfTheAncientWorld.HangingGardensOfBabylon;

WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");


WriteLine();
// =====================================================================

// Todas versões de C#
Person alfred = new Person();
alfred.Name = "Alfred";
bob.Children.Add(alfred);

// Funciona de C# 3 para frente
bob.Children.Add(new Person { Name = "Bella" });

// Funciona de C# 9 para frente
bob.Children.Add(new() { Name = "Zoe" });

WriteLine($"{bob.Name} has {bob.Children.Count} children:");
foreach (var child in bob.Children)
{
    WriteLine($"> {child.Name}");
}


WriteLine();
// =====================================================================

BankAccount.InterestRate = 0.012M;

BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;

WriteLine(
    format: "{0} earned {1:C} interest",
    arg0: jonesAccount.AccountName,
    arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;

WriteLine(
    format: "{0} earned {1:C} interest",
    arg0: gerrierAccount.AccountName,
    arg1: gerrierAccount.Balance * BankAccount.InterestRate);

WriteLine();
// =====================================================================

WriteLine($"{bob.Name} is a {Person.Species}");
WriteLine($"{bob.Name} was born {bob.HomePlanet}");

WriteLine();
// =====================================================================

/*
Book book = new()
{
    Isbn = "978-1828374740",
    Title = "C# 12 and .NET 8 - Modern Cross-Platform Development"
};
*/

Book book = new(isbn: "987-1803237800",
    title: "C#12 and .NET8 - Modern Cross-Platform Development")
{
    Author = "Mark J Price",
    PageCount = 821
};

WriteLine($"{book.Isbn}: {book.Title} written by {book.Author} has {book.PageCount:N0} pages");

WriteLine();
// =====================================================================

Person blankPerson = new();

WriteLine(
    format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    arg0: blankPerson.Name,
    arg1: blankPerson.HomePlanet,
    arg2: blankPerson.Instantiated
);

WriteLine();
// =====================================================================

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");

WriteLine(
    format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    arg0: gunny.Name,
    arg1: gunny.HomePlanet,
    arg2: gunny.Instantiated
);

WriteLine();
// =====================================================================

bob.WriteToConsole();
WriteLine(bob.GetOrigin());

WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Emily"));

WriteLine(bob.OptionalParameters(3));

WriteLine();
// =====================================================================

int a = 10;
int b = 20;
int c = 30;
int d = 40;

WriteLine($"Before: a={a}, b={b}, c={c}, d={d}");
bob.PassingParameters(a, b, ref c, out d);
WriteLine($"After: a={a}, b={b}, c={c}, d={d}");