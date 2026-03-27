# Capítulo 2 — Tipos de Dados

## Tipos de Variáveis

```csharp
// Tipos unsigned representam apenas valores positivos ou zero

byte num = 12;       // 8 bits; 0 - 255 (bom para idades)
ushort s = 1;        // 16 bits; 0 - 65.535
uint i = 1;          // 32 bits; 0 - 4.294.967.295
ulong l = 1;         // 64 bits; 0 - 18.446.744.073.709.551.615

// Tipos signed (padrão) representam positivos e negativos

short integer = 1;   // 16 bits
int integer = 12;    // 32 bits
long integer = 12L;  // 64 bits; sufixo L

// Tipos de tamanho nativo (C# 9+) — tamanho depende se o processo é 32 ou 64 bits
nint nativeInt = 1;
nuint nativeUInt = 1;

--------------------------------------------------------------------

float floater = 12.25f;    // 32 bits; precisa do sufixo f
double doubler = 0.4;      // 64 bits; mais preciso que float; padrão para reais
decimal price = 2830.90m;  // 128 bits; precisa do sufixo m; alta precisão

--------------------------------------------------------------------

char caracter = 'K';         // aspas simples; 16 bits - UTF-16
string fruit = "Maçã";       // aspas duplas

--------------------------------------------------------------------

bool estudante = true; // 8 bits (True/False)

// var: fixa o tipo após a primeira atribuição; ocorre em tempo de compilação — não afeta desempenho
// Regra de ouro: use var apenas quando o tipo for óbvio para quem lê
var name = "Estudante";         // óbvio — ok
var xml = new XmlDocument();    // óbvio — ok

object name = "Erick Magagna";  // memória heap; raiz de todos os tipos no .NET
dynamic algo;                   // tipo dinâmico e flexível; custo de performance
```

### Boxing e Unboxing

```csharp
// Boxing: um tipo de valor (stack) é enviado para a heap
object int_heap = 10;

// Unboxing: retira o valor da heap de volta para a stack
// Só funciona com tipos que originalmente eram da stack (int, float, double, etc.)
int num_stack = (int)int_heap;
```

### Casting

```csharp
// Para acessar um valor da heap, deve-se informar o tipo contido na variável
string name2 = (string)name;
```

### Convenções de Nomenclatura

| Convenção | Uso | Exemplo |
|---|---|---|
| camelCase | Variáveis locais e parâmetros | `firstName`, `applesCount` |
| PascalCase | Tipos, métodos e propriedades | `WriteLine`, `DateTime` |

---

## Strings

```csharp
// Constructor que gera uma linha de traços
string horizontalLine = new('-', count: 74);
```

```csharp
// @ (Verbatim): ignora caracteres de escape
string filePath = @"C:\Users\kcire\projects\coding>";
```

```csharp
// $ (Interpolação): ativa interpolação com variáveis e expressões entre chaves
// $$ = usa {{}} para chaves literais
Console.WriteLine($"{name}");
```

```csharp
// """ (Raw String Literals): armazena múltiplas linhas sem escape
string xml = """
             <person age="50">
               <first_name>Mark</first_name>
             </person>
             """;
```

```csharp
// dynamic: pode armazenar qualquer tipo; último valor atribuído prevalece
dynamic algo;
algo = new[] { 3, 5, 7 };
algo = 12;
algo = "Erick";
Console.WriteLine(algo); // Erick
```

```csharp
// ?: Nullable Reference Type (NRT) — indica que o valor pode ser nulo; evita Warning
string? name = Console.ReadLine();

// !: Null-forgiving operator — garante ao compilador que o valor não será nulo
string age = Console.ReadLine()!;

// ??: Null-coalescing operator — define valor padrão caso a variável seja nula
string input = Console.ReadLine() ?? "padrão";
```

### Formatação e Alinhamento

```csharp
// Alinhamento em colunas com argumentos posicionais
// {índice, largura} — negativo = esquerda, positivo = direita
Console.WriteLine(format: "{0,-10} {1,6}", arg0: "Name", arg1: "Count");
Console.WriteLine(format: "{0,-10} {1,6:N0}", arg0: applesText, arg1: applesCount);

// Resultado:
// Name          Count
// Apples        1,234
// Bananas      56,789
```

| Código | Descrição | Exemplo |
|---|---|---|
| `:C` | Moeda (Currency) | `1234` → `R$ 1.234,00` |
| `:N0` | Número com separador de milhar | `1234` → `1,234` |
| `:X` | Hexadecimal | `255` → `FF` |

> **StringBuilder**: concatenar strings com `+` em loops é ineficiente. Para muitas concatenações use `StringBuilder` do namespace `System.Text`.

---

## Números e Precisão

**Float (32 bits)** e **double (64 bits)** são imprecisos pois trabalham em Base 2 (binário) — apenas aproximam do valor real.

**Decimal (128 bits)** é bem mais preciso porém lento; trabalha em Base 10; essencial para sistemas monetários.

### Valores especiais de float e double

```csharp
double nan = double.NaN;                    // Not-a-Number
double posInf = double.PositiveInfinity;    // Infinito positivo
double negInf = double.NegativeInfinity;    // Infinito negativo
```

### Tamanho em memória com sizeof

```csharp
Console.WriteLine(sizeof(int));     // 4 bytes
Console.WriteLine(sizeof(double));  // 8 bytes
Console.WriteLine(sizeof(decimal)); // 16 bytes
```

### Banker's Rounding (arredondamento padrão do C#)

O C# arredonda `.5` para o número par mais próximo, diferente do arredondamento convencional:

```csharp
Math.Round(10.5); // 10 — arredonda para baixo (par)
Math.Round(11.5); // 12 — arredonda para cima (par)
```

Para forçar o arredondamento convencional:

```csharp
Math.Round(10.5, MidpointRounding.AwayFromZero); // 11
```
