using AcmePay.BL;
using AcmePay.BL.Renders;
using AcmePay.Data.Repositories.PaymentMethodRepositories;
using AcmePay.Data.Repositories.PaymentRepositories;
using AcmePay.Models.Api;
using AcmePay.Models.Api.generic;
using AcmePay.Models.Enums;
using AcmePay.Models.Payments;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AcmePay.Controllers.v1._0;

[Produces("application/json")]
[ApiController]
[ApiVersion("1.0")]
[Route("/api/v{version:apiVersion}/[controller]/[action]")]
[EnableCors("CORS")]
public class PaymentsController : Controller
{
    private readonly IPaymentRepository _payment;
    private readonly IPaymentMethodRepository _paymentMethod;
    private readonly IPaymentRender _render;

    public PaymentsController(IPaymentMethodRepository paymentMethod, IPaymentRepository payment, IPaymentRender render)
    {
        _paymentMethod = paymentMethod;
        _payment = payment;
        _render = render;
    }

    /// <summary>
    /// Create payment
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentModel model,
        CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ApiResponse
            {
                Error = AcmeError.INVALID_DATA,
                Description = ErrorsMapper.Map(ModelState)!
            });
        }

        var methods = await _paymentMethod.ListAsync(cancellationToken);

        return Ok(new ApiResponse<Guid>
        {
            Data = (await _payment.CreatePaymentAsync(model, cancellationToken)).Id,
            Message = MessageEnum.PaymentCreated,
        });
    }


    /// <summary>
    /// Get payment detail
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<PaymentDetailsModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PaymentDetail(
        [FromQuery(Name = "id"), BindRequired] Guid id,
        CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ApiResponse
            {
                Description = ErrorsMapper.Map(ModelState)!,
                Error = AcmeError.INVALID_DATA,
            });
        }

        if (await _payment.GetByIdAsync(id, cancellationToken) is var payment && payment == null)
        {
            return BadRequest(new ApiResponse
            {
                Error = AcmeError.PAYMENT_NOT_FOUND,
            });
        }

        var paymentMethods = await _paymentMethod.ListAsync(cancellationToken);
        return Ok(new ApiResponse<PaymentDetailsModel>
        {
            Data = _render.GetPaymentDetails(payment, paymentMethods),
            Message = MessageEnum.Ok
        });
    }

    /// <summary>
    /// Get payment method details
    /// </summary>
    /// <param name="paymentMethodName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("/api/v{version:apiVersion}/[controller]/[action]/{name}")]
    [ProducesResponseType(typeof(ApiResponse<PaymentMethodModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PaymentDetails(
        [FromRoute(Name = "name"), BindRequired]
        string paymentMethodName,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ApiResponse
            {
                Description = ErrorsMapper.Map(ModelState)!,
                Error = AcmeError.INVALID_DATA,
            });
        }

        if (await _paymentMethod.GetByNameAsync(paymentMethodName, cancellationToken) is var method && method == null)
        {
            return BadRequest(new ApiResponse
            {
                Error = AcmeError.PAYMENT_METHOD_NOT_FOUND
            });
        }

        return Ok(new ApiResponse<PaymentMethodModel>
        {
            Data = _render.GetPaymentMethod(method),
            Message = MessageEnum.Ok
        });
    }

    [HttpPost]
    public async Task<IActionResult> Payment(
        [FromBody] PaymentSubmitModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ApiResponse
            {
                Description = ErrorsMapper.Map(ModelState)!,
                Error = AcmeError.INVALID_DATA,
            });
        }

        if (await _payment.GetByIdAsync(model.PaymentId, cancellationToken) is var payment && payment == null)
        {
            return BadRequest(new ApiResponse
            {
                Error = AcmeError.PAYMENT_NOT_FOUND,
            });
        }

        await _payment.UpdatePaymentStatus(payment, cancellationToken);

        return Ok(new ApiResponse
        {
            Message = MessageEnum.PaymentPaid,
        });
    }
}