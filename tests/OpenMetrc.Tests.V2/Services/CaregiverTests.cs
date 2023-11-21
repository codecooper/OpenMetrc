using OpenMetrc.Tests.V2.Fixtures;
using OpenMetrc.Tests.V2.Helpers;

namespace OpenMetrc.Tests.V2.Services;

public class CaregiverTests
    (ITestOutputHelper testOutputHelper, SharedFixture sharedFixture) : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper = new(testOutputHelper);

    [SkippableFact]
    public void GetCaregiverStatusAsync_AdditionalPropertiesAreEmpty_ShouldPass()
    {
        //TODO: get sample caregiverLicenseNumbers
        var caregiverLicenseNumber = string.Empty;
        var testEndpointResult = new TestEndpointResult();
        foreach (var apiKey in sharedFixture.ApiKeys)
            foreach (var facility in apiKey.Facilities)
                try
                {
                    var result = sharedFixture.SafeExecutor(() =>
                        apiKey.MetrcService.Caregivers
                            .GetCaregiverStatusAsync(caregiverLicenseNumber, facility.License.Number).Result);
                    _additionalPropertiesHelper.CheckAdditionalProperties(result, facility.License.Number);
                }
                catch (SharedFixture.TestExceptionWrapper ex)
                {
                    sharedFixture.HandleTestEndpointException(ex, testEndpointResult, apiKey, testOutputHelper);
                }

        sharedFixture.AlertIfSkippableTest(testEndpointResult);
    }
}