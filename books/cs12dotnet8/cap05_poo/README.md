# Capítulo 05 — Construindo Tipos com Programação Orientada a Objetos

## Estrutura de um Tipo

Um tipo em C# é composto por:

### Campos (Fields) — Armazenam Dados
Variáveis de instância que guardam o estado do objeto.

```csharp
public class Person
{
    public string Name;           // campo público
    public DateTimeOffset Born;   // campo público
    public List<Person> Children; // coleção
}
```

| Tipo | Definição | Modificação |
|------|-----------|------------|
| `const` | Em **tempo de compilação** | Apenas na declaração |
| `readonly` | Em **tempo de execução** | Na declaração ou no construtor |
| Campo normal | Pode ser alterado | A qualquer momento |

### Métodos (Methods) — Definem Comportamento
Instruções que o objeto sabe executar.

```csharp
public void WriteToConsole() { }           // sem retorno
public string GetOrigin() { }              // com retorno
public void SayHello() { }                 // sem parâmetros
public void SayHello(string name) { }      // sobrecarga
public void OptionalParameters(int x = 5) { } // parâmetro com valor padrão
```

### Membros Especiais
- **Constructor** — inicializa o objeto
- **Property** — acesso controlado a campos (`get`/`set`)
- **Indexer** — acesso via índice como em arrays
- **Operator** — sobrecarga de operadores

---

## Modificadores de Acesso

Controlam onde cada membro pode ser visto e usado.

