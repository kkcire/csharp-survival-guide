# Capítulo 04 — Escrevendo, Depurando e Testando Funções

## 1. Escrevendo Funções
### O Princípio DRY
O objetivo fundamental das funções é seguir o princípio DRY (Don't Repeat Yourself), transformando blocos de código repetitivos em unidades reutilizáveis e isoladas

### Estrutura em Programas de Alto Nível (Top-Level)
- Funções Locais: Em arquivos que usam top-level statements, funções definidas no final do arquivo tornam-se "funções locais" dentro do método `<Main>$` gerado pelo compilador
- Classes Parciais: Para uma melhor organização, o autor recomenda o uso de classes parciais (ex: Program.Functions.cs) para definir funções como membros estáticos da classe Program

### Parâmetros vs. Argumentos
- Parâmetro: É a variável definida na assinatura da função (ex: double b)
- Argumento: É o valor real passado para a função no momento da chamada (ex: 2.5)

###### Recursos Avançados:
- Parâmetros Opcionais: Definidos com valores padrão (ex: int size = 12)
- Argumentos Nomeados: Aumentam a legibilidade ao especificar o nome do parâmetro na chamada

### Documentação com XML
Usar três barras (///) acima de uma função gera comentários XML que alimentam o IntelliSense com descrições de parâmetros e retornos

## 2. Depuração (Debugging)
Ferramentas integradas para pausar a execução e inspecionar o estado do software em tempo de desenvolvimento

### Navegação e Controle
- Breakpoints (F9): Pontos de interrupção que podem ser condicionais (ex: parar apenas se answer > 9)

### Comandos de Execução:
- Step Into (F11): Entra no corpo da função chamada
- Step Over (F10): Executa a função como um passo único
- Step Out (Shift+F11): Sai da função atual e retorna à linha chamadora
- Hot Reload: Aplica alterações de código sem reiniciar a aplicação

### Janelas de Diagnóstico
- Locals/Variables: Mostra variáveis locais automaticamente
- Watch: Permite monitorar expressões específicas manualmente
- Immediate Window/Debug Console: Permite interagir e executar comandos no estado atual da memória

## 3. Instrumentação (Logging)
Monitoramento do código durante o desenvolvimento e em produção

### Debug vs. Trace (System.Diagnostics)
- Classe Debug: Logs visíveis apenas durante o desenvolvimento. São removidos pelo compilador em versões de produção (Release)
- Classe Trace: Logs que permanecem ativos em produção, essenciais para diagnosticar erros no cliente final

### Listeners e Configuração
O código abaixo configura o rastreio para um arquivo de texto no Desktop
```csharp
string logPath = Path.Combine(Environment.GetFolderPath(
    Environment.SpecialFolder.DesktopDirectory), "log.txt");
TextWriterTraceListener logFile = new(File.CreateText(logPath));

Trace.Listeners.Add(logFile);

Trace.AutoFlush = true; // Garante escrita imediata
```

### Níveis de Rastreamento (Trace Levels)
Configurados via appsettings.json, permitem filtrar o que é registrado sem recompilar

| Número | Nome | Função |
| --- | --- | --- |
| 0 | Off | Nada |
| 1 | Error | Apenas erros críticos |
| 2 | Warning | Erros e avisos |
| 3 | Info | Informações gerais (Padrão) |
| 4 | Verbose | Detalhes técnicos completos |


## 4. Testes Unitários
Prática de testar a menor unidade de código isolada de suas dependências

### O Framework xUnit
O livro utiliza o xUnit por ser de código aberto, extensível e possuir amplo suporte da comunidade

- Atributo [Fact]: Identifica um método como um teste unitário.
- Atributo [Theory]: Identifica um teste que recebe vários parâmetros de entrada.

### Padrão AAA:
- Arrange: Organiza os dados de entrada e instâncias
- Act: Executa a unidade sob teste
- Assert: Valida se o resultado é o esperado usando a classe Assert

### Organização de Repositório
Recomenda-se separar a lógica em uma Class Library (.csproj tipo classlib) e os testes em um projeto separado (.csproj tipo xunit) para que os testes não sejam enviados ao cliente final

## 5. Tratamento de Exceções em Funções
### Cláusulas de Guarda (Guard Clauses)
Introduzidas/aprimoradas no .NET 6 e 8, simplificam a validação de argumentos

- ArgumentNullException.ThrowIfNull(accountName);
- ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

### Rethrowing (Relançamento)
- throw;: Relança a exceção original preservando toda a pilha de chamadas (Call Stack)

- throw ex;: Relança a exceção como se tivesse ocorrido na linha atual, perdendo o rastreio original (má prática na maioria dos casos)
