﻿using System;

namespace OpenMetrc.Tests;

public class LabTestTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;

    public LabTestTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private SharedFixture Fixture { get; }

    [SkippableFact]
    public async void GetLabTestTypesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var wasTested = false;
        var unauthorized = 0;
        var timeout = 0;
        foreach (var apiKey in Fixture.ApiKeys)
        foreach (var facility in apiKey.Facilities)
            try
            {
                var items = await apiKey.MetrcService.LabTests.GetLabTestTypesAsync();
                if (items == null) continue;
                wasTested = wasTested || items.Any();
                foreach (var item in items)
                    _additionalPropertiesHelper.CheckAdditionalProperties(item, facility.License.Number);
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
        Skip.IfNot(wasTested, "WARN: There were no testable lab test types for any license");
    }

    [SkippableFact]
    public async void GetLabTestStatesAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var wasTested = false;
        var unauthorized = 0;
        var timeout = 0;
        foreach (var apiKey in Fixture.ApiKeys)
            try
            {
                var items = await apiKey.MetrcService.LabTests.GetLabTestStatesAsync();
                wasTested = wasTested || items.Any();
                Assert.NotEmpty(items);
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
                _testOutputHelper.WriteLine($@"{apiKey.OpenMetrcConfig.SubDomain}: Timeout");
                timeout++;
            }

        Skip.If(!wasTested && unauthorized > 0, "WARN: All responses came back as 401 Unauthorized. Could not test.");
        Skip.If(!wasTested && timeout > 0, "WARN: All responses timed out. Could not test.");
        Skip.IfNot(wasTested, "WARN: There were no testable lab test states for any license");
    }

    [Fact(Skip = "This is only testable with a valid package id that has test results")]
    public async void GetLabTestResultsAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        var packageId = 0;
        var wasTested = false;
        var unauthorized = 0;
        var timeout = 0;
        foreach (var apiKey in Fixture.ApiKeys)
        foreach (var facility in apiKey.Facilities)
            try
            {
                var items = await apiKey.MetrcService.LabTests.GetLabTestResultsAsync(packageId,
                    facility.License.Number);
                if (items == null) continue;
                wasTested = wasTested || items.Any();
                foreach (var item in items)
                    _additionalPropertiesHelper.CheckAdditionalProperties(item, facility.License.Number);
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
        Skip.IfNot(wasTested, "WARN: There were no testable lab test states for any license");
    }
}