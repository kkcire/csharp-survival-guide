# Capítulo 3 — Controle de Fluxos

## Operadores Aritméticos (Binários)
Utilizados para cálculos matemáticos padrão entre dois operandos.

| Operador | Nome | Exemplo | Resposta |
|---|---|---|---|
| + | Adição | `num = 13 + 3` | `num = 16` |
| - | Subtração | `num = 13 - 3` | `num = 10` |
| * | Multiplicação | `num = 13 * 3` | `num = 39`|
| / | Divisão | `num = 13 / 3` | `num = 4` |
| % | Módulo (Resto da Divisão) | `num = 13 % 3` | `num = 1` |

---

## Operadores Unários
Operam em apenas um operando (variável).

```csharp
int x = 5;
int postfixIncrement = x++; // define a variável e depois incrementa a referência
int prefixIncrement = ++x;  // incrementa e define a variável incrementada
```

---

## Operadores de Atribuição Composta
Simplificam o código ao realizar uma operação e atribuir o resultado à mesma variável.

```csharp
int p = 6;
p -= 3; // p = 3 ; Equivalente à: p = p - 3
p += 3; // p = 6 ; Equivalente à: p = p + 3
p *= 3; // p = 18 ; Equivalente à: p = p * 3
p /= 3; // p = 6 ; Equivalente à: p = p / 3
```

---

## Operadores de Nulidade (Null-Coalescing)
Recursos modernos do C# para lidar com valores nulos de forma segura, evita `NullReferenceException`.

