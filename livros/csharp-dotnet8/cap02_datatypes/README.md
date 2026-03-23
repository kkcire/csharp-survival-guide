# Capítulo 2 — Tipos de Dados

## Tipos de Variáveis
```csharp
int integer = 12; // 32 bits

char caracter = 'K'; // aspas simples ; 16 bits - UTF-16

float floater = 12.25f; // precisa do sufixo f

double doubler = 0.4; // mais preciso que float, sem sufixo - padrão para reais

decimal price = 2830.90m; //precisa do sufixo m ; 128 bits (Muita precisão)

object name = "Erick Magagna"; // memória Heap; memória de tipo referência (guarda o endereço)

bool estudante = true; // 8 bits (True/False)
```

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
// $ (Interpolação): ativa interpolação em chaves com variáveis e funções. $$ = {{}} duas chaves e etc...
Console.WriteLine($"{name}");
```

```csharp
// """ (Raw String Literals): armazena multiplas linhas.
string xml = """
             <person age="50">
               <first_name>Mark</first_name>
             </person>
             """;
```

## Números e Precisão

Float (32 bits) e double (64 bits) são imprecisos pois trabalham em Base 2 (binário), apenas aproximam do valor real em binário.
Decimal (128 bits) é bem mais preciso porém lento; trabalha em Base 10 (Decimal); essencial quando trabalha-se com sistemas monetários.