namespace AsyncProgrammingBasicExample;

/*
 The recommended asynchronous pattern is Task-based Asynchronous Programming (TAP)
 a synchronous task blocks CPU or I/O operations until the task is finished
 an asynchronous task ensures non-blocking CPU or I/O operations by scheduling task implementation
 the task keyword works as encapsulation for the async block that either returns a result or throws an exception
 */
class Program
{

    public static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        await OnWebApiCall();
    }

    private static async Task OnWebApiCall()
    {
        // http client to get the api call
        HttpClient httpClient = new HttpClient();
        string apiCallUri = "http://localhost:5101/api/testlongoperation";
        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(apiCallUri);

        string result = await httpResponseMessage.Content.ReadAsStringAsync();

        Console.WriteLine(result);
    }
    
}