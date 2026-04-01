# Capítulo 3 - Controle de Fluxos

## Operadores Aritméticos (Binários)
Utilizados para cálculos matemáticos padrão entre dois operandos.
| Operador | Nome | Exemplo | Resposta |
|---|---|---|---|
| + | Adição | `num = 13 + 3` | `num = 16` |
| - | Subtração | `num = 13 - 3` | `num = 10` |
| * | Multiplicação | `num = 13 * 3` | `num = 39`|
| / | Divisão | `num = 13 / 3` | `num = 4` |
| % | Módulo (Resto da Divisão) | `num = 13 % 3` | `num = 1` |

## Operadores Unários
Operam em apenas um operando (variável).
```csharp
int x = 5; 
int postfixIncrement = x++; //define a variável e depois incrementa a referência
int prefixIncrement = ++x; //incrementa e define a variável incrementada
```

## Operadores de Atribuição Composta
Simplificam o código ao realizar uma operação e atribuir o resultado à mesma variável.
```csharp
int p = 6; 
p -= 3; // p = 3 ; Equivalente à: p = p - 3
p += 3; // p = 6 ; Equivalente à: p = p + 3
p *= 3; // p = 18 ; Equivalente à: p = p * 3
p /= 3; // p = 6 ; Equivalente à: p = p / 3
```

## Operadores de Nulidade (Null-Coalesceing)
Recursos modernos do C# para lidar com valores nulos de forma segura, evita `NullReferenceException`.
| Operador | Nome | Explição | Exemplo |
|---|---|---|---|
| ? | Nullable Type | Permite que um tipo de variável seja nulo | `int? num;` |
| ?? | Null-coalescening operator | Retorna o valor da esquerda se não for nulo; caso contrário, retorna o da direita | `string name = input ?? "Anônimo";` |
| ??= | Null-coalescing assignment | Atribui o valor à variável apenas se ela for nula | `name ??= "Anônimo";`|

## Operadores Lógicos
| Operador | Nome | Descrição |
|---|---|---|
| `&` | AND | Verdadeiro se ambos forem verdadeiros. |
| `\|` | OR | Verdadeiro se pelo menos um for verdadeiro. |
| `^` | XOR | Verdadeiro se apenas um for verdadeiro (exclusivo). |
| `&&` | Conditional AND | Não avalia o segundo se o primeiro for falso. |
| `\|\|` | Conditional OR | Não avalia o segundo se o primeiro for verdadeiro. |