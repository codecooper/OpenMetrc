﻿using System;

namespace OpenMetrc.Tests;

public class SaleTransactionTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;

    public SaleTransactionTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact]
    public async void GetTransactionsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var wasTested = false;
        var unauthorized = 0;
        var timeout = 0;
        foreach (var apiKey in Fixture.ApiKeys)
        foreach (var facility in apiKey.Facilities)
            try
            {
                var saleTransactions =
                    await apiKey.MetrcService.Sales.GetTransactionsAsync(facility.License.Number);
                if (saleTransactions == null) continue;
                wasTested = wasTested || saleTransactions.Any();
                foreach (var saleTransaction in saleTransactions)
                    _additionalPropertiesHelper.CheckAdditionalProperties(saleTransaction, facility.License.Number);
            }
            catch (ApiException<ErrorResponse?> ex)
            {
                if (ex.StatusCode != StatusCodes.Status401Unauthorized &&
                    ex.StatusCode != StatusCodes.Status503ServiceUnavailable)
                {
                    if (ex.Result != null) _testOutputHelper.WriteLine(ex.Result.Message);
                    _testOutputHelper.WriteLine(ex.Response);
                    throw;
                }

                unauthorized++;
            }
            catch (TimeoutException)
            {
                _testOutputHelper.WriteLine($@"{apiKey.OpenMetrcConfig.SubDomain}: {facility.License.Number}: Timeout");
                timeout++;
            }

        Skip.If(!wasTested && unauthorized > 0, "WARN: All responses came back as 401 Unauthorized. Could not test.");
        Skip.If(!wasTested && timeout > 0, "WARN: All responses timed out. Could not test.");
        Skip.IfNot(wasTested, "WARN: There were no testable SaleTransactions for any license");
    }

    [SkippableFact]
    public async void GetInactiveSaleTransactionsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var wasTested = false;
        var unauthorized = 0;
        var timeout = 0;
        var daysBack = -1;
        foreach (var apiKey in Fixture.ApiKeys)
        foreach (var facility in apiKey.Facilities)
            do
                try
                {
                    var saleTransactions = await apiKey.MetrcService.Sales.GetTransactionsByDateRangeAsync(
                        facility.License.Number, DateTimeOffset.UtcNow.AddDays(daysBack - 1),
                        DateTimeOffset.UtcNow.AddDays(daysBack));
                    if (saleTransactions == null) continue;
                    wasTested = wasTested || saleTransactions.Any();
                    foreach (var saleTransaction in saleTransactions)
                        _additionalPropertiesHelper.CheckAdditionalProperties(saleTransaction, facility.License.Number);
                    daysBack--;
                    if (daysBack < -apiKey.DaysToTest) break;
                }
                catch (ApiException<ErrorResponse?> ex)
                {
                    if (ex.StatusCode != StatusCodes.Status401Unauthorized &&
                        ex.StatusCode != StatusCodes.Status503ServiceUnavailable)
                    {
                        if (ex.Result != null) _testOutputHelper.WriteLine(ex.Result.Message);
                        _testOutputHelper.WriteLine(ex.Response);
                        throw;
                    }

                    unauthorized++;
                }
                catch (TimeoutException)
                {
                    _testOutputHelper.WriteLine(
                        $@"{apiKey.OpenMetrcConfig.SubDomain}: {facility.License.Number}: Timeout");
                    timeout++;
                }
            while (true);

        Skip.If(!wasTested && unauthorized > 0, "WARN: All responses came back as 401 Unauthorized. Could not test.");
        Skip.If(!wasTested && timeout > 0, "WARN: All responses timed out. Could not test.");
        Skip.IfNot(wasTested, "WARN: There were no testable SaleTransactions for any license");
    }
}