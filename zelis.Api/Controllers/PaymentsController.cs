// using Microsoft.AspNetCore.Mvc;
// using Zelis.Api.Services;
// using Zelis.Api.DTOs;

// namespace Zelis.Api.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class PaymentsController : ControllerBase
// {
//     private readonly IPaymentService _paymentService;
//     private readonly ILogger<PaymentsController> _logger;

//     public PaymentsController(IPaymentService paymentService, ILogger<PaymentsController> logger)
//     {
//         _paymentService = paymentService;
//         _logger = logger;
//     }

//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<PaymentDto>>> GetAllPayments()
//     {
//         try
//         {
//             _logger.LogInformation("API: Fetching all payments");
//             var payments = await _paymentService.GetAllAsync();
//             return Ok(payments);
//         }
//         catch (Exception ex)
//         {
//             _logger.LogError(ex, "Failed to fetch payments");
//             return StatusCode(500, "Internal server error");
//         }
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<PaymentDto>> GetPayment(int id)
//     {
//         try
//         {
//             var payment = await _paymentService.GetByIdAsync(id);
//             if (payment == null)
//             {
//                 return NotFound($"Payment with ID {id} not found");
//             }
//             return Ok(payment);
//         }
//         catch (Exception ex)
//         {
//             _logger.LogError(ex, $"Failed to fetch payment with ID {id}");
//             return StatusCode(500, "Internal server error");
//         }
//     }

//     [HttpPost]
//     public async Task<ActionResult<PaymentDto>> CreatePayment([FromBody] CreatePaymentDto createDto)
//     {
//         if (!ModelState.IsValid)
//         {
//             return BadRequest(ModelState);
//         }

//         try
//         {
//             var newPayment = await _paymentService.CreateAsync(createDto);
//             return CreatedAtAction(nameof(GetPayment), new { id = newPayment.Id }, newPayment);
//         }
//         catch (Exception ex)
//         {
//             _logger.LogError(ex, "Error creating payment");
//             return StatusCode(500, "Internal server error");
//         }
//     }

//     [HttpPut("{id}")]
//     public async Task<ActionResult<PaymentDto>> UpdatePayment(int id, [FromBody] UpdatePaymentDto updateDto)
//     {
//         if (!ModelState.IsValid)
//         {
//             return BadRequest(ModelState);
//         }

//         try
//         {
//             var updated = await _paymentService.UpdateAsync(id, updateDto);
//             return Ok(updated);
//         }
//         catch (Exception ex)
//         {
//             _logger.LogError(ex, $"Error updating payment {id}");
//             return StatusCode(500, "Internal server error");
//         }
//     }

//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeletePayment(int id)
//     {
//         try
//         {
//             await _paymentService.DeleteAsync(id);
//             return NoContent();
//         }
//         catch (Exception ex)
//         {
//             _logger.LogError(ex, $"Error deleting payment {id}");
//             return StatusCode(500, "Internal server error");
//         }
//     }

//     [HttpGet("health")]
//     public IActionResult HealthCheck()
//     {
//         return Ok($"Zelis Payments API is up and running — {DateTime.Now}");
//     }
// }
