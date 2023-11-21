﻿using Asp.Versioning;

namespace OpenMetrc.Builder.Controllers.V2;

[Route("sales/v2")]
[ApiVersion("2")]
[ApiController]
public class SaleController : ControllerBase
{
    [HttpGet("customertypes")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_customertypes)]
    [Authorize]
    [ApiAuthorizationFilter]
    [ProducesResponseType(typeof(MetrcWrapper<string>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get sale customer types")]
    public ActionResult GetSaleCustomerTypes() => Ok();

    [HttpGet("patientregistration/locations")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_patientregistration_locations)]
    [Authorize]
    [ApiAuthorizationFilter]
    [ProducesResponseType(typeof(MetrcWrapper<PatientRegistrationLocation>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get patient registration locations")]
    public ActionResult GetPatientRegistrationLocations() => Ok();

    [HttpGet("deliveries/{id}")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_deliveries_id)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.SalesDelivery })]
    [ProducesResponseType(typeof(SaleDelivery), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get a sales delivery by id")]
    public ActionResult GetSaleDeliveryById(
        [Required] [SwaggerParameter(Description = "Delivery ID")]
        long id,
        [SwaggerParameter("If specified, the Sales Delivery will be validated against the specified License Number. " +
                          "If not specified, the Sales Delivery will be validated against all of the User's current Facilities. " +
                          "Please note that if the Sales Delivery is not valid for the specified License Number, a 401 Unauthorized status will be returned")]
        string licenseNumber
    ) => Ok();

    [HttpGet("deliveries/active")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_deliveries_active)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [ProducesResponseType(typeof(MetrcWrapper<SaleDelivery>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get active sales deliveries")]
    public ActionResult GetActiveSaleDeliveries(
        [Required] string licenseNumber,
        [SwaggerParameter(
            "The sales date start timestamp. If specified, also specifying any of the last modified parameters will result in an error.")]
        DateTimeOffset? salesDateStart,
        [SwaggerParameter(
            "The sales date end timestamp. If specified, also specifying any of the last modified parameters will result in an error.")]
        DateTimeOffset? salesDateEnd,
        [SwaggerParameter(
            "The last modified start timestamp. If specified, also specifying any of the sales date parameters will result in an error.")]
        DateTimeOffset? lastModifiedStart,
        [SwaggerParameter(
            "The last modified end timestamp. If specified, also specifying any of the sales date parameters will result in an error.")]
        DateTimeOffset? lastModifiedEnd
    ) => Ok();

    [HttpGet("deliveries/inactive")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_deliveries_inactive)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [ProducesResponseType(typeof(MetrcWrapper<SaleDelivery>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get inactive sales deliveries")]
    public ActionResult GetInactiveSaleDeliveries(
        [Required] string licenseNumber,
        [SwaggerParameter(
            "The sales date start timestamp. If specified, also specifying any of the last modified parameters will result in an error.")]
        DateTimeOffset? salesDateStart,
        [SwaggerParameter(
            "The sales date end timestamp. If specified, also specifying any of the last modified parameters will result in an error.")]
        DateTimeOffset? salesDateEnd,
        [SwaggerParameter(
            "The last modified start timestamp. If specified, also specifying any of the sales date parameters will result in an error.")]
        DateTimeOffset? lastModifiedStart,
        [SwaggerParameter(
            "The last modified end timestamp. If specified, also specifying any of the sales date parameters will result in an error.")]
        DateTimeOffset? lastModifiedEnd
    ) => Ok();

    [HttpGet("deliveries/returnreasons")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_deliveries_returnreasons)]
    [Authorize]
    [ApiAuthorizationFilter]
    [ProducesResponseType(typeof(MetrcWrapper<DeliveryReturnReason>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get delivery return reasons")]
    public ActionResult GetDeliveryReturnReasons() => Ok();

    [HttpGet("counties")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_counties)]
    [Authorize]
    [ApiAuthorizationFilter]
    [ProducesResponseType(typeof(MetrcWrapper<County>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get counties")]
    public ActionResult GetCounties() => Ok();

    [HttpGet("paymenttypes")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_paymenttypes)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.SalesDelivery })]
    [ProducesResponseType(typeof(MetrcWrapper<string>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get payment types")]
    public ActionResult GetPaymentTypes([Required] string licenseNumber) => Ok();

    [HttpGet("receipts/{id}")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_receipts_id)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [ProducesResponseType(typeof(SaleReceipt), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get a sales receipt by id")]
    public ActionResult GetSaleReceiptById(
        [Required] [SwaggerParameter(Description = "Receipt ID")]
        long id,
        [SwaggerParameter("If specified, the Sales Receipt will be validated against the specified License Number. " +
                          "If not specified, the Sales Receipt will be validated against all of the User's current Facilities. " +
                          "Please note that if the Sales Receipt is not valid for the specified License Number, a 401 Unauthorized status will be returned")]
        string licenseNumber
    ) => Ok();

    [HttpGet("receipts/active")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_receipts_active)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [ProducesResponseType(typeof(MetrcWrapper<SaleReceipt>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get active sales receipts")]
    public ActionResult GetActiveSaleReceipts(
        [Required] string licenseNumber,
        [SwaggerParameter(
            "The sales date start timestamp. If specified, also specifying any of the last modified parameters will result in an error.")]
        DateTimeOffset? salesDateStart,
        [SwaggerParameter(
            "The sales date end timestamp. If specified, also specifying any of the last modified parameters will result in an error.")]
        DateTimeOffset? salesDateEnd,
        [SwaggerParameter(
            "The last modified start timestamp. If specified, also specifying any of the sales date parameters will result in an error.")]
        DateTimeOffset? lastModifiedStart,
        [SwaggerParameter(
            "The last modified end timestamp. If specified, also specifying any of the sales date parameters will result in an error.")]
        DateTimeOffset? lastModifiedEnd
    ) => Ok();

    [HttpGet("receipts/inactive")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_receipts_inactive)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [ProducesResponseType(typeof(MetrcWrapper<SaleReceipt>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get inactive sales receipts")]
    public ActionResult GetInactiveSaleReceipts(
        [Required] string licenseNumber,
        [SwaggerParameter(
            "The sales date start timestamp. If specified, also specifying any of the last modified parameters will result in an error.")]
        DateTimeOffset? salesDateStart,
        [SwaggerParameter(
            "The sales date end timestamp. If specified, also specifying any of the last modified parameters will result in an error.")]
        DateTimeOffset? salesDateEnd,
        [SwaggerParameter(
            "The last modified start timestamp. If specified, also specifying any of the sales date parameters will result in an error.")]
        DateTimeOffset? lastModifiedStart,
        [SwaggerParameter(
            "The last modified end timestamp. If specified, also specifying any of the sales date parameters will result in an error.")]
        DateTimeOffset? lastModifiedEnd
    ) => Ok();

    [HttpPost("deliveries")]
    [MapsToApi(MetrcEndpoint.post_sales_v2_deliveries)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Create a new sale delivery",
        Description =
            "Please note: The SalesDateTime field must be the actual date and time of the transaction without time zone. " +
            "This date/time must already be in the same time zone as the Facility recording the sales. " +
            "For example, if the Facility is in Pacific Time, then this time must be Pacific Standard (or Daylight Savings) Time and not in UTC.")]
    public ActionResult CreateSaleDelivery([Required] string licenseNumber,
        [Required] ICollection<CreateSaleDeliveryRequest> createSaleDeliveryRequests) => Ok();

    [HttpPost("receipts")]
    [MapsToApi(MetrcEndpoint.post_sales_v2_receipts)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Create a new sale receipt",
        Description =
            "Please note: The SalesDateTime field must be the actual date and time of the transaction without time zone. " +
            "This date/time must already be in the same time zone as the Facility recording the sales. " +
            "For example, if the Facility is in Pacific Time, then this time must be Pacific Standard (or Daylight Savings) Time and not in UTC.")]
    public ActionResult CreateSaleReceipt([Required] string licenseNumber,
        [Required] ICollection<CreateSaleReceiptRequest> createSaleReceiptRequests) => Ok();

    [HttpPut("deliveries/hub")]
    [MapsToApi(MetrcEndpoint.put_sales_v2_deliveries_hub)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.SalesDelivery })]
    [SwaggerOperation(Summary = "Update a sale delivery hub",
        Description =
            "Please note: The SalesDateTime field must be the actual date and time of the transaction without time zone. " +
            "This date/time must already be in the same time zone as the Facility recording the sales. " +
            "For example, if the Facility is in Pacific Time, then this time must be Pacific Standard (or Daylight Savings) Time and not in UTC.")]
    public ActionResult UpdateSaleDeliveryHub([Required] string licenseNumber,
        [Required] ICollection<UpdateSaleDeliveryHubRequest> updateSaleDeliveryHubRequest) => Ok();

    [HttpPut("deliveries/hub/accept")]
    [MapsToApi(MetrcEndpoint.put_sales_v2_deliveries_hub_accept)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Update a sale delivery hub to accept")]
    public ActionResult AcceptSaleDeliveryHub([Required] string licenseNumber,
        [Required] ICollection<AcceptSaleDeliveryHubRequest> acceptSaleDeliveryHubRequest) => Ok();

    [HttpPut("deliveries/complete")]
    [MapsToApi(MetrcEndpoint.put_sales_v2_deliveries_complete)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Update a sale delivery to complete",
        Description =
            "Please note: The SalesDateTime field must be the actual date and time of the transaction without time zone. " +
            "This date/time must already be in the same time zone as the Facility recording the sales. " +
            "For example, if the Facility is in Pacific Time, then this time must be Pacific Standard (or Daylight Savings) Time and not in UTC.")]
    public ActionResult UpdateSaleDeliveryComplete([Required] string licenseNumber,
        [Required] ICollection<UpdateSaleDeliveryCompleteRequest> updateSaleDeliveryCompleteRequests) => Ok();

    [HttpPut("deliveries/hub/depart")]
    [MapsToApi(MetrcEndpoint.put_sales_v2_deliveries_hub_depart)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Update a sale delivery hub to depart")]
    public ActionResult DepartSaleDeliveryHub([Required] string licenseNumber,
        [Required] ICollection<DepartSaleDeliveryHubRequest> departSaleDeliveryHubRequest) => Ok();

    [HttpPut("deliveries/hub/verifyID")]
    [MapsToApi(MetrcEndpoint.put_sales_v2_deliveries_hub_verifyID)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Update a sale delivery hub to verify id")]
    public ActionResult VerifyIdSaleDeliveryHub([Required] string licenseNumber,
        [Required] ICollection<VerifyIdSaleDeliveryHubRequest> verifyIdSaleDeliveryHubRequest) => Ok();

    [HttpPut("deliveries")]
    [MapsToApi(MetrcEndpoint.put_sales_v2_deliveries)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Create a new sale delivery",
        Description =
            "Please note: The SalesDateTime field must be the actual date and time of the transaction without time zone. " +
            "This date/time must already be in the same time zone as the Facility recording the sales. " +
            "For example, if the Facility is in Pacific Time, then this time must be Pacific Standard (or Daylight Savings) Time and not in UTC.")]
    public ActionResult UpdateSaleDelivery([Required] string licenseNumber,
        [Required] ICollection<UpdateSaleDeliveryRequest> updateSaleDeliveryRequests) => Ok();

    [HttpPut("receipts")]
    [MapsToApi(MetrcEndpoint.put_sales_v2_receipts)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Create a new sale receipt",
        Description =
            "Please note: The SalesDateTime field must be the actual date and time of the transaction without time zone. " +
            "This date/time must already be in the same time zone as the Facility recording the sales. " +
            "For example, if the Facility is in Pacific Time, then this time must be Pacific Standard (or Daylight Savings) Time and not in UTC.")]
    public ActionResult UpdateSaleReceipt([Required] string licenseNumber,
        [Required] ICollection<UpdateSaleReceiptRequest> updateSaleReceiptRequests) => Ok();

    [HttpPut("receipts/finalize")]
    [MapsToApi(MetrcEndpoint.put_sales_v2_receipts_finalize)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Finalize sale receipts")]
    public ActionResult FinalizeSaleReceipt([Required] string licenseNumber,
        [Required] ICollection<FinalizeSaleReceiptRequest> finalizeSaleReceiptRequests) => Ok();

    [HttpPut("receipts/unfinalize")]
    [MapsToApi(MetrcEndpoint.put_sales_v2_receipts_unfinalize)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Unfinalize sale receipts")]
    public ActionResult UnfinalizeSaleReceipt([Required] string licenseNumber,
        [Required] ICollection<FinalizeSaleReceiptRequest> unfinalizeSaleReceiptRequests) => Ok();

    [HttpDelete("deliveries/{id}")]
    [MapsToApi(MetrcEndpoint.delete_sales_v2_deliveries_id)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Delete an sale delivery")]
    public ActionResult DeleteDelivery([Required] string licenseNumber,
        [Required] [SwaggerParameter(Description = "Sale Delivery ID")]
        long id) => Ok();

    [HttpDelete("receipts/{id}")]
    [MapsToApi(MetrcEndpoint.delete_sales_v2_receipts_id)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.Sales })]
    [SwaggerOperation(Summary = "Delete an sale delivery")]
    public ActionResult DeleteReceipt([Required] string licenseNumber,
        [Required] [SwaggerParameter(Description = "Sale Receipt ID")]
        long id) => Ok();

    [HttpGet("deliveries/retailer/active")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_deliveries_retailer_active)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.RetailerDelivery })]
    [ProducesResponseType(typeof(MetrcWrapper<Retailer>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get active delivery retailers")]
    public ActionResult GetDeliveriesRetailerActive(
        [Required] string licenseNumber,
        [Required] DateTime lastModifiedStart,
        [Required] DateTime lastModifiedEnd) => Ok();

    [HttpGet("deliveries/retailer/inactive")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_deliveries_retailer_inactive)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.RetailerDelivery })]
    [ProducesResponseType(typeof(MetrcWrapper<Retailer>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get inactive delivery retailers")]
    public ActionResult GetDeliveriesRetailerInactive(
        [Required] string licenseNumber,
        [Required] DateTime lastModifiedStart,
        [Required] DateTime lastModifiedEnd) => Ok();

    [HttpGet("deliveries/retailer/{id}")]
    [MapsToApi(MetrcEndpoint.get_sales_v2_deliveries_retailer_id)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.RetailerDelivery })]
    [ProducesResponseType(typeof(Retailer), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get delivery retailer")]
    public ActionResult GetDeliveriesRetailer(
        [Required] [SwaggerParameter(Description = "Retailer ID")]
        long id,
        [Required] string licenseNumber) => Ok();

    [HttpPost("deliveries/retailer")]
    [MapsToApi(MetrcEndpoint.post_sales_v2_deliveries_retailer)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.RetailerDelivery })]
    [SwaggerOperation(Summary = "Create delivery retailer",
        Description =
            "Please note: The DateTime field must be the actual date and time of the transaction without time zone. This date/time must already be in the same time zone as the Facility recording the sales. For example, if the Facility is in Pacific Time, then this time must be Pacific Standard (or Daylight Savings) Time and not in UTC.")]
    public ActionResult CreateDeliveriesRetailer(
        [Required] string licenseNumber,
        [Required] ICollection<CreateSalesDeliveryRetailerRequest> createSalesDeliveryRetailerRequest) => Ok();

    [HttpPut("deliveries/retailer")]
    [MapsToApi(MetrcEndpoint.put_sales_v2_deliveries_retailer)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.RetailerDelivery })]
    [SwaggerOperation(Summary = "Create delivery retailer",
        Description =
            "Please note: The DateTime field must be the actual date and time of the transaction without time zone. This date/time must already be in the same time zone as the Facility recording the sales. For example, if the Facility is in Pacific Time, then this time must be Pacific Standard (or Daylight Savings) Time and not in UTC.")]
    public ActionResult UpdateDeliveriesRetailer(
        [Required] string licenseNumber,
        [Required] ICollection<UpdateSalesDeliveryRetailerRequest> updateSalesDeliveryRetailerRequest) => Ok();

    [HttpDelete("deliveries/retailer/{id}")]
    [MapsToApi(MetrcEndpoint.delete_sales_v2_deliveries_retailer_id)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.RetailerDelivery })]
    [SwaggerOperation(Summary = "Delete delivery retailer")]
    public ActionResult DeleteDeliveriesRetailer(
        [Required] [SwaggerParameter(Description = "Retailer ID")]
        long id,
        [Required] string licenseNumber) => Ok();

    [HttpPost("deliveries/retailer/depart")]
    [MapsToApi(MetrcEndpoint.post_sales_v2_deliveries_retailer_depart)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.RetailerDelivery })]
    [SwaggerOperation(Summary = "Set delivery retailer to departed")]
    public ActionResult DepartDeliveriesRetailer(
        [Required] string licenseNumber,
        [Required] ICollection<UpdateSalesDeliveryRetailerDepartRequest> updateSalesDeliveryRetailerDepartRequest) =>
        Ok();

    [HttpPost("deliveries/retailer/restock")]
    [MapsToApi(MetrcEndpoint.post_sales_v2_deliveries_retailer_restock)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.RetailerDelivery })]
    [SwaggerOperation(Summary = "Restock delivery retailer")]
    public ActionResult RestockDeliveriesRetailer(
        [Required] string licenseNumber,
        [Required] ICollection<UpdateSalesDeliveryRetailerRestockRequest> updateSalesDeliveryRetailerRestockRequest) =>
        Ok();

    [HttpPost("deliveries/retailer/sale")]
    [MapsToApi(MetrcEndpoint.post_sales_v2_deliveries_retailer_sale)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.RetailerDelivery })]
    [SwaggerOperation(Summary = "Create delivery retailer sale",
        Description =
            "Please note: The SalesDateTime field must be the actual date and time of the transaction without time zone. This date/time must already be in the same time zone as the Facility recording the sales. For example, if the Facility is in Pacific Time, then this time must be Pacific Standard (or Daylight Savings) Time and not in UTC.")]
    public ActionResult CreateDeliveriesRetailerSale(
        [Required] string licenseNumber,
        [Required] ICollection<CreateSalesDeliveryRetailerSaleRequest> createSalesDeliveryRetailerSaleRequest) => Ok();

    [HttpPost("deliveries/retailer/end")]
    [MapsToApi(MetrcEndpoint.post_sales_v2_deliveries_retailer_end)]
    [Authorize]
    [ApiAuthorizationFilter(new[] { ApiPermission.RetailerDelivery })]
    [SwaggerOperation(Summary = "Create delivery retailer sale",
        Description =
            "Please note: The ActualArrivalDateTime field must be the actual date and time of the transaction without time zone. This date/time must already be in the same time zone as the Facility recording the sales. For example, if the Facility is in Pacific Time, then this time must be Pacific Standard (or Daylight Savings) Time and not in UTC.\r\n\r\n")]
    public ActionResult EndDeliveriesRetailer(
        [Required] string licenseNumber,
        [Required] ICollection<UpdateSalesDeliveryRetailerEndRequest> updateSalesDeliveryRetailerEndRequest) => Ok();
}