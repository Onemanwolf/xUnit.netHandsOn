# Getting Started

[Docs](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test)

1. Create folder Open Command Prompt and make dir xUnit.

````console
C:\Users\tioleson>md xUnit

```
2. Clone the repo from [xUnit.netHandsOn](https://github.com/Onemanwolf/xUnit.netHandsOn)
.

3. Once the repo is cloned in the How_Session folder open the Code folder and open the GameEngine.sln with Visual Studio.

4. Now that the solution is open we will add a xUnit Test project by right clicking the GameEngine Solution and select add New Project.

![alt text](https://github.com/Onemanwolf/.Net_Core_Api_Getting_Started/blob/master/Labs/images/Add_Test_Project.png?raw=true 'Request Pipeline')

4. In the Create a new ASP.NET Core Web Application dialog, confirm that .NET Core and ASP.NET Core 3.1 are selected. Select the API template and click Create.

![alt text](https://github.com/Onemanwolf/.Net_Core_Api_Getting_Started/blob/master/Labs/images/CreateANewASPDotNetCoreWebApp.png?raw=true 'Request Pipeline')

```json
[
  {
    "date": "2019-07-16T19:04:05.7257911-06:00",
    "temperatureC": 52,
    "temperatureF": 125,
    "summary": "Mild"
  },
  {
    "date": "2019-07-17T19:04:05.7258461-06:00",
    "temperatureC": 36,
    "temperatureF": 96,
    "summary": "Warm"
  },
  {
    "date": "2019-07-18T19:04:05.7258467-06:00",
    "temperatureC": 39,
    "temperatureF": 102,
    "summary": "Cool"
  },
  {
    "date": "2019-07-19T19:04:05.7258471-06:00",
    "temperatureC": 10,
    "temperatureF": 49,
    "summary": "Bracing"
  },
  {
    "date": "2019-07-20T19:04:05.7258474-06:00",
    "temperatureC": -1,
    "temperatureF": 31,
    "summary": "Chilly"
  }
]
````

## Add a model class

1. In Solution Explorer, right-click the project. Select Add > New Folder. Name the folder Models.

```cs
    public class TodoItem
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
}
```

## Add a database context

### Add Microsoft.EntityFrameworkCore.SqlServer

![alt text](https://github.com/Onemanwolf/.Net_Core_Api_Getting_Started/blob/master/Labs/images/InstallEntityFrameWork.png?raw=true 'Request Pipeline')

## Add the TodoContext database context

1.

2. Enter the following code:

```c
 using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
```

## Register the database context

```c
 // Code Here


```

## Examine the PostTodoItem create method

```c#
   // Code here

```

## Asserts

### Test PostTodoItem with Postman

1. Create a new request.

2. Set the HTTP method to POST.

3. Select the Body tab.

4. Select the raw radio button.

5. Set the type to JSON (application/json).

6. In the request body enter JSON for a to-do item:

```Json
      {
  "name":"walk dog",
  "isComplete":true
}
```

![alt text](https://github.com/Onemanwolf/.Net_Core_Api_Getting_Started/blob/master/Labs/images/Postman_Post_Exp_1.png?raw=true 'Request Pipeline')

### Test the location header URI

![alt text](https://github.com/Onemanwolf/.Net_Core_Api_Getting_Started/blob/master/Labs/images/Postman_Location_header.png?raw=true 'Request Pipeline')

## Examine the Get methods

```Json
        [
  {
    "id": 1,
    "name": "Item1",
    "isComplete": false
  }
]
```

### Test Get with Postman

1. Create a new request.
2. Set the HTTP method to GET.
3. Set the request URL to https://localhost:<port>/api/TodoItems. For example, https://localhost:5001/api/TodoItems.
4. Set Two pane view in Postman.
5. Select Send.

## Routing and URL paths

- Start with the template string in the controller's Route attribute:

```C#
//Code here
```

-

```c#
        // Code here
```

## Return values

[EF Core Docs](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-3.1&tabs=visual-studio)
