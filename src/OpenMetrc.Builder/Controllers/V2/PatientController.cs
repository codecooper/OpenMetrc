﻿using Asp.Versioning;

namespace OpenMetrc.Builder.Controllers.V2;

[Route("patients/v2")]
[ApiVersion("2")]
[ApiController]
public class PatientController : ControllerBase
{
    [HttpGet("{id}")]
    [MapsToApi(MetrcEndpoint.get_patients_v2_id)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.ManagePatients })]
    [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get a specific patient by id")]
    public ActionResult GetPatientById(
        [Required] [SwaggerParameter(Description = "Patient ID")]
        long id,
        [SwaggerParameter(Description =
            "If specified, the Patient will be validated against the specified License Number. If not specified, the Patient will be validated against all of the User's current Facilities. Please note that if the Patient is not valid for the specified License Number, a 401 Unauthorized status will be returned.")]
        string licenseNumber
    ) => Ok();

    [HttpGet("active")]
    [MapsToApi(MetrcEndpoint.get_patients_v2_active)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.ManagePatients })]
    [ProducesResponseType(typeof(MetrcWrapper<Patient>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get active patients")]
    public ActionResult GetActivePatients(
        [Required]
        [SwaggerParameter(Description =
            "The license number of the facility for which to return the list of active patients.")]
        string licenseNumber) => Ok();

    [HttpGet("statuses/{patientLicenseNumber}")]
    [MapsToApi(MetrcEndpoint.get_patients_v2_statuses_patientLicenseNumber)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.LookupPatients })]
    [ProducesResponseType(typeof(MetrcWrapper<PatientStatus>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get patient status. Data returned by this endpoint is cached for up to one minute")]
    public ActionResult GetPatientStatus(
        [Required] string patientLicenseNumber,
        [Required]
        [SwaggerParameter(Description = "The license number of the Facility under which to get the Patient Status.")]
        string licenseNumber
    ) => Ok();

    [HttpPost]
    [MapsToApi(MetrcEndpoint.post_patients_v2)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.ManagePatients })]
    [SwaggerOperation(Summary = "Create patients")]
    public ActionResult CreatePatient([Required] string licenseNumber,
        [Required] List<CreatePatientRequest> createPatientRequests) => Ok();

    [HttpPut]
    [MapsToApi(MetrcEndpoint.put_patients_v2)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.ManagePatients })]
    [SwaggerOperation(Summary = "Update patients")]
    public ActionResult UpdatePatient([Required] string licenseNumber,
        [Required] List<UpdatePatientRequest> updatePatientRequests) => Ok();

    [HttpDelete("{id}")]
    [MapsToApi(MetrcEndpoint.delete_patients_v2_id)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.ManagePatients })]
    [SwaggerOperation(Summary = "Delete an patient")]
    public ActionResult DeletePatient([Required] string licenseNumber,
        [Required] [SwaggerParameter(Description = "Patient ID")]
        long id) => Ok();
}