| Modificador | Acessível por | Uso Típico |
|-------------|---------------|-----------|
| `private` | Apenas dentro do próprio tipo | Campos internos, lógica privada *(padrão)* |
| `internal` | Mesmo assembly | Tipos de suporte não públicos |
| `protected` | Tipo + subclasses | Membros herdáveis |
| `public` | Em qualquer lugar | API pública da classe |
| `internal protected` | Mesmo assembly **OU** subclasses | Raramente usado |
| `private protected` | Mesmo assembly **E** subclasses | Raramente usado (C# 7.2+) |

---

## Campos (Fields): Dados da Instância

### Declaração Básica
```csharp
public class Person
{
    public string Name;
    public DateTimeOffset Born;
    public string HomePlanet = "Earth";
}

Person bob = new();
bob.Name = "Bob Smith";
bob.Born = new DateTimeOffset(year: 1965, month: 12, day: 22, hour: 16, minute: 28, second: 0, offset: TimeSpan.Zero);
```

### Campos Constantes e Somente Leitura

**`const`** — fixo em **tempo de compilação**
```csharp
public const double PI = 3.14159;
// Não pode ser alterado em nenhuma situação
```

**`readonly`** — fixo em **tempo de execução**
```csharp
public readonly DateTime CreatedAt = DateTime.Now;
// Pode ser definido na declaração ou no construtor
```

---

## Coleções e Agregação

Use `List<T>` para armazenar múltiplos objetos dentro de uma classe.

```csharp
public class Person
{
    public string Name;
    public List<Person> Children = new();
}

Person bob = new() { Name = "Bob Smith" };
bob.Children.Add(new Person { Name = "Bella" });
bob.Children.Add(new Person { Name = "Zoe" });

WriteLine($"{bob.Name} has {bob.Children.Count} children:");
foreach (var child in bob.Children)
{
    WriteLine($"> {child.Name}");
}
```

---

## Membros Estáticos (Static)

Compartilhados entre **todas as instâncias** da classe. Pertencem ao **tipo**, não ao objeto.

```csharp
public class BankAccount
{
    public string AccountName;
    public decimal Balance;
    public static decimal InterestRate = 0.012M; // pertence à classe
}

// Acesso direto pelo nome da classe
BankAccount.InterestRate = 0.012M;

BankAccount jonesAccount = new() 
{ 
    AccountName = "Mrs. Jones", 
    Balance = 2400 
};

BankAccount gerrierAccount = new() 
{ 
    AccountName = "Ms. Gerrier", 
    Balance = 98 
};

// Ambas as contas usam o mesmo InterestRate
WriteLine($"{jonesAccount.AccountName} earned {jonesAccount.Balance * BankAccount.InterestRate:C} interest");
WriteLine($"{gerrierAccount.AccountName} earned {gerrierAccount.Balance * BankAccount.InterestRate:C} interest");
```

---

## Enums e Flags

Defina um conjunto limitado de opções. Use `[Flags]` para combinar múltiplas opções com `|` (OR binário).

### Enum Simples
```csharp
public enum WondersOfTheAncientWorld
{
    GreatPyramidOfGiza,
    HangingGardensOfBabylon,
    TempleOfArtemis,
    StatueOfZeus,
    MausoleumAtHalicarnassus,
    ColossusOfRhodes,
    LighthouseOfAlexandria
}
```

### Enum com [Flags] — Combinável
```csharp
[Flags]
public enum WondersOfTheAncientWorld
{
    GreatPyramidOfGiza = 1,
    HangingGardensOfBabylon = 2,
    TempleOfArtemis = 4,
    StatueOfZeus = 8,
    MausoleumAtHalicarnassus = 16,
    ColossusOfRhodes = 32,
    LighthouseOfAlexandria = 64
}

public class Person
{
    public WondersOfTheAncientWorld BucketList;
}

Person bob = new();
bob.BucketList = WondersOfTheAncientWorld.MausoleumAtHalicarnassus 
    | WondersOfTheAncientWorld.HangingGardensOfBabylon;

WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
// Output: bob's bucket list is HangingGardensOfBabylon, MausoleumAtHalicarnassus
```

---

## Construtores

Métodos especiais que inicializam o objeto.

### Construtor Padrão (sem parâmetros)
```csharp
Person blankPerson = new();
// Inicializa com valores padrão

WriteLine(
    format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    arg0: blankPerson.Name,
    arg1: blankPerson.HomePlanet,
    arg2: blankPerson.Instantiated
);
```

### Construtor com Parâmetros
```csharp
public class Person
{
    public string Name;
    public string HomePlanet;
    public DateTime Instantiated;
    
    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }
}

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");

WriteLine(
    format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    arg0: gunny.Name,
    arg1: gunny.HomePlanet,
    arg2: gunny.Instantiated
);
```

---

## Instanciação de Objetos

### C# Tradicional (todas as versões)
```csharp
Person alfred = new Person();
```

### C# 3+ — Object Initializer
```csharp
bob.Children.Add(new Person { Name = "Bella" });
```

### C# 9+ — Target-typed `new()`
Simplificado — o compilador deduz o tipo automaticamente.

```csharp
bob.Children.Add(new() { Name = "Zoe" });
```

---

## Campos Requeridos (C# 11+)

O modificador `required` força a definição de campos na instanciação.

```csharp
public class Book
{
    public required string Isbn;  // obrigatório
    public required string Title; // obrigatório
    public string Author;         // opcional
    public int PageCount;         // opcional
}

// Compilador exige que Isbn e Title sejam definidos
Book book = new(isbn: "987-1803237800", title: "C#12 and .NET8")
{
    Author = "Mark J Price",
    PageCount = 821
};

WriteLine($"{book.Isbn}: {book.Title} written by {book.Author} has {book.PageCount:N0} pages");
```

---

## Métodos e Sobrecarga (Overloading)

### Método Simples
```csharp
public void WriteToConsole()
{
    WriteLine($"{Name} was born {Born}");
}

bob.WriteToConsole();
```

### Sobrecarga — Mesmo Nome, Assinatura Diferente
```csharp
public string SayHello()
{
    return $"Hello, I am {Name}";
}

public string SayHello(string name)
{
    return $"{name}, this is {Name}. Hello!";
}

WriteLine(bob.SayHello());          // versão sem parâmetro
WriteLine(bob.SayHello("Emily"));   // versão com parâmetro
```

### Métodos Estáticos
```csharp
public static string GetSpecies()
{
    return "Homo sapiens";
}

WriteLine($"{bob.Name} is a {Person.GetSpecies()}");
```

---

## Parâmetros de Métodos

### Parâmetros Opcionais (Valores Padrão)
```csharp
public void OptionalParameters(int x = 5, int y = 10)
{
    WriteLine($"x={x}, y={y}");
}

bob.OptionalParameters(3);        // usa y=10
bob.OptionalParameters(3, 20);    // usa ambos
```

### Modificador `ref` — Entrada e Saída
Passa a **referência** da variável. Alterações afetam o original. Precisa ser inicializado antes.

```csharp
public void IncrementRef(ref int value)
{
    value++;
}

int c = 30;
bob.PassingParameters(ref c);
// c agora é 31
```

### Modificador `out` — Saída
O método **deve** atribuir um valor. Não precisa estar inicializado. Alterações afetam o original.

```csharp
public void GetOutput(out int result)
{
    result = 42; // obrigatório definir
}

int d;
bob.PassingParameters(out d);
// d agora é 42
```

### Exemplo Completo
```csharp
int a = 10;    // valor simples (cópia)
int b = 20;    // valor simples (cópia)
int c = 30;    // ref: entrada e saída
int d = 40;    // out: saída apenas

WriteLine($"Before: a={a}, b={b}, c={c}, d={d}");
bob.PassingParameters(a, b, ref c, out d);
WriteLine($"After:  a={a}, b={b}, c={c}, d={d}");
// a e b NÃO mudam (por valor)
// c mudou (foi passado por ref)
// d foi redefinido (foi passado por out)
```

| Modificador | Comportamento | Inicialização |
|-------------|---------------|---------------|
| *(nenhum)* | Cópia do valor — alterações não afetam o original | Obrigatória |
| `ref` | Referência — alterações afetam o original | Obrigatória |
| `out` | Saída — o método deve atribuir | Ignorada (redefinida) |

---

## Resumo Estrutural

```
Tipo (Class)
├── Campos (Fields)
│   ├── const — compilação
│   ├── readonly — execução
│   └── Normal
├── Construtores (Constructors)
├── Propriedades (Properties)
├── Métodos (Methods)
│   ├── Sobrecarga (Overloading)
│   └── Estáticos (Static)
├── Enums [com ou sem Flags]
└── Modificadores de Acesso (public, private, protected, internal)
```
