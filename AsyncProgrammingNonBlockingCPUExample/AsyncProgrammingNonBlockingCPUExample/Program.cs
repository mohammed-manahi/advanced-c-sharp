namespace AsyncProgrammingNonBlockingCPUExample;

// A non-blocking cpu task implementation using TAP approach
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Method Name: {nameof(Main)}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        StockMarketTechnicalAnalysisData stockMarketTechnicalAnalysisData =
            new StockMarketTechnicalAnalysisData(
                "STKZA",
                new DateTime(2010, 1, 1),
                new DateTime(2020, 1, 1));
        
        DateTime before = DateTime.Now;
        // Synchronous implementation
        // decimal[] data1 = stockMarketTechnicalAnalysisData.GetOpeningPrices();
        // decimal[] data2 = stockMarketTechnicalAnalysisData.GetClosingPrices();
        // decimal[] data3 = stockMarketTechnicalAnalysisData.GetPriceHighs();
        // decimal[] data4 = stockMarketTechnicalAnalysisData.GetPriceLows();
        
        // Asynchronous implementation
        List<Task<decimal[]>> tasks = new List<Task<decimal[]>>();
        
        Task<decimal[]> openingPricesTask = Task.Run(() => stockMarketTechnicalAnalysisData.GetOpeningPrices());
        Task<decimal[]> closingPricesTask = Task.Run(() => stockMarketTechnicalAnalysisData.GetClosingPrices());
        Task<decimal[]> priceHighsTask = Task.Run(() => stockMarketTechnicalAnalysisData.GetPriceHighs());
        Task<decimal[]> priceLowsTask = Task.Run(() => stockMarketTechnicalAnalysisData.GetPriceLows());
        
        tasks.Add(openingPricesTask);
        tasks.Add(closingPricesTask);
        tasks.Add(priceLowsTask);
        tasks.Add(openingPricesTask);
        // Wait for all four methods to be completed
        Task.WaitAll(tasks.ToArray());
        decimal[] data1 = tasks[0].Result;
        decimal[] data2 = tasks[1].Result;
        decimal[] data3 = tasks[2].Result;
        decimal[] data4 = tasks[3].Result;
        
        DateTime after = DateTime.Now;
        TimeSpan duration = after.Subtract(before);
        Console.WriteLine($"Time duration: {duration.Seconds} {(duration.Seconds >1 ? "seconds" : "second")}");
        // decimal[] data5 = stockMarketTechnicalAnalysisData.CalculteStochastics();
        // decimal[] data6 = stockMarketTechnicalAnalysisData.CalculateFastMovingAverage();
        // decimal[] data7 = stockMarketTechnicalAnalysisData.CalculateSlowMovingAverage();
        // decimal[] data8 = stockMarketTechnicalAnalysisData.CalculateUpperBoundBollingerBand();
        // decimal[] data9 = stockMarketTechnicalAnalysisData.CalculateLowerBoundBollingerBand();
    }
}