| Operador | Nome | Explicação | Exemplo |
|---|---|---|---|
| `?` | Nullable Type | Permite que um tipo de variável seja nulo | `int? num;` |
| `??` | Null-coalescing operator | Retorna o valor da esquerda se não for nulo; caso contrário, retorna o da direita | `string name = input ?? "Anônimo";` |
| `??=` | Null-coalescing assignment (C# 8+) | Atribui o valor à variável apenas se ela for nula | `name ??= "Anônimo";` |

---

## Operadores Lógicos

| Operador | Nome | Descrição |
|---|---|---|
| `&` | AND | Verdadeiro se ambos forem verdadeiros |
| `\|` | OR | Verdadeiro se pelo menos um for verdadeiro |
| `^` | XOR | Verdadeiro se apenas um for verdadeiro (exclusivo) |
| `&&` | Conditional AND | Não avalia o segundo se o primeiro for falso (short-circuit) |
| `\|\|` | Conditional OR | Não avalia o segundo se o primeiro for verdadeiro (short-circuit) |

---

## Operadores Diversos

```csharp
nameof(variavel) // retorna o nome da variável como string, não o valor
sizeof(int)      // retorna o tamanho em memória (bytes)
```

```csharp
// Quantos operadores há nessa linha?
char firstDigit = age.ToString()[0];
// = operador de atribuição
// . operador de acesso a membro
// () operador de invocação
// [] operador de acesso por índice
```

---

## Controle de Fluxo

`if` — ramificação que valida uma expressão booleana. Se verdadeiro, executa o bloco.

`else if` — outra expressão para validar, fora do `if` principal.

`else` — opcional; executa se todas as outras expressões forem falsas.

### Pattern Matching

```csharp
// Sem pattern matching — dois passos
if (num is int)
{
    int i = (int)num;
    Console.WriteLine(i);
}

// Com pattern matching — verifica e atribui em um passo só
if (num is int i)
{
    Console.WriteLine(i);
}
```

`num is int i` faz duas coisas ao mesmo tempo:
1. Verifica se `num` é do tipo `int`
2. Se sim, atribui o valor à variável `i` já convertida

Útil quando se trabalha com `object` ou `dynamic`, onde o tipo não é conhecido em tempo de compilação.

### Switch Statement

`switch` é diferente de `if` pois compara uma única expressão com múltiplas possibilidades `case`. Cada `case` deve terminar com:

- `break`
- `return`
- `goto`
- `goto <label>`
- sem instrução (para pular direto ao próximo caso)

Switch statement também suporta Pattern Matching — os cases não precisam ser valores literais, podem ser padrões (patterns).

### Loops

`for` — loop com contador explícito; usado quando se sabe o número de iterações.

`while` — loop que executa enquanto a condição for verdadeira; condição verificada antes de cada iteração.

`do while` — semelhante ao `while`, mas a condição é verificada após a execução — garante pelo menos uma execução.

`foreach` — itera sobre cada elemento de uma coleção ou array sem precisar de índice.

---

## Convenções de Nomenclatura

| Tipo | Convenção | Exemplo |
|---|---|---|
| Variável local | camelCase | `myName` |
| Field público | PascalCase | `Name` |
| Field privado | _camelCase | `_name` |
| Propriedade | PascalCase | `Name` |
| Método | PascalCase | `ToString()` |

---

## Arrays

```
array          = string[]
array 2D       = string[,]
array 3D       = string[,,]
jagged array   = string[][]    // matriz com linhas de diferentes tamanhos
jagged 3D      = string[][][]  // array 3D com linhas de diferentes tamanhos
```

> Quando não há necessidade de adicionar ou remover itens dinamicamente, prefira arrays a collections — arrays são mais eficientes em memória.

---

## Casting e Conversão de Tipos

Casting e conversão têm dois tipos: implícito e explícito.

**Implícito** — acontece automaticamente, sem risco de perda de informação.
```csharp
int x = 10;
double y = x; // seguro — int cabe dentro de double
```

**Explícito** — deve ser feito manualmente pois há risco de perda de informação.
```csharp
double x = 3.9;
int y = (int)x; // perde o .9 — resultado é 3
```

Conversões explícitas também podem ser feitas com `System.Convert`:
```csharp
int y = Convert.ToInt32(3.9); // resultado é 4 (arredonda)
```

Conversões de qualquer tipo para `string` via `ToString()` da classe `System.Object`:
```csharp
int number = 12;
WriteLine(number.ToString());
```

Conversões de objetos binários para string — **Base64 encoding**:
```csharp
byte[] binaryObject = new byte[128];
string encoded = Convert.ToBase64String(binaryObject);
```

Conversões de `string` para tipos numéricos via `Parse`:
```csharp
int num = int.Parse("12");
```

Ou via `TryParse` para evitar exceções:
```csharp
if (int.TryParse(ReadLine(), out int num) && num == 1)
{
    WriteLine("Prosseguindo...");
}
else
{
    WriteLine("Encerrando...");
}
```

> Todas essas classes e namespaces vêm da biblioteca padrão do .NET — a **BCL (Base Class Library)**.

---

## Arredondando Números

O .NET usa valores `enum` do `MidpointRounding` para definir a estratégia de arredondamento:

- `AwayFromZero` — arredonda para longe do zero (convencional)
- `ToZero` — arredonda em direção ao zero (trunca)
- `ToEven` — arredonda para o par mais próximo (Banker's Rounding — padrão do C#)
- `ToPositiveInfinity` — sempre arredonda para cima
- `ToNegativeInfinity` — sempre arredonda para baixo

```csharp
// Math.Round(valor, casas decimais, estratégia)
Math.Round(9.3, 1, MidpointRounding.AwayFromZero); // 9.3
Math.Round(10.5, MidpointRounding.ToEven);          // 10 (Banker's Rounding)
Math.Round(10.5, MidpointRounding.AwayFromZero);    // 11 (convencional)
```

---

## Tratamento de Exceções

### try-catch-finally

Se o código dentro do `try` falhar, a execução pula imediatamente para o `catch`.
O bloco `finally` executa sempre — com ou sem erro.

```csharp
try
{
    int age = int.Parse(ReadLine()!);
    WriteLine($"Você tem {age} anos.");
}
catch (FormatException ex)
{
    WriteLine($"Formato inválido: {ex.Message}");
}
catch (OverflowException ex)
{
    WriteLine($"Número muito grande: {ex.Message}");
}
catch (Exception ex)
{
    WriteLine($"Erro inesperado: {ex.Message}");
}
finally
{
    WriteLine("Finalizando...");
}
```

> Catches mais específicos devem vir antes do genérico `Exception` — caso contrário nunca serão alcançados.

### Exception Filter — `when`

Permite filtrar catches do mesmo tipo com condições diferentes:

```csharp
catch (FormatException) when (amount.Contains("$"))
{
    WriteLine("Amounts cannot use the dollar sign!");
}
catch (FormatException)
{
    WriteLine("Amounts must only contain digits!");
}
```

### checked e unchecked

`checked` — lança uma `OverflowException` quando ocorre overflow aritmético:
```csharp
checked
{
    int x = int.MaxValue + 1; // lança OverflowException
}
```

`unchecked` — remove a verificação de overflow do compilador (comportamento padrão do C#):
```csharp
unchecked
{
    int x = int.MaxValue + 1; // silenciosamente faz overflow — resultado incorreto
}